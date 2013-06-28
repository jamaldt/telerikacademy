using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_5_Handshake_Problem
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int a = n / 2;

            int result = (int) Math.Pow(2, a) - a;

            if (a % 2 > 0)
                result--;

            Console.WriteLine(result);
        }

       
            
    }

}
