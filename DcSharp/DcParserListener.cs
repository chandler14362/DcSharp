using Krypton.Buffers;
using System;

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

        public override void EnterParameter_field(DcParser.Parameter_fieldContext context)
        {
            var param = BuildDcParameterFromContext(context.parameter());
            ReadKeywordsIntoList(context.keywords, param.KeywordList);
            
            if (!_currentClass.AddField(param))
                throw new Exception($"Failed to add field {param.Name} to class {_currentClass.Name}");
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
                throw new Exception($"Failed to add field {context.name.Text} to class {_currentClass.Name}");
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
                var bw = new SpanBufferWriter(stackalloc byte[512]);
                foreach (var element in field.Elements)
                    bw.WriteBytes(element.DefaultValue.Span);
                field.DefaultValue = bw.Data.ToArray();
                field.HasDefaultValue = true;
            }

            if (!_currentClass.AddField(field))
                throw new Exception($"Failed to add field {context.name.Text} to class {_currentClass.Name}");
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

            DcLongRange? paramRange = null;
            if (context.parameter_range() != null)
            {
                paramRange = new DcLongRange();
                ReadRangeArgumentsIntoRange(context.parameter_range().range_arguments(), paramRange);
            }

            // Array parameters
            var array = context.array;
            if (array != null)
            {
                var elementType = CreateParameterFromName(context.type.Text, divisor, paramRange);
                
                var range = new DcUIntRange();
                if (context.array.range != null)
                    ReadRangeArgumentsIntoRange(context.array.range, range);
                
                parameter = new DcArrayParameter(elementType, range);

                array = array.next;
                while (array != null)
                {
                    range = new DcUIntRange();
                    if (context.array.range != null)
                        ReadRangeArgumentsIntoRange(context.array.range, range);

                    parameter.AppendArraySpecification(range);
                    array = array.next;
                }
            }
            else
            {
                parameter = CreateParameterFromName(context.type.Text, divisor, paramRange);
            }

            parameter.Name = context.name?.Text ?? "";
            
            if (context.default_value() != null) 
            {
                var bw = new SpanBufferWriter(stackalloc byte[512]);
                bw.WriteValueConstant(parameter, context.default_value().value);
                parameter.DefaultValue = bw.Data.ToArray();
                parameter.HasDefaultValue = true;
            }

            return parameter;
        }

        private void ReadRangeArgumentsIntoRange(DcParser.Range_argumentsContext context, DcUIntRange range)
        {
            while (context != null)
            {
                var arg = context.range_argument();
                
                if (arg.single != null)
                {
                    if (!uint.TryParse(arg.single.GetText(), out var single))
                        throw new Exception($"Error parsing array range '{arg.single.GetText()}' on line {arg.single.Start.Line}");

                    range.Add(single, single);
                }
                else if (arg.@char != null)
                {
                    // Index 1 because the text includes quotes
                    var value = (uint) arg.@char.Text[1];
                    range.Add(value, value);
                }
                else
                {
                    if (!uint.TryParse(arg.min.GetText(), out var min))
                        throw new Exception($"Error parsing array range min '{arg.min.GetText()}' on line {arg.min.Start.Line}");

                    if (!uint.TryParse(arg.min.GetText(), out var max))
                        throw new Exception($"Error parsing array range max '{arg.max.GetText()}' on line {arg.max.Start.Line}");

                    range.Add(min, max);
                }
                
                context = context.next;
            }
        }
        
        private void ReadRangeArgumentsIntoRange(DcParser.Range_argumentsContext context, DcLongRange range)
        {
            while (context != null)
            {
                var arg = context.range_argument();
                
                if (arg.single != null)
                {
                    if (!long.TryParse(arg.single.GetText(), out var single))
                        throw new Exception($"Error parsing array range '{arg.single.GetText()}' on line {arg.single.Start.Line}");

                    range.Add(single, single);
                }
                else if (arg.@char != null)
                {
                    // Index 1 because the text includes quotes
                    var value = (uint) arg.@char.Text[1];
                    range.Add(value, value);
                }
                else
                {
                    if (!long.TryParse(arg.min.GetText(), out var min))
                        throw new Exception($"Error parsing array range min '{arg.min.GetText()}' on line {arg.min.Start.Line}");

                    if (!long.TryParse(arg.min.GetText(), out var max))
                        throw new Exception($"Error parsing array range max '{arg.max.GetText()}' on line {arg.max.Start.Line}");

                    range.Add(min, max);
                }
                
                context = context.next;
            }
        }
        
        private DcParameter CreateParameterFromName(string name, uint divisor=1, DcLongRange range=null)
        {
            // Builtin types:
            if (name == "uint8")
                return new DcSimpleParameter(DcSubatomicType.UInt8, divisor, range);
            else if (name == "uint16")
                return new DcSimpleParameter(DcSubatomicType.UInt16, divisor, range);
            else if (name == "uint32")
                return new DcSimpleParameter(DcSubatomicType.UInt32, divisor, range);
            else if (name == "uint64")
                return new DcSimpleParameter(DcSubatomicType.UInt64, divisor, range);
            else if (name == "int8")
                return new DcSimpleParameter(DcSubatomicType.Int8, divisor, range);
            else if (name == "int16")
                return new DcSimpleParameter(DcSubatomicType.Int16, divisor, range);
            else if (name == "int32")
                return new DcSimpleParameter(DcSubatomicType.Int32, divisor, range);
            else if (name == "int64")
                return new DcSimpleParameter(DcSubatomicType.Int64, divisor, range);
            else if (name == "float64")
                return new DcSimpleParameter(DcSubatomicType.Float64, range: range);
            else if (name == "string")
                return new DcSimpleParameter(DcSubatomicType.String, range: range);
            else if (name == "char")
                return new DcSimpleParameter(DcSubatomicType.Char, range: range);
            else if (name == "blob")
                return new DcSimpleParameter(DcSubatomicType.Blob, range: range);
            else if (name == "blob32")
                return new DcSimpleParameter(DcSubatomicType.Blob32, range: range);
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
