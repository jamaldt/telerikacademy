using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07_Reverse_digits_of_decimal_number
{
    //Write a method that reverses the digits of given decimal number. 
    //Example: 256  652
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine(ReversDigits(n));
        }

        static int ReversDigits(int n)
        {
            int reversed = n;
            int count = 0;
            while (reversed > 0)
            {
                reversed /= 10;
                count++;
            }
            if (count > 0)
            {
                for (int i = count-1; i > 0; i--)
                {
                    reversed += (int)Math.Pow(10, i) * (n % 10);
                    n /= 10;                    
                }
                reversed += n % 10;
            }
            return reversed;
        }
    }
}
