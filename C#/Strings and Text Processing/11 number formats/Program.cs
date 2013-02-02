using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11_number_formats
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine("{0,15}", n); 
            Console.WriteLine("{0,15:X}", n); 
            Console.WriteLine("{0,15:P}", n); 
            Console.WriteLine("{0,15:E}", n);
        }
    }
}
