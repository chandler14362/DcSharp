using System;
using System.Buffers.Binary;

namespace DcSharp
{
    public enum DcPackType
    {
        Invalid,
        Double,
        Int,
        UInt,
        Int64,
        UInt64,
        String,
        Blob,
        
        Array,
        Field,
        Class,
        Switch
    }

    public abstract class DcPackerInterface
    {
        public string Name { get; internal set; }
        public int FixedByteSize { get; protected set; }
        public bool HasFixedByteSize { get; protected set; }
        public bool HasFixedStructure { get; protected set; }
        public bool HasRangeLimits { get; protected set; }
        public int NumLengthBytes { get; protected set; }
        public bool HasNestedFields { get; protected set; }
        public int NumNestedFields { get; protected set; }

        public DcPackType PackType;

        public DcPackerInterface(string name)
        {
            Name = name;

            HasFixedByteSize = true;
            FixedByteSize = 0;
            HasFixedStructure = false;
            HasRangeLimits = false;
            NumLengthBytes = 0;
            HasNestedFields = false;
            NumNestedFields = -1;
            PackType = DcPackType.Invalid;
        }

        public abstract DcPackerInterface GetNestedField(int n);
    }
}