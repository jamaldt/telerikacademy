using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_Reverse_ints_using_stack
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<int> stack = new Stack<int>();
            String input = Console.ReadLine();

            while (!input.Equals(String.Empty))
            {
                try
                {
                    int number = int.Parse(input);
                    stack.Push(number);
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

            if (stack.Count > 0)
            {
                foreach (var item in stack)
                {
                    Console.WriteLine(item);
                }
            }
            else
            {
                Console.WriteLine("There are no elements in stack");
            }
        }
    }
}
