using System.Collections.Generic;

namespace DcSharp
{
    public class DcDoubleRange
    {
        public class Range
        {
            public double Min { get; set; }
        
            public double Max { get; set; }
        }

        public List<Range> Ranges = new List<Range>();

        public void Add(double min, double max)
        {
            Ranges.Add(new Range { Min = min, Max = max });
        }
    }
    
    public class DcUIntRange
    {
        public class Range
        {
            public uint Min { get; set; }
        
            public uint Max { get; set; }
        }

        public List<Range> Ranges = new List<Range>();

        public bool HasOneValue()
        {
            return Ranges.Count == 1 && Ranges[0].Min == Ranges[0].Max;
        }

        public uint GetOneValue()
        {
            return Ranges[0].Min;
        }
        
        public void Add(uint min, uint max)
        {
            Ranges.Add(new Range { Min = min, Max = max });
        }
    }
}