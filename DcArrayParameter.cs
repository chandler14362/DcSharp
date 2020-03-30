using System;
using System.Buffers.Binary;

namespace DcSharp
{
    public class DcArrayParameter : DcParameter
    {
        private DcParameter _elementType;
        private int _arraySize;
        private DcUIntRange _arraySizeRange;

        public DcArrayParameter(DcParameter elementType, DcUIntRange size)
        {
            _elementType = elementType;
            _arraySize = -1;
            _arraySizeRange = size;
            HasFixedByteSize = false;

            Name = elementType.Name;
            elementType.Name = string.Empty;

            if (_arraySizeRange.HasOneValue())
                _arraySize = (int)_arraySizeRange.GetOneValue();
            else
                HasRangeLimits = true;

            if (_arraySize >= 0 && _elementType.HasFixedByteSize)
            {
                HasFixedByteSize = true;
                FixedByteSize = _arraySize * _elementType.FixedByteSize;
                HasFixedStructure = true;
            }
            else
            {
                NumLengthBytes = 2;
            }

            if (_elementType.HasRangeLimits)
                HasRangeLimits = true;

            if (_elementType.HasDefaultValue)
                HasDefaultValue = true;

            HasNestedFields = true;
            NumNestedFields = _arraySize;
            PackType = DcPackType.Array;

            if (_elementType is DcSimpleParameter simpleType)
                if (simpleType.Type == DcSubatomicType.Char)
                    PackType = DcPackType.String;
        }

        public override DcParameter AppendArraySpecification(DcUIntRange size)
        {
            // If we are a typedef wrap directly
            if (Typedef != null)
                return new DcArrayParameter(this, size);

            _elementType = _elementType.AppendArraySpecification(size);
            return this;
        }

        public override DcPackerInterface GetNestedField(int n)
        {
            return _elementType;
        }

        public override string ToString()
        {
            // TODO: Output ranges
            return $"{_elementType}[]";
        }
    }
}