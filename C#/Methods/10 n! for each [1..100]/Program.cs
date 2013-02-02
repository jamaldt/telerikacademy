using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _10_n__for_each__1._100_;

namespace _10_n__for_each__1._._100_
{
    //Write a program to calculate n! for each n in the range [1..100].
    //Hint: Implement first a method that multiplies a number represented
    //as array of digits by given integer number. 
    class Program
    {
        static void Main(string[] args)
        {
           
            BigInt factoriel = new BigInt(1);
            for (int i = 1; i <= 100; i++)
            {
                factoriel.Multiply(i);
                Console.WriteLine(factoriel);
            }
             
            
            /*
            BigInt factoriel = new BigInt(int.MaxValue);
            factoriel.Multiply(new BigInt(10));

            Console.WriteLine(factoriel);
            */
        }
    }
}
