using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Hello_name
{
    //Write a method that asks the user for his name and prints “Hello, <name>” 
    //(for example, “Hello, Peter!”). Write a program to test this method.
    class Program
    {
        static void Main(string[] args)
        {
            PrintName(InputName());
        }

        static string InputName()
        {
            Console.Write("what's your name: ");
            return Console.ReadLine();
        }

        static void PrintName(string name)
        {
            Console.WriteLine("Hi, {0}!", name);
        }
    }
}
