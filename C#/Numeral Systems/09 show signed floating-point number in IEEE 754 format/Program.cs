using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09_show_signed_floating_point_number_in_IEEE_754_format
{
    //Write a program that shows the internal binary representation of given 32-bit 
    //signed floating-point number in IEEE 754 format (the C# type float). 
    //Example: -27,25  sign = 1, exponent = 10000011, mantissa = 10110100000000000000000.

    /*
     * 
     * 
     * ЗА ДА ПУСНЕТЕ ЗАДАЧАТА ТРЯБВА ДА ВКЛЮЧИТЕ КОМПАЙЛ UNSAFE!!!!!!!!!! 
     * 
     * 
     * 
     */



    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("enter floating point number: ");
            float f = float.Parse(Console.ReadLine());
            uint num = 0;

            unsafe
            {
                //uint* pNum = &num;
                //float* pF = &f;
                //pNum = (uint*) pF;
                //num = *pNum;
                num = *(uint*)&f;
            }

            Console.WriteLine("sign = {0}", num >> 31 & 1);
            Console.Write("exponent = ");
            for (int i = 30; i > 22; i--)
            {
                Console.Write(num >> i & 1);                               
            }
            Console.WriteLine();
            Console.Write("mantisa = ");
            for (int i = 22; i >= 0; i--)
            {
                Console.Write(num >> i & 1);
            }
            Console.WriteLine();

        }
    }
}
