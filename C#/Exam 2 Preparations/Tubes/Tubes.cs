using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tubes
{
    class Tubes
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int m = int.Parse(Console.ReadLine());
            int[] tube = new int[n];
            int tubeLength = 0;
            for (int i = 0; i < tube.Length; i++)
            {
                tube[i] = int.Parse(Console.ReadLine());
                tubeLength += tube[i];
            }


            int up = (int) Math.Ceiling((double) tubeLength / m);
            int down = 0;
            int middle;
            int tubesCount;

            while (down < up)
            {
                middle = (down + up) / 2;
                if (middle == 0)
                {
                    down = 1;
                    break;
                }
                tubesCount = CountTubes(tube, middle);
                
                if (tubesCount < m)
                {
                    up = middle;
                }
                else
                {
                    down = middle + 1;
                }
                //Console.WriteLine(tubesCount + " " + middle + " " + up + " " + down);

            }

            for (; down >= 1; down--)
            {
                int count = 0;
                foreach (var tub in tube)
                {
                    count += tub / down;
                }
                if (count >= m)
                {
                    break;
                }
            }
            Console.WriteLine(down);


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
