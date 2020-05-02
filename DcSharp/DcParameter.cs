using System;

namespace DcSharp
{
    public abstract class DcParameter : DcField
    {
        public DcTypedef? Typedef { get; set; }
        
        public DcParameter() : base("", null)
        {
        }
        
        public DcParameter(DcParameter other) : base(other.Name, other.Class)
        {}

        public virtual DcParameter AppendArraySpecification(DcUIntRange size)
        {
            return new DcArrayParameter(this, size);
        }
    }
}
