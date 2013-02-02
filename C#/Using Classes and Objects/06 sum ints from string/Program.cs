using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06_sum_ints_from_string
{
    //You are given a sequence of positive integer values written into a string, separated by spaces.
    //Write a function that reads these values from given string and calculates their sum. Example:
	//	string = "43 68 9 23 318"  result = 461
    class Program
    {
        static void Main(string[] args)
        {
            string str = "43 68 9 23 318";
            string[] input = str.Split(' ');
            //int[] arr = new int[input.Length];
            int sum = 0;
            for (int i = 0; i < input.Length; i++)
            {
                //arr[i] = int.Parse(input[i]);
                sum += int.Parse(input[i]);
            }

            Console.WriteLine(sum);
            
        }
    }
}
