using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _13_Queue_linked_implementation
{
    class QueueLinked<T>
    {
        private T[] queueArray;
        private int firstElementIndex;
        private int lastElementIndex;
        private bool isFirstElement;

        public QueueLinked(int currentCapacity = 4)
        {
            this.queueArray = new T[currentCapacity];
            this.isFirstElement = true;
        }

        public void Enqueue(T value)
        {
            //we make the array loop-alike so we can resize the array
            //only when we're 100% sure that the queue is full
            IncreaseLastElementPossition();

            if (this.lastElementIndex == this.firstElementIndex)
            {
                ResizeQueue();
            }

            if (isFirstElement)
            {
                this.firstElementIndex = this.lastElementIndex;
                this.isFirstElement = false;
            }

            this.queueArray[this.lastElementIndex] = value;
        }

        public T Dequeue()
        {
            var item = this.queueArray[this.firstElementIndex];

            this.IncreaseFirstElementPossition();

            return item;
        }

        public T Peek()
        {
            return this.queueArray[firstElementIndex];
        }

        private void ResizeQueue()
        {
            var newQueue = new T[this.queueArray.Length * 2];
            this.DecreaseLastElementPossition();

            //when we resize we put the first element at 0, and the other elements after it;
            for (int newPos = 0; this.firstElementIndex != this.lastElementIndex; newPos++)
            {
                newQueue[newPos] = this.queueArray[this.firstElementIndex];
                this.IncreaseFirstElementPossition();
            }
            newQueue[this.queueArray.Length - 1] = this.queueArray[this.firstElementIndex];

            this.firstElementIndex = 0;
            this.lastElementIndex = this.queueArray.Length;
            this.queueArray = newQueue;
        }

        //looping to next/previous possition methods
        private void IncreaseFirstElementPossition()
        {
            if (this.firstElementIndex == this.queueArray.Length - 1)
            {
                this.firstElementIndex = 0;
            }
            else
            {
                this.firstElementIndex++;
            }
        }

        private void IncreaseLastElementPossition()
        {
            if (this.lastElementIndex == this.queueArray.Length - 1)
            {
                this.lastElementIndex = 0;
            }
            else
            {
                this.lastElementIndex++;
            }
        }

        private void DecreaseLastElementPossition()
        {
            if (this.lastElementIndex == 0)
            {
                this.lastElementIndex = this.queueArray.Length - 1;
            }
            else
            {
                this.lastElementIndex--;
            }
        }
    }
}
