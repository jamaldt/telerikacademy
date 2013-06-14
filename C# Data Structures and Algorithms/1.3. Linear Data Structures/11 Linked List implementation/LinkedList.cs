using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11_Linked_List_implementation
{
    public class LinkedList<T> : IEnumerable<T>
    {
        private ListItem<T> firstElement;
        private ListItem<T> lastElement;

        public int Count { get; private set; }

        public LinkedList() 
        {
            this.Count = 0;
        }

        public void Add(T value)
        {
            ListItem<T> item = new ListItem<T>(value);
            if (this.Count == 0)
            {
                this.firstElement = item;
            }
            else
            {
                this.lastElement.NextItem = item;
            }
            
            this.lastElement = item;
            this.Count++;
        }

        public void Clear()
        {
            this.Count = 0;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new Enumerator<T>(this.firstElement);
        }

        private class Enumerator<T> : IEnumerator<T>
        {
            private ListItem<T> current;
            private T value;

            public Enumerator(ListItem<T> listItem)
            {
                this.current = listItem;
            }

            public T Current
            {
                get
                {
                    return this.value;
                }
            }

            public void Dispose()
            {
            }

            object System.Collections.IEnumerator.Current
            {
                get { return this.Current; }
            }

            public bool MoveNext()
            {
                if (this.current != null)
                {
                    this.value = this.current.Value;
                    this.current = this.current.NextItem;
                    return true;
                }
                else
                {
                    return false;
                }
            }

            public void Reset()
            {
                throw new NotImplementedException();
            }
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }

}
