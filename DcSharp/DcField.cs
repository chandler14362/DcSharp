using System;

namespace DcSharp
{
    public abstract class DcField : DcPackerInterface
    {
        public DcKeywordList KeywordList { get; protected set; }

        public int Number { get; set; }

        public DcClass? Class { get; internal set; }

        public bool HasDefaultValue { get; set; }

        public bool DefaultValueStale { get; set; }

        public bool Bogus { get; set; }

        public bool IsRequired => (1 & KeywordList.Flags) != 0;

        public bool IsBroadcast => (1 << 1 & KeywordList.Flags) != 0;

        public bool IsOwnrecv => (1 << 2 & KeywordList.Flags) != 0;

        public bool IsRam => (1 << 3 & KeywordList.Flags) != 0;

        public bool IsDb => (1 << 4 & KeywordList.Flags) != 0;

        public bool IsClsend => (1 << 5 & KeywordList.Flags) != 0;
        public bool IsClrecv => (1 << 6 & KeywordList.Flags) != 0;

        public bool IsOwnsend => (1 << 7 & KeywordList.Flags) != 0;

        public bool IsAirecv => (1 << 8 & KeywordList.Flags) != 0;

        public ReadOnlyMemory<byte> DefaultValue { get; internal set; }

        public DcField() : base("")
        {
            KeywordList = new DcKeywordList();
            
            Number = -1;
            HasDefaultValue = false;
            DefaultValueStale = true;
            
            Bogus = false;
            
            HasNestedFields = true;
            NumNestedFields = 0;
            PackType = DcPackType.Field;
            
            HasFixedByteSize = true;
            FixedByteSize = 0;
            HasFixedStructure = true;
        }
        
        public DcField(string name, DcClass dclass) : base(name)
        {
            KeywordList = new DcKeywordList();
            Class = dclass;
            
            Number = -1;
            HasDefaultValue = false;
            DefaultValueStale = true;
            
            Bogus = false;
            
            HasNestedFields = true;
            NumNestedFields = 0;
            PackType = DcPackType.Field;
            
            HasFixedByteSize = true;
            FixedByteSize = 0;
            HasFixedStructure = true;
        }

    }
}
