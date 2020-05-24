using System;
using System.Buffers;
using System.Buffers.Binary;
using Krypton.Buffers;

namespace DcSharp
{
    public static class DcPacker
    {

        public static ReadOnlySpan<byte> UnpackBytes(DcPackerInterface pi, ReadOnlySpan<byte> buffer)
        {
            if (pi.HasFixedByteSize && pi.HasFixedStructure)
                return buffer.Slice(0, pi.FixedByteSize);

            if (pi.PackType == DcPackType.Array || pi.PackType == DcPackType.Blob || pi.PackType == DcPackType.String)
            {
                var length =  pi.NumLengthBytes switch {
                    2 => BinaryPrimitives.ReadUInt16LittleEndian(buffer),
                    4 => BinaryPrimitives.ReadUInt32LittleEndian(buffer),
                    _ => throw new Exception()
                };
                return buffer.Slice(0, (int) (pi.NumLengthBytes + length));
            }
            
            var offset = 0;
            if (pi.HasNestedFields)
            {
                for (var i = 0; i < pi.NumNestedFields; i++)
                {
                    var f = pi.GetNestedField(i);
                    var d = UnpackBytes(f, buffer.Slice(offset));
                    offset += d.Length;
                }
            }
            return buffer.Slice(0, offset);
        }
    }
}
