using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _14_Min__max__avr__sum_and_product_of_set_of_int
{
    class Program
    {
        //Write methods to calculate minimum, maximum, average, sum and
        //product of given set of integer numbers. Use variable number of arguments.
        static void Main(string[] args)
        {
            Console.WriteLine(MinElement(1,2,3));
            Console.WriteLine(MinElement(1,2,3,-1));
            Console.WriteLine(MaxElement(1,2,3));
            Console.WriteLine(AverageElement(1,2,3, -1));
            Console.WriteLine(ProductElement(1,2,3,4,5));
           


        }

        static int MinElement(params int[] arr)
        {
            int min = int.MaxValue;
            for (int i = 0; i < arr.Length; i++)
            {
                if (min > arr[i])
                {
                    min = arr[i];
                }
            }
            return min;
        }

        static int MaxElement(params int[] arr)
        {
            int max = int.MinValue;
            for (int i = 0; i < arr.Length; i++)
            {
                if (max < arr[i])
                {
                    max = arr[i];
                }
            }
            return max;
        }

        static int AverageElement(params int[] arr)
        {
            int avr = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                avr += arr[i];
            }
            return avr / arr.Length;
        }

        static int SumElement(params int[] arr)
        {
            int sum = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                sum += arr[i];
            }
            return sum;
        }

        static int ProductElement(params int[] arr)
        {
            int product = 1;
            for (int i = 0; i < arr.Length; i++)
            {
                product *= arr[i];
            }
            return product;
        }


    }
}
