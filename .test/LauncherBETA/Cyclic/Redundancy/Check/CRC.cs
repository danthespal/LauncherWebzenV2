using System;
using System.Collections.Generic;
using System.Security.Cryptography;

namespace Cyclic.Redundancy.Check
{
    public sealed class CRC : HashAlgorithm
    {
        public const uint DefaultPolynominal = 79764919;
        public const uint DefaultSeed = 4294967295;
        private static uint[] defaultTable;
        private readonly uint seed;
        private readonly uint[] table;
        private uint hash;

        public CRC() : this(79764919U, uint.MaxValue)
        {
        }

        public CRC(uint polynomial, uint seed)
        {
            this.table = CRC.InitializeTable(polynomial);
            this.seed = this.hash = seed;
        }

        public override void Initialize() => this.hash = this.seed;

        protected override void HashCore(byte[] buffer, int start, int length) => this.hash = CRC.CalculateHash(this.table, this.hash, (IList<byte>) buffer, start, length);

        protected override byte[] HashFinal()
        {
            byte[] numArray = CRC.UInt32ToBigEndianBytes(~this.hash);
            this.HashValue = numArray;
            return numArray;
        }

        public override int HashSize => 32;

        public static uint Compute(byte[] buffer) => CRC.Compute(uint.MaxValue, buffer);

        public static uint Compute(uint seed, byte[] buffer) => CRC.Compute(79764919U, seed, buffer);

        public static uint Compute(uint polynomial, uint seed, byte[] buffer) => ~CRC.CalculateHash(CRC.InitializeTable(polynomial), seed, (IList<byte>) buffer, 0, buffer.Length);

        private static uint[] InitializeTable(uint polynomial)
        {
            if (polynomial == 79764919U && CRC.defaultTable != null)
                return CRC.defaultTable;
            uint[] numArray = new uint[256];
            for (int index1 = 0; index1 < 256; ++index1)
            {
                uint num = (uint) index1;
                for (int index2 = 0; index2 < 8; ++index2)
                {
                    if (((int) num & 1) == 1)
                        num = num >> 1 ^ polynomial;
                    else
                        num >>= 1;
                }
                numArray[index1] = num;
            }
            if (polynomial == 79764919U)
                CRC.defaultTable = numArray;
            return numArray;
        }

        private static uint CalculateHash(uint[] table, uint seed, IList<byte> buffer, int start, int size)
        {
            uint num = seed;
            for (int index = start; index < size - start; ++index)
                num = num >> 8 ^ table[(int) buffer[index] ^ (int) num & (int) byte.MaxValue];
            return num;
        }

        private static byte[] UInt32ToBigEndianBytes(uint uint32)
        {
            byte[] bytes = BitConverter.GetBytes(uint32);
            if (BitConverter.IsLittleEndian)
                Array.Reverse((Array) bytes);
            return bytes;
        }
    }
}
