using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_2_3D_Labyrinth
{
    class Program
    {
        static void main(string[] args)
        {
            string[] input = Console.ReadLine().Split(' ');
            int posLevel = int.Parse(input[0]);
            int posRow = int.Parse(input[1]);
            int posCol = int.Parse(input[2]);

            input = Console.ReadLine().Split(' ');
            int levelsCount = int.Parse(input[0]);
            int rowsCount = int.Parse(input[1]);
            int colsCount = int.Parse(input[2]);

            char[, ,] house = new char[levelsCount, rowsCount, colsCount];

            for (int level = 0; level < levelsCount; level++)
            {
                for (int row = 0; row < rowsCount; row++)
                {
                    string inputRow = Console.ReadLine();
                    for (int col = 0; col < colsCount; col++)
                    {
                        house[level, row, col] = inputRow[col];
                    }
                }
            }

            int startPosition;
            List<int> posibleExits = new List<int>();
            int vertexIndex = 0;

            for (int level = 0; level < levelsCount; level++)
            {
                for (int row = 0; row < rowsCount; row++)
                {
                    for (int col = 0; col < colsCount; col++)
                    {
                        
                        vertexIndex++;
                    }
                }
            }

            Console.WriteLine();
            //Graph G = new Graph(new In(args[0]));
            //int s = Integer.parseInt(args[1]);
//            DepthFirstPaths search = new DepthFirstPaths(G, s);

        }

        private static int FindPath(DepthFirstPaths search, int v)
        {
            int counter = 0;

            if (search.HasPathTo(v))
            {
                foreach (var x in search.PathTo(v))
                {
                    counter++;
                }
            }

            return counter;
        }
    }
}