using System;

namespace DcSharp
{
    public class DcPackData
    {
        private Memory<byte> _buffer;
        
        public int Length { get; private set; }

        public DcPackData(int size)
        {
            _buffer = new byte[size];
        }
        
        public void AppendData(Span<byte> data)
        {
            SetUsedLength(Length + data.Length);
            var buf = _buffer.Slice(Length - data.Length);
            data.CopyTo(buf.Span);
        }

        public Span<byte> GetWriteSpan(int size)
        {
            SetUsedLength(Length + size);
            return _buffer.Slice(Length - size, size).Span;
        }

        public void AppendJunk(int size)
        {
            SetUsedLength(Length + size);
        }

        public void RewriteData(int position, Span<byte> data)
        {
            var buf = _buffer.Slice(position);
            data.CopyTo(buf.Span);
        }

        public Span<byte> GetRewriteSpan(int position, int size)
        {
            var buf = _buffer.Slice(position, size);
            return buf.Span;
        }

        private void SetUsedLength(int size)
        {
            if (size > _buffer.Length)
            {
                var buf = new byte[(size * 2) + 50];
                _buffer.CopyTo(buf);
                _buffer = buf;
            }

            Length = size;
        }

        public Memory<byte> TakeData()
        {
            var data = _buffer.Slice(0, Length);
            _buffer = Memory<byte>.Empty;
            Length = 0;
            return data;
        }
        
        public void Clear()
        {
        }
    }
}