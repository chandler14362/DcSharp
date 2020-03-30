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
            
            // Read each parameter
            var parameters = context.parameters;
            while (parameters != null)
            {
                var parameter = BuildDcParameterFromContext(parameters.p);
                field.AddElement(parameter);
                parameters = parameters.next;
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
            return parameter;
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
