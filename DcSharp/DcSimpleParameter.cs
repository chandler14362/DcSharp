using System.Collections.Generic;

namespace DcSharp
{
    public class DcSimpleParameter : DcParameter
    {
        private static DcPackerInterface? _uint32uint8type;
        
        public static DcPackerInterface UInt32UInt8Type
        {
            get
            {
                if (_uint32uint8type == null)
                {
                    var dclass = new DcClass(null, "", true, false);
                    dclass.AddField(new DcSimpleParameter(DcSubatomicType.UInt32));
                    dclass.AddField(new DcSimpleParameter(DcSubatomicType.UInt8));
                    dclass.RebuildInheritedFields();
                    _uint32uint8type = new DcClassParameter(dclass);
                }

                return _uint32uint8type;
            }
        }
        
        private static Dictionary<DcSubatomicType, Dictionary<uint, DcSimpleParameter>> _nestedFieldMap 
            = new Dictionary<DcSubatomicType, Dictionary<uint, DcSimpleParameter>>();

        public DcSubatomicType Type { get; private set; }
        
        public uint Divisor { get; private set; }
        
        public DcSubatomicType NestedType { get; private set; }

        public DcPackerInterface? NestedField { get; private set; }

        public int BytesPerElement { get; private set; }
        
        public bool HasModulus { get; private set; }
        
        public DcSimpleParameter(DcSimpleParameter other) : base(other)
        {
            Type = other.Type;
            Divisor = other.Divisor;
        }
        
        public DcSimpleParameter(DcSubatomicType type, uint divisor = 1)
        {
            Type = type;
            Divisor = divisor;
            HasModulus = false;
            HasFixedByteSize = false;
            PackType = DcPackType.Invalid;
            NestedType = DcSubatomicType.Invalid;
            HasNestedFields = false;
            BytesPerElement = 0;
            NumLengthBytes = 2;

            switch (Type)
            {
                case DcSubatomicType.Int8Array:
                    PackType = DcPackType.Array;
                    NestedType = DcSubatomicType.Int8;
                    HasNestedFields = true;
                    BytesPerElement = 1;
                    break;
                case DcSubatomicType.Int16Array:
                    PackType = DcPackType.Array;
                    NestedType = DcSubatomicType.Int16;
                    HasNestedFields = true;
                    BytesPerElement = 2;
                    break;
                case DcSubatomicType.Int32Array:
                    PackType = DcPackType.Array;
                    NestedType = DcSubatomicType.Int32;
                    HasNestedFields = true;
                    BytesPerElement = 4;
                    break;
                case DcSubatomicType.UInt8Array:
                    PackType = DcPackType.Array;
                    NestedType = DcSubatomicType.UInt8;
                    HasNestedFields = true;
                    BytesPerElement = 1;
                    break;
                case DcSubatomicType.UInt16Array:
                    PackType = DcPackType.Array;
                    NestedType = DcSubatomicType.UInt16;
                    HasNestedFields = true;
                    BytesPerElement = 2;
                    break;
                case DcSubatomicType.UInt32Array:
                    PackType = DcPackType.Array;
                    NestedType = DcSubatomicType.UInt32;
                    HasNestedFields = true;
                    BytesPerElement = 4;
                    break;
                case DcSubatomicType.UInt32UInt8Array:
                    PackType = DcPackType.Array;
                    HasNestedFields = true;
                    BytesPerElement = 5;
                    break;
                case DcSubatomicType.Blob32:
                    NumLengthBytes = 4;
                    PackType = DcPackType.Blob;
                    NestedType = DcSubatomicType.UInt8;
                    HasNestedFields = true;
                    BytesPerElement = 1;
                    break;
                case DcSubatomicType.Blob:
                    PackType = DcPackType.Blob;
                    NestedType = DcSubatomicType.UInt8;
                    HasNestedFields = true;
                    BytesPerElement = 1;
                    break;
                case DcSubatomicType.String:
                    PackType = DcPackType.String;
                    NestedType = DcSubatomicType.Char;
                    HasNestedFields = true;
                    BytesPerElement = 1;
                    break;
                case DcSubatomicType.Char:
                    PackType = DcPackType.String;
                    HasFixedByteSize = true;
                    BytesPerElement = 1;
                    break;
                case DcSubatomicType.Int8:
                    PackType = DcPackType.Int;
                    HasFixedByteSize = true;
                    FixedByteSize = 1;
                    break;
                case DcSubatomicType.Int16:
                    PackType = DcPackType.Int;
                    HasFixedByteSize = true;
                    FixedByteSize = 2;
                    break;
                case DcSubatomicType.Int32:
                    PackType = DcPackType.Int;
                    HasFixedByteSize = true;
                    FixedByteSize = 4;
                    break;
                case DcSubatomicType.Int64:
                    PackType = DcPackType.Int64;
                    HasFixedByteSize = true;
                    FixedByteSize = 8;
                    break;
                case DcSubatomicType.UInt8:
                    PackType = DcPackType.UInt;
                    HasFixedByteSize = true;
                    FixedByteSize = 1;
                    break;
                case DcSubatomicType.UInt16:
                    PackType = DcPackType.UInt;
                    HasFixedByteSize = true;
                    FixedByteSize = 2;
                    break;
                case DcSubatomicType.UInt32:
                    PackType = DcPackType.UInt;
                    HasFixedByteSize = true;
                    FixedByteSize = 4;
                    break;
                case DcSubatomicType.UInt64:
                    PackType = DcPackType.UInt64;
                    HasFixedByteSize = true;
                    FixedByteSize = 8;
                    break;
                case DcSubatomicType.Float64:
                    PackType = DcPackType.Double;
                    HasFixedByteSize = true;
                    FixedByteSize = 8;
                    break;
            }

            HasFixedStructure = HasFixedByteSize;

            SetDivisor(divisor);

            if (NestedType != DcSubatomicType.Invalid)
                NestedField = CreateNestedField(NestedType, divisor);
            else if (Type == DcSubatomicType.UInt32UInt8Array)
                NestedField = UInt32UInt8Type;
            else
                NestedField = null;
        }
        
        // TODO
        public bool SetDivisor(uint divisor)
        {
            if (PackType == DcPackType.String || PackType == DcPackType.Blob || Divisor == 0)
            {
                return false;
            }

            Divisor = divisor;
            if (Divisor != 1 && (PackType == DcPackType.Int || PackType == DcPackType.Int64 ||
                                  PackType == DcPackType.UInt || PackType == DcPackType.UInt64))
            {
                PackType = DcPackType.Double;
            }

            //
            if (HasRangeLimits)
            {

            }

            return true;
        }

        // TODO
        public bool SetRange(DcDoubleRange range)
        {
            return false;
        }

        // TODO
        public bool SetModulus(double modulus)
        {
            if (PackType == DcPackType.String || PackType == DcPackType.Blob || modulus <= 0.0)
            {
                return false;
            }

            return true;
        }

        private static DcSimpleParameter CreateNestedField(DcSubatomicType type, uint divisor)
        {
            if (!_nestedFieldMap.TryGetValue(type, out var divisorMap))
                _nestedFieldMap[type] = divisorMap = new Dictionary<uint, DcSimpleParameter>();

            if (divisorMap.TryGetValue(divisor, out var field))
                return field;
            
            field = new DcSimpleParameter(type, divisor);
            divisorMap[divisor] = field;
            return field;
        }

        public override DcPackerInterface GetNestedField(int n)
        {
            return NestedField;
        }

        public override string ToString()
        {
            var str = Type.ToString();
            
            // TODO: Include modulus and divisor
            return Type.ToString();
        }
    }
}
