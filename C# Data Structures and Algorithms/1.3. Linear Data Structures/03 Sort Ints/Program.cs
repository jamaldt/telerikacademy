using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_Sort_Ints
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> sequence = new List<int>();
            String input = Console.ReadLine();

            while (!input.Equals(String.Empty))
            {
                try
                {
                    int number = int.Parse(input);
                    sequence.Add(number);
                }
                catch (ArgumentNullException)
                {
                    Console.WriteLine("Null argument! Please enter INT number or ENTER to end.");
                }
                catch (FormatException)
                {
                    Console.WriteLine("Format exception! Please enter INT number or ENTER to end.");
                }
                catch (OverflowException)
                {
                    Console.WriteLine("Number is to big! Please enter INT number or ENTER to end.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error, program terminated. " + ex.Message);
                    return;
                }

                input = Console.ReadLine();
            }

            if (sequence.Count > 0)
            {
                sequence.Sort();
                foreach (var item in sequence)
                {
                    Console.WriteLine(item);
                }
            }
            else
            {
                Console.WriteLine("There are no elements in sequence");
            }
        }
    }
}
