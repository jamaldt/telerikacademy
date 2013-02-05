using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tubes
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int m = int.Parse(Console.ReadLine());
            int[] tube = new int[n];
            for (int i = 0; i < tube.Length; i++)
            {
                tube[i] = int.Parse(Console.ReadLine());
            }

            int tubeLength = int.MaxValue;

            int tubesCount = CountTubes(tube, tubeLength); 

            while (tubesCount != m)
            {
                if (tubesCount > m)
                {
                    tubeLength *= 2;
                }
                else if (tubesCount < m)
                {
                    tubeLength /= 2;
                }
                else
                {
                    tubeLength--;
                }
                tubesCount = CountTubes(tube, tubeLength);
                Console.WriteLine(tubesCount +" "+tubeLength);

            }
            //Console.WriteLine(tubesCount);
            Console.WriteLine(--tubeLength);


        }

        private static int CountTubes(int[] tube, int length)
        {
            int tubesCount = 0;
            for (int i = 0; i < tube.Length; i++)
            {
                tubesCount += tube[i] / length;
            }
            return tubesCount;
        }
    }
}
