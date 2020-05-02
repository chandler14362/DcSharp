namespace DcSharp
{
    public class DcTypedef : DcDeclaration
    {
        public int Number { get; internal set; }
        
        public bool IsBogus { get; private set; }
        
        public bool IsImplicit { get; private set; }
        
        public string Name => Parameter.Name;
        
        public DcParameter Parameter { get; private set; }

        public DcTypedef(DcParameter parameter, bool isImplicit = false)
        {
            Parameter = parameter;
            IsImplicit = isImplicit;
        }
    }
}