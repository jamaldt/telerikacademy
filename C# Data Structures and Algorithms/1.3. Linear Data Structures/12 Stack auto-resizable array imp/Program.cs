using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _12_Stack_auto_resizable_array_imp
{
    class Program
    {
        static void Main(string[] args)
        {
            //default size is 4, we can set bigger from the constructor;
            StackArray<string> stack = new StackArray<string>();
            //testing resizability
            stack.Push("Ivan");
            stack.Push("Ivan2");
            stack.Push("Ivan3");
            stack.Push("Gosho");
            stack.Push("Tosho");

            Console.WriteLine("Current top element is {0}", stack.Peek());
            string removed = stack.Pop();
            Console.WriteLine("Removed element is {0}", removed);
            Console.WriteLine("Current top element is {0}", stack.Peek());
        }
    }
}
