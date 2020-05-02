namespace DcSharp
{
    public class DcSwitchParameter : DcPackerInterface
    {
        public DcSwitchParameter(string name) : base(name)
        {
        }

        public override DcPackerInterface GetNestedField(int n)
        {
            throw new System.NotImplementedException();
        }
    }
}