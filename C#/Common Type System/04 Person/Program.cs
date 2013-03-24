using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_Person
{
    class Program
    {
        static void Main(string[] args)
        {
            Person unaged = new Person("Pesho");
            Person aged = new Person("Gosho", 34);
            Console.WriteLine(unaged);
            Console.WriteLine(aged);
        }
    }
}
