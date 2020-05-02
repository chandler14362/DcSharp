using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace DcSharp
{
    public class DcAtomicField : DcField
    {
        private List<DcParameter> _elements;

        public ReadOnlyCollection<DcParameter> Elements => _elements.AsReadOnly();

        public DcAtomicField(string name, DcClass dclass, bool isBogus) : base(name, dclass)
        {
            _elements = new List<DcParameter>();
            Bogus = isBogus;
        }

        public void AddElement(DcParameter element)
        {
            _elements.Add(element);
            NumNestedFields = _elements.Count;

            if (HasFixedByteSize)
            {
                HasFixedByteSize = element.HasFixedByteSize;
                FixedByteSize += element.FixedByteSize;
            }

            if (HasFixedStructure)
                HasFixedStructure = element.HasFixedStructure;

            if (!HasRangeLimits)
                HasRangeLimits = element.HasRangeLimits;

            if (!HasDefaultValue)
                HasDefaultValue = element.HasDefaultValue;

            DefaultValueStale = true;
        }

        public override DcPackerInterface GetNestedField(int n)
        {
            return _elements[n];
        }

        public override string ToString()
        {
            var elements = string.Join(", ", _elements.Select(x => x.ToString()));
            var keywords = string.Join(" ", KeywordList.Keywords.Select(x => x.Name));
            return $"{Name}({elements}) {keywords}";
        }
    }
}