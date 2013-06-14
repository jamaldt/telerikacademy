// Write a program that reads from the console a sequence of positive integer numbers.
// The sequence ends when empty line is entered. Calculate and print the sum and average
// of the elements of the sequence. Keep the sequence in List<int>.
using System;
using System.Collections.Generic;
using System.Linq;

namespace _01_Sum_and_average_of_sequence
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
                Console.WriteLine("Sum: " + sequence.Sum());
                Console.WriteLine("Average: " + sequence.Average());
            }
            else
            {
                Console.WriteLine("There are no elements in sequence");
            }
        }
    }
}
