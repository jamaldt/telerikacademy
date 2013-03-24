using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05_BitArray64
{
    class BitArray64 : IEnumerable<int>
    {
        private ulong _value;

        public ulong Value
        {
            get { return _value; }
            private set { _value = value; }
        }

        public BitArray64(ulong val)
        {
            this.Value = val;
        }

        public IEnumerator<int> GetEnumerator()
        {
            return new BitArray64Enum(this);
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private class BitArray64Enum : IEnumerator<int>
        {
            private BitArray64 bitArray64;
            private int curIndex;
            private int curItem;

            public BitArray64Enum(BitArray64 bitArray64)
            {
                this.bitArray64 = bitArray64;
                curIndex = -1;
                curItem = default(int);
            }
            public int Current
            {
                get { return curItem; }
            }

            public bool MoveNext()
            {
                curIndex++;
                if (curIndex >= 63)
                {
                    return false;
                }
                else
                {
                    curItem = bitArray64[curIndex];
                    return true;
                }
            }

            public void Reset()
            {
                curIndex = -1;
            }

            public void Dispose()
            {
            }

            object System.Collections.IEnumerator.Current
            {
                get { return Current; }
            }
        }

        public override bool Equals(object obj)
        {
            BitArray64 bit = obj as BitArray64;
            if (bit == null)
                return false;
            return this.Value == bit.Value;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode() ^ (int)this.Value;
        }

        public static bool operator ==(BitArray64 bit1, BitArray64 bit2)
        {
            return BitArray64.Equals(bit1, bit2);
        }

        public static bool operator !=(BitArray64 bit1, BitArray64 bit2)
        {
            return !(BitArray64.Equals(bit1, bit2));
        }

        public int this[int i]
        {
            get 
            {
                return (int)(1 & (_value >> i));
            }
        }


    }
}
