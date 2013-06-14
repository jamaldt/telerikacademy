namespace Iterator
{
    using System;

    public class Sequence<T>
    {
        private T[] items;
        private int next = 0;

        public Sequence(int size)
        {
            items = new T[size];
        }

        public void Add(T newItem)
        {
            if (next < items.Length)
            {
                items[next] = newItem;
                next += 1;
            }
        }

        private class SequenceSelector : ISelector
        {
            private int i = 0;
            Sequence<T> seq;

            public SequenceSelector(Sequence<T> seq)
            {
                this.seq = seq;
            }

            public bool End()
            {
                return i == seq.items.Length;
            }

            public Object Current()
            {
                return seq.items[i];
            }

            public void Next()
            {
                if (i < seq.items.Length)
                {
                    i++;
                }
            }
        }

        public ISelector Selector()
        {
            return new SequenceSelector(this);
        }
    }
}
