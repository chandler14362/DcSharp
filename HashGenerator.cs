using System;

namespace DcSharp
{
    public class HashGenerator
    {
        private long _hash;
        private int _index;
        private PrimeNumberGenerator _primes;

        public void Add(int num)
        {
            throw new NotImplementedException();
        }

        public void Add(string str)
        {
            throw new NotImplementedException();
        }

        public void Add(Span<byte> bytes)
        {
            throw new NotImplementedException();
        }

        public ulong Hash => throw new NotImplementedException();
    }
}
