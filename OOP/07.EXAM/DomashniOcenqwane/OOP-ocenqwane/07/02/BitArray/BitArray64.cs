using System;
using System.Collections;
using System.Collections.Generic;

namespace BitArray64
{
    class BitArray64 : IEnumerable<int>
    {
        private ulong number;

        public ulong Number
        {
            get
            {
                return this.number;
            }
            private set
            {
                this.number = value;
            }
        }

        public BitArray64(ulong number)
        {
            this.Number = number;
        }

        private int[] ConvertToBitsArray()
        {
            int[] bits = new int[64];
            for (int i = 0; i < bits.Length; i++)
            {
                bits[63 - i] = (int)((number >> i) & 1);
            }
            return bits;
        }

        public override bool Equals(object obj)
        {
            if (!(obj is BitArray64))
            {
                return false;
            }
            BitArray64 other = obj as BitArray64;

            return this.Number == other.Number;
        }

        public override int GetHashCode()
        {
            return number.GetHashCode();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public IEnumerator<int> GetEnumerator()
        {
            int[] bits = ConvertToBitsArray();

            for (int i = 0; i < bits.Length; i++)
            {
                yield return bits[i];
            }
        }

        public int this[int index]
        {
            get
            {
                if (index < 0 || index > 63)
                {
                    throw new System.IndexOutOfRangeException();
                }

                int[] bits = this.ConvertToBitsArray();
                return bits[index];
            }
        }

        public static bool operator ==(BitArray64 a, BitArray64 b)
        {
            return a.Equals(b);
        }

        public static bool operator !=(BitArray64 a, BitArray64 b)
        {
            return !(a == b);
        }
    }
}