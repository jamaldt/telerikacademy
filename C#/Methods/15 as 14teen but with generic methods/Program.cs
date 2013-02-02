using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _15_as_14teen_but_with_generic_methods
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(MinElement(1, 2, 3));
            Console.WriteLine(MinElement(1.5, 2, 3, 4));
            Console.WriteLine(MaxElement(1, 2, 3.6));
            Console.WriteLine(AverageElement(1f, 2, 3, -1));
            Console.WriteLine(ProductElement(1, 2, 3, 4, 5));



        }

        static T MinElement<T>(params T[] arr) where T : System.IComparable<T>
        {
            T min = arr[0];
            for (int i = 1; i < arr.Length; i++)
            {
                if (min.CompareTo(arr[i]) > 0)
                {
                    min = arr[i];
                }
            }
            return min;
        }

        static T MaxElement<T>(params T[] arr) where T : System.IComparable<T>
        {
            T max = arr[0];
            for (int i = 1; i < arr.Length; i++)
            {
                if (max.CompareTo(arr[i]) < 0)
                {
                    max = arr[i];
                }
            }
            return max;
        }

        static dynamic AverageElement(params dynamic[] arr) 
        {
            dynamic avr = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                avr += arr[i];
            }
            return avr / arr.Length;
        }

        static dynamic SumElement(params dynamic[] arr)
        {
            dynamic sum = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                sum += arr[i];
            }
            return sum;
        }

        static dynamic ProductElement(params dynamic[] arr)
        {
            dynamic product = 1;
            for (int i = 0; i < arr.Length; i++)
            {
                product *= arr[i];
            }
            return product;
        }
    }
}
