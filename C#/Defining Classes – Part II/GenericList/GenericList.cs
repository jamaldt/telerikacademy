using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericList
{
    class GenericList<T>
    {
        private T[] items;
        private int n;
        private int size;

        public GenericList(int size)
        {
            items = new T[size];
            n = 0;
            this.size = size;
        }

        public int Count
        {
            get
            {
                return n;
            }
        }

        public T this[int index]
        {
            get
            {
                ValidateIndex(index);
                return items[index];
            }
            set
            {
                ValidateIndex(index);
                items[index] = value;
            }
        }

        private void ValidateIndex(int index)
        {
            if (index < 0 || index >= n)
            {
                throw new ArgumentOutOfRangeException();
            }
        }

        public void Add(T item)
        {
            if (n == size)
            {
                size *= 2;
                Resize(size);
            }
            items[n++] = item;
        }

        private void Resize(int size)
        {
            T[] temp = new T[size];
            for (int i = 0; i < n; i++)
            {
                temp[i] = items[i];
            }
            items = temp;
        }

        public void RemoveAt(int index)
        {
            ValidateIndex(index);
            n--;
            for (int i = index; i < n; i++)
            {
                items[i] = items[i + 1];
            }
        }

        public void Clear()
        {
            items = new T[size];
        }

        public int Find(T item)
        {
            for (int i = 0; i < n; i++)
            {
                if (items[i].Equals(item))
                    return i;
            }
            return -1;
        }

        public override string ToString()
        {
            StringBuilder s = new StringBuilder(n);
            for (int i = 0; i < n; i++)
            {
                String str = items[i].ToString();
                s.Append(str);
                s.Append(" ");
            }
            return s.ToString();
        }

        public T Min<K>() where K : IComparable<K>
        {
            T min = items.Min();
            return min;
        }
    }
}
