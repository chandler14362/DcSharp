using System.Collections.Generic;
using System.Linq;

namespace DcSharp
{
    public class DcMolecularField : DcField
    {
        private List<DcAtomicField> _fields;

        public IReadOnlyList<DcAtomicField> Fields => _fields.AsReadOnly();

        public DcMolecularField(string name, DcClass dclass) : base(name, dclass)
        {
            _fields = new List<DcAtomicField>();
        }

        public void AddAtomic(DcAtomicField field)
        {
            // Copy our keywords from our first field
            if (_fields.Count == 0)
                KeywordList = new DcKeywordList(field.KeywordList);

            _fields.Add(field);
            NumNestedFields = _fields.Count;

            if (HasFixedByteSize)
            {
                HasFixedByteSize = field.HasFixedByteSize;
                FixedByteSize += field.FixedByteSize;
            }

            if (HasFixedStructure)
                HasFixedStructure = field.HasFixedStructure;

            if (!HasRangeLimits)
                HasRangeLimits = field.HasRangeLimits;

            if (!HasDefaultValue)
                HasDefaultValue = field.HasDefaultValue;

            DefaultValueStale = true;
        }

        public override DcPackerInterface GetNestedField(int n)
        {
            return _fields[n];
        }

        public override string ToString()
        {
            return $"{Name} : {string.Join(", ", _fields.Select(x => x.Name))}";
        }
    }
}