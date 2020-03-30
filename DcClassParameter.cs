using System.Collections.Generic;

namespace DcSharp
{
    public class DcClassParameter : DcParameter
    {
        private DcClass _dclass;
        private List<DcPackerInterface> _nestedFields;
        
        public DcClassParameter(DcClass dcClass) : base()
        {
            _dclass = dcClass;
            _nestedFields = new List<DcPackerInterface>();
            Name = _dclass.Name;

            var numFields = _dclass.NumInheritedFields;

            if (_dclass.Constructor != null)
            {
                _nestedFields.Add(_dclass.Constructor);
                HasDefaultValue = HasDefaultValue || _dclass.Constructor.HasDefaultValue;
            }

            for (var i = 0; i < numFields; i++)
            {
                var field = _dclass.GetInheritedField(i);
                if (!(field is DcMolecularField))
                {
                    _nestedFields.Add(field);
                    HasDefaultValue = HasDefaultValue || field.HasDefaultValue;
                }
            }

            NumNestedFields = _nestedFields.Count;

            HasFixedByteSize = true;
            FixedByteSize = 0;
            HasFixedStructure = true;
            for (var i = 0; i < NumNestedFields; i++)
            {
                var field = _nestedFields[i];
                
                HasFixedByteSize = HasFixedByteSize && field.HasFixedByteSize;
                FixedByteSize += field.FixedByteSize;
                HasFixedStructure = HasFixedStructure && field.HasFixedStructure;
                HasRangeLimits = HasRangeLimits || field.HasRangeLimits;
            }
        }

        public override DcPackerInterface GetNestedField(int n)
        {
            return _nestedFields[n];
        }

        public override string ToString()
        {
            return $"{_dclass.Name}";
        }
    }
}
