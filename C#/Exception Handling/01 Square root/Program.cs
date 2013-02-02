using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Square_root
{
    //Write a program that reads an integer number and calculates and prints its square root.
    //If the number is invalid or negative, print "Invalid number".
    //In all cases finally print "Good bye". Use try-catch-finally.
    class Program
    {   
        
        static void Main()
        {
            try
            {
                Sqrt(int.Parse(Console.ReadLine()));
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.Error.WriteLine("Error: " + ex.Message);
            }
            catch (FormatException e)
            {
                Console.WriteLine("Error: " + e.Message);
            }
            finally
            {
                Console.WriteLine("Good bye");
            }
        }

        public static double Sqrt(double value)
        {
            if (value < 0)
                throw new System.ArgumentOutOfRangeException("Sqrt for negative numbers is undefined!");
            return Math.Sqrt(value);
        }
    }
}
