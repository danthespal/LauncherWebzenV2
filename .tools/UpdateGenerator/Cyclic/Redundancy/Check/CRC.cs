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
            table = InitializeTable(polynomial);
            hash = seed;
            this.seed = seed;
        }

        public override void Initialize()
        {
            hash = seed;
        }

        protected override void HashCore(byte[] buffer, int start, int length)
        {
            hash = CalculateHash(table, hash, buffer, start, length);
        }

        protected override byte[] HashFinal()
        {
            byte[] numArray = UInt32ToBigEndianBytes(~hash);
            HashValue = numArray;
            return numArray;
        }

        public override int HashSize => 32;

        public static uint Compute(byte[] buffer)
        {
            return Compute(uint.MaxValue, buffer);
        }

        public static uint Compute(uint seed, byte[] buffer)
        {
            return Compute(79764919U, seed, buffer);
        }

        public static uint Compute(uint polynomial, uint seed, byte[] buffer)
        {
            return ~CalculateHash(InitializeTable(polynomial), seed, buffer, 0, buffer.Length);
        }

        private static uint[] InitializeTable(uint polynomial)
        {
            if (polynomial == 79764919U && defaultTable != null)
            {
                return defaultTable;
            }

            uint[] numArray = new uint[256];
            for (int index1 = 0; index1 < 256; ++index1)
            {
                uint num = (uint)index1;
                for (int index2 = 0; index2 < 8; ++index2)
                {
                    if (((int)num & 1) == 1)
                    {
                        num = (num >> 1) ^ polynomial;
                    }
                    else
                    {
                        num >>= 1;
                    }
                }
                numArray[index1] = num;
            }

            if (polynomial == 79764919U)
            {
                defaultTable = numArray;
            }
            return numArray;
        }

        private static uint CalculateHash(uint[] table, uint seed, IList<byte> buffer, int start, int size)
        {
            uint num = seed;
            for (int index = start; index < size - start; ++index)
            {
                num = (num >> 8) ^ table[buffer[index] ^ ((int)num & byte.MaxValue)];
            }

            return num;
        }

        private static byte[] UInt32ToBigEndianBytes(uint uinCRC2)
        {
            byte[] bytes = BitConverter.GetBytes(uinCRC2);
            if (BitConverter.IsLittleEndian)
            {
                Array.Reverse(bytes);
            }
            return bytes;
        }
    }
}
