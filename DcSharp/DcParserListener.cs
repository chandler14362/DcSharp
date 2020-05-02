using Krypton.Buffers;
using System;
using System.Buffers.Binary;

namespace DcSharp
{
    public class DcParserListener : DcParserBaseListener
    {
        private DcFile _dcFile;

        private DcClass _currentClass;

        public DcParserListener(DcFile dcFile)
        {
            _dcFile = dcFile;
        }

        /// <summary>
        /// keyword_declaration : KEYWORD name=IDENTIFIER
        /// </summary>
        /// <param name="context"></param>
        /// <exception cref="Exception"></exception>
        public override void EnterKeyword_declaration(DcParser.Keyword_declarationContext context)
        {
            if (!_dcFile.AddKeyword(context.name.Text))
            {
                throw new Exception($"Failed to add keyword: {context.name.Text}");
            }
        }

        public override void EnterTypedef_declaration(DcParser.Typedef_declarationContext context)
        {
            var parameter = BuildDcParameterFromContext(context.p);
            var typedef = new DcTypedef(parameter);
            if (!_dcFile.AddTypedef(typedef))
                throw new Exception($"Failed to add typedef: {typedef.Name}");
        }

        public override void EnterClass_declaration(DcParser.Class_declarationContext context)
        {
            _currentClass = new DcClass(_dcFile, context.name.Text, false, false);
            
            // Add all our parents
            var parents = context.parents;
            while (parents != null)
            {
                if (!_dcFile.TryGetClassByName(parents.name.Text, out var parent))
                    throw new Exception($"Unknown parent: {parents.name.Text}");
                
                _currentClass.AddParent(parent);
                parents = parents.next;
            }
        }

        public override void ExitClass_declaration(DcParser.Class_declarationContext context)
        {
            _dcFile.AddClass(_currentClass);
            _currentClass = null;
        }

        public override void EnterStruct_declaration(DcParser.Struct_declarationContext context)
        {
            _currentClass = new DcClass(_dcFile, context.name.Text, true, false);
        }

        public override void ExitStruct_declaration(DcParser.Struct_declarationContext context)
        {
            _dcFile.AddClass(_currentClass);
            _currentClass = null;
        }

        public override void EnterStruct_field(DcParser.Struct_fieldContext context)
        {
            // Our other listeners will deal with the class_field
            if (context.p == null)
                return;

            var param = BuildDcParameterFromContext(context.p);
            _currentClass.AddField(param);
        }

        public override void EnterMolecular_field(DcParser.Molecular_fieldContext context)
        {
            var field = new DcMolecularField(context.name.Text, _currentClass);
            
            // Add each atomic
            var members = context.members;
            while (members != null)
            {
                if (!_currentClass.TryGetFieldByName(members.name.Text, out var atomic))
                    throw new Exception($"Unknown field {members.name.Text}");

                if (!(atomic is DcAtomicField atomicField))
                    throw new Exception($"Member field must be atomic");

                field.AddAtomic(atomicField);
                members = members.next;
            }

            if (!_currentClass.AddField(field))
                throw new Exception($"Failed to add field {context.name.Text}");
        }

        public override void EnterAtomic_field(DcParser.Atomic_fieldContext context)
        {
            var field = new DcAtomicField(context.name.Text, _currentClass, false);
            
            // Read keywords
            ReadKeywordsIntoList(context.keywords, field.KeywordList);

            var hasDefaultValue = false;
            
            // Read each parameter
            var parameters = context.parameters;
            while (parameters != null)
            {
                var parameter = BuildDcParameterFromContext(parameters.p);
                hasDefaultValue = parameter.HasDefaultValue;
                field.AddElement(parameter);
                parameters = parameters.next;
            }
            
            if (hasDefaultValue)
            {
                var bw = new GrowingSpanBuffer(stackalloc byte[512]);
                foreach (var element in field.Elements)
                    bw.WriteBytes(element.DefaultValue.Span);
                field.DefaultValue = bw.Data.ToArray();
                field.HasDefaultValue = true;
            }

            if (!_currentClass.AddField(field))
                throw new Exception($"Failed to add field {context.name.Text}");
        }

        private void ReadKeywordsIntoList(DcParser.Keyword_listContext? context, DcKeywordList into)
        {
            while (context != null)
            {
                if (!_dcFile.TryGetKeyword(context.keyword.Text, out var keyword))
                    throw new Exception($"Unknown keyword: {context.keyword.Text}");
                
                into.AddKeyword(keyword);
                context = context.next;
            }
        }

        private DcParameter BuildDcParameterFromContext(DcParser.ParameterContext context)
        {
            DcParameter parameter;

            uint divisor = 1;
            if (context.divisor != null)
                divisor = uint.Parse(context.divisor.Text);

            // Array parameters
            // TODO: Parse range in specification
            var array = context.array;
            if (array != null)
            {
                var elementType = CreateParameterFromName(context.type.Text, divisor);
                parameter = new DcArrayParameter(elementType, new DcUIntRange());

                array = array.next;
                while (array != null)
                {
                    parameter.AppendArraySpecification(new DcUIntRange());
                    array = array.next;
                }
            }
            else
            {
                parameter = CreateParameterFromName(context.type.Text, divisor);
            }

            parameter.Name = context.name?.Text ?? "";
            
            if (context.default_value() != null) {
                var bw = new GrowingSpanBuffer(stackalloc byte[128]);
                CreateDefaultValueFromParameter(parameter, context.default_value(), ref bw);
                parameter.DefaultValue = bw.Data.ToArray();
                parameter.HasDefaultValue = true;
            }

            return parameter;
        }

        private void CreateDefaultValueFromParameter(DcParameter pi, DcParser.Default_valueContext context, ref GrowingSpanBuffer bw)
        {
            switch (pi)
            {
                case DcSimpleParameter param: 
                {
                    PackValueFromSimpleParameter(param, context.value.GetText(), ref bw);
                    break;
                }
                case DcArrayParameter param: 
                {
                    PackValueFromArrayParameter(param, context, ref bw);
                    break;
                }
                default:
                    throw new Exception("Unsupported default value for parameter.");
            }
        }

        private void PackValueFromSimpleParameter(DcSimpleParameter param, String text, ref GrowingSpanBuffer bw)
        {
            switch (param.Type)
            {
                case DcSubatomicType.Int8:
                {
                    if (!sbyte.TryParse(text, out var value))
                        throw new Exception("Error parsing default value");
                    bw.WriteInt8(value);
                    break;
                }
                case DcSubatomicType.UInt8:
                {
                    if (!byte.TryParse(text, out var value))
                        throw new Exception("Error parsing default value");
                    bw.WriteUInt8(value);
                    break;
                }
                case DcSubatomicType.Int16:
                {
                    if (!short.TryParse(text, out var value))
                        throw new Exception("Error parsing default value");
                    bw.WriteInt16(value);
                    break;
                }
                case DcSubatomicType.UInt16:
                {
                    if (!ushort.TryParse(text, out var value))
                        throw new Exception("Error parsing default value");
                    bw.WriteUInt16(value);
                    break;
                }
                case DcSubatomicType.Int32:
                {
                    if (!int.TryParse(text, out var value))
                        throw new Exception("Error parsing default value");
                    bw.WriteInt32(value);
                    break;
                }
                case DcSubatomicType.UInt32:
                {
                    if (!uint.TryParse(text, out var value))
                        throw new Exception("Error parsing default value");
                    bw.WriteUInt32(value);
                    break;
                }
                case DcSubatomicType.Int64:
                {
                    if (!long.TryParse(text, out var value))
                        throw new Exception("Error parsing default value");
                    bw.WriteInt64(value);
                    break;
                }
                case DcSubatomicType.UInt64:
                {
                    if (!ulong.TryParse(text, out var value))
                        throw new Exception("Error parsing default value");
                    bw.WriteUInt64(value);
                    break;
                }
                case DcSubatomicType.Char:
                {
                    bw.WriteUInt8((byte)text[0]);
                    break;
                }
                case DcSubatomicType.Blob:
                {
                    if (text.Length == 0 || text == "''" || text == "\"\"" || text == "[]")
                    {
                        bw.WriteUInt16(0);
                        return;
                    }


                    if (!text.StartsWith('['))
                    {
                        bw.WriteString8(text);
                        return;
                    }

                    text = text.Substring(1, text.Length - 2);


                    var bookmark = bw.ReserveBookmark(2);
                    int totalSize = 0;

                    String[] vars = text.Split(',');

                    foreach (String var in vars)
                    {
                        String[] byteDef = var.Split('*');
                        byte value = byte.Parse(byteDef[0]);

                        if (byteDef.Length == 1)
                        {
                            bw.WriteUInt8(value);
                            ++totalSize;
                            continue;
                        }

                        ushort size = ushort.Parse(byteDef[1]);
                        for (int i = 0; i < size; i++)
                        {
                            bw.WriteUInt8(value);
                        }

                        totalSize += size;

                    }

                    bw.WriteBookmark(bookmark, (ushort)totalSize, BinaryPrimitives.WriteUInt16LittleEndian);

                    return;

                }
                case DcSubatomicType.String:
                {
                    if (text.Length > 2)
                        bw.WriteString8(text.Substring(1, text.Length - 1));
                    return;
                }
                case DcSubatomicType.Float64:
                {
                    if (!double.TryParse(text, out var value))
                        throw new Exception("Error parsing default value");
                    bw.WriteFloat64(value);
                    break;
                }
                default:
                    throw new Exception("Unsupported DCType for packing default:" + param.Type);
            }
        }

        private void PackValueFromArrayParameter(DcArrayParameter param, DcParser.Default_valueContext context, ref GrowingSpanBuffer bw)
        {
            String text = context.value.GetText();
            if(text == "[]")
            {
                bw.WriteUInt16(0);
                return;
            }
            
            text = text.Substring(1, text.Length - 2);

            GrowingSpanBuffer.Bookmark bookmark = default;
            if (!param.HasFixedByteSize)
            {
                bookmark = bw.ReserveBookmark(2);
            }

            var startSize = bw.Size;

            foreach (var element in text.Split(','))
            {
                String[] elementDef = element.Split('*');

                if (elementDef.Length > 1)
                {
                    ushort count = ushort.Parse(elementDef[1]);
                    for (ushort i = 0; i < count; i++)
                    {
                        PackValueFromSimpleParameter((DcSimpleParameter)param.GetNestedField(0), elementDef[0], ref bw);
                    }
                }
                else
                {
                    PackValueFromSimpleParameter((DcSimpleParameter)param.GetNestedField(0), element, ref bw);
                }
            }

            if (!param.HasFixedByteSize)
            {
                var length = bw.Size - startSize;
                bw.WriteBookmark(bookmark, (ushort) length, BinaryPrimitives.WriteUInt16LittleEndian);
            }
        }
        
        private DcParameter CreateParameterFromName(string name, uint divisor=1)
        {
            // Builtin types:
            if (name == "uint8")
                return new DcSimpleParameter(DcSubatomicType.UInt8, divisor);
            else if (name == "uint16")
                return new DcSimpleParameter(DcSubatomicType.UInt16, divisor);
            else if (name == "uint32")
                return new DcSimpleParameter(DcSubatomicType.UInt32, divisor);
            else if (name == "uint64")
                return new DcSimpleParameter(DcSubatomicType.UInt64, divisor);
            else if (name == "int8")
                return new DcSimpleParameter(DcSubatomicType.Int8, divisor);
            else if (name == "int16")
                return new DcSimpleParameter(DcSubatomicType.Int16, divisor);
            else if (name == "int32")
                return new DcSimpleParameter(DcSubatomicType.Int32, divisor);
            else if (name == "int64")
                return new DcSimpleParameter(DcSubatomicType.Int64, divisor);
            else if (name == "float64")
                return new DcSimpleParameter(DcSubatomicType.Float64);
            else if (name == "string")
                return new DcSimpleParameter(DcSubatomicType.String);
            else if (name == "char")
                return new DcSimpleParameter(DcSubatomicType.Char);
            else if (name == "blob")
                return new DcSimpleParameter(DcSubatomicType.Blob);
            else if (name == "blob32")
                return new DcSimpleParameter(DcSubatomicType.Blob32);
            else if (name == "int8array")
                return new DcSimpleParameter(DcSubatomicType.Int8Array, divisor);
            else if (name == "int16array")
                return new DcSimpleParameter(DcSubatomicType.Int16Array, divisor);
            else if (name == "int32array")
                return new DcSimpleParameter(DcSubatomicType.Int32Array, divisor);
            else if (name == "uint8array")
                return new DcSimpleParameter(DcSubatomicType.UInt8Array, divisor);
            else if (name == "uint16array")
                return new DcSimpleParameter(DcSubatomicType.UInt16Array, divisor);
            else if (name == "uint32array")
                return new DcSimpleParameter(DcSubatomicType.UInt32Array, divisor);
            else if (name == "uint32uint8array")
                return new DcSimpleParameter(DcSubatomicType.UInt32UInt8Array);

            // Check against typedefs
            if (_dcFile.TryGetTypedef(name, out var typedef))
                return typedef.Parameter;

            // Check for class
            if (_dcFile.TryGetClassByName(name, out var dclass))
                return new DcClassParameter(dclass);
            
            throw new Exception($"Couldn't resolve name {name}");
        }
    }
}
