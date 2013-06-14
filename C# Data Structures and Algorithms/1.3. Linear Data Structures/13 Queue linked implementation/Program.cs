using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _13_Queue_linked_implementation
{
    class Program
    {
        static void Main(string[] args)
        {
            QueueLinked<string> queue = new QueueLinked<string>();
            //test autoGrow
            queue.Enqueue("string1");
            queue.Enqueue("string2");
            queue.Enqueue("string3");
            queue.Enqueue("string4");
            queue.Enqueue("string5");

            //test Peek - expected "string1"
            Console.WriteLine(queue.Peek());

            //test remove - expected string1;
            var removed = queue.Dequeue();
            Console.WriteLine(removed);

            //test remove - expected peek - "string2"
            Console.WriteLine(queue.Peek());

            //remove 4 more and check the last one - "string5"
            queue.Dequeue();
            queue.Dequeue();
            queue.Dequeue();
            Console.WriteLine(queue.Dequeue());
        }
    }
}
