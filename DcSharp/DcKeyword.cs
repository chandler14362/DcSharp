namespace DcSharp
{
    /// <summary>
    /// Represents a single keyword declaration in the dc file. It is used to define a communication property associated
    /// with a field, for instance "broadcast" or "airecv"
    /// </summary>
    public class DcKeyword : DcDeclaration
    {
        public string Name { get; set; }
        
        public int HistoricalFlag { get; private set; }

        public DcKeyword(string name, int historicalFlag = ~0)
        {
            Name = name;
            HistoricalFlag = historicalFlag;
        }

        public override string ToString()
        {
            return $"keyword {Name}";
        }
    }
}
