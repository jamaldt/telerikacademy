
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _12_Stack_auto_resizable_array_imp
{
    class StackArray<T>
    {
                private T[] stackArray;
        private int currentItemsCount;

        public StackArray(int initialCapacity = 4)
        {
            this.stackArray = new T[initialCapacity];
            this.currentItemsCount = 0;
        }

        public void Push(T value)
        {
            if (this.currentItemsCount == this.stackArray.Length)
            {
                this.ResizeStack();
            }

            this.stackArray[currentItemsCount] = value;
            currentItemsCount++;
        }

        public T Pop()
        {
            if (this.currentItemsCount == 0)
            {
                throw new InvalidOperationException("Cannot Pop from empty stack");
            }

            this.currentItemsCount--;

            T item = this.stackArray[this.currentItemsCount];
            this.stackArray[this.currentItemsCount] = default(T);

            return item;
        }

        public T Peek()
        {
            if (this.currentItemsCount == 0)
            {
                throw new InvalidOperationException("Cannot Pop from empty stack");
            }

            return this.stackArray[currentItemsCount - 1];
        }

        private void ResizeStack()
        {
            var newStack = new T[this.stackArray.Length * 2];

            for (int i = 0; i < this.stackArray.Length; i++)
            {
                newStack[i] = this.stackArray[i];
            }

            this.stackArray = newStack;
        }
    }
}
