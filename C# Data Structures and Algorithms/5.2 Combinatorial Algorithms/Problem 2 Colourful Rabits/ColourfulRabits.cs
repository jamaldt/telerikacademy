using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_2_Colourful_Rabits
{
    class ColourfulRabits
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<int, Bunny> dict = new Dictionary<int, Bunny>();

            for (int i = 0; i < n; i++)
            {
                int num = int.Parse(Console.ReadLine());
                num++;

                if (dict.ContainsKey(num))
                {
                    dict[num].repeated++;
                }
                else
                {
                    Bunny b = new Bunny(num, 1);
                    dict.Add(num, b);
                }
            }

            int count = 0;

            foreach (var b in dict.Values)
            {
                if (b.bunniesCount >= b.repeated)
                {
                    count += b.bunniesCount;
                }
                else
                {
                    int groups = (int) Math.Ceiling((double) b.repeated / b.bunniesCount);
                    count += groups * b.bunniesCount;
                }
            }

            Console.WriteLine(count);

        }
    }

    class Bunny
    {
        public int bunniesCount;
        public int repeated;

        public Bunny(int num, int p)
        {
            this.bunniesCount = num;
            this.repeated = p;
        }
    }

}
