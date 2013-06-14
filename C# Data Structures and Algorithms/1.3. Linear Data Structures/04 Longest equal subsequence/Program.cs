using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_Longest_equal_subsequence
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> sequence = ReadInput();
            List<int> subsequence = FindLongestEqualSubsequence(sequence);

            if (subsequence.Count > 0)
            {
                foreach (var item in subsequence)
                {
                    Console.Write(item + " ");
                }
            }
            else
            {
                Console.WriteLine("There are no elements in sequence");
            }
        }

        private static List<int> FindLongestEqualSubsequence(List<int> sequence)
        {
            if (sequence.Count > 0)
            {
                int subSeqLength = 0;
                int subSeqNum = sequence[0];
                int curSubSeqLength = 0;
                int curSubSeqNum = sequence[0];

                foreach (var item in sequence)
                {
                    if (item != curSubSeqNum)
                    {
                        if (subSeqLength < curSubSeqLength)
                        {
                            subSeqNum = curSubSeqNum;
                            subSeqLength = curSubSeqLength;
                        }
                        curSubSeqNum = item;
                        curSubSeqLength = 0;
                    }

                    curSubSeqLength++;
                }

                if (subSeqLength < curSubSeqLength)
                {
                    subSeqNum = curSubSeqNum;
                    subSeqLength = curSubSeqLength;
                }

                List<int> output = new List<int>(subSeqLength);
                for (int i = 0; i < subSeqLength; i++)
                {
                    output.Add(subSeqNum);
                }

                return output;
            }
            else
            {
                return new List<int>();
            }
        }

        private static List<int> ReadInput()
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
                    Console.WriteLine("Uresolved error: " + ex.Message);
                }

                input = Console.ReadLine();
            }
            return sequence;
        }
    }
}
