using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _14_Labyrinth
{
    class Program
    {
        private static string[,] matrix;
        public const string InitialSymbol = "0";
        public const string UnavailableSymbol = "u";
        public const string WallSymbol = "X";

        public static void Main()
        {
            Console.Write("Enter N - The size of the matrix: ");
            int n = int.Parse(Console.ReadLine());

            matrix = new string[n, n];
            FillMatrix();

            //get random starting point.
            Random randomGenerator = new Random();
            int startingRow = randomGenerator.Next(0, n);
            int startingCol = randomGenerator.Next(0, n);
            matrix[startingRow, startingCol] = "*";

            Console.WriteLine("The initial matrix is:");
            PrintMatrix();
            MarkFields(new Point(startingRow, startingCol));
            MarkUnavailable();
            Console.WriteLine("The marked matrix is:");
            PrintMatrix();
        }

        private static void MarkUnavailable()
        {
            for (int r = 0; r < matrix.GetLength(0); r++)
            {
                for (int c = 0; c < matrix.GetLength(1); c++)
                {
                    if (matrix[r, c] == InitialSymbol)
                    {
                        matrix[r, c] = UnavailableSymbol;
                    }
                }
            }
        }

        private static void MarkFields(Point startingPoint)
        {
            Queue<Point> points = new Queue<Point>();
            Queue<int> distances = new Queue<int>();
            int currentDistance = 0;
            points.Enqueue(startingPoint);
            distances.Enqueue(0);

            while (points.Count != 0)
            {
                Point currentPoint = points.Dequeue();
                currentDistance = distances.Dequeue();

                Point downPoint = new Point(currentPoint.Row + 1, currentPoint.Col);
                if (IsAvailablePoint(downPoint))
                {
                    MarkCell(downPoint, currentDistance, points, distances);
                }

                Point upPoint = new Point(currentPoint.Row - 1, currentPoint.Col);
                if (IsAvailablePoint(upPoint))
                {
                    MarkCell(upPoint, currentDistance, points, distances);
                }

                Point rightPoint = new Point(currentPoint.Row, currentPoint.Col + 1);
                if (IsAvailablePoint(rightPoint))
                {
                    MarkCell(rightPoint, currentDistance, points, distances);
                }

                Point leftPoint = new Point(currentPoint.Row, currentPoint.Col - 1);
                if (IsAvailablePoint(leftPoint))
                {
                    MarkCell(leftPoint, currentDistance, points, distances);
                }
            }
        }

        private static void MarkCell(Point upPoint, int currentDistance, Queue<Point> points, Queue<int> distances)
        {
            matrix[upPoint.Row, upPoint.Col] = (currentDistance + 1).ToString();
            points.Enqueue(upPoint);
            distances.Enqueue(currentDistance + 1);
        }

        private static bool IsAvailablePoint(Point point)
        {
            if ((point.Row < 0 || point.Row >= matrix.GetLength(0)) ||
                (point.Col < 0 || point.Col >= matrix.GetLength(1)))
            {
                return false;
            }

            if (matrix[point.Row, point.Col] == InitialSymbol)
            {
                return true;
            }

            return false;
        }

        private static void PrintMatrix()
        {
            for (int r = 0; r < matrix.GetLength(0); r++)
            {
                for (int c = 0; c < matrix.GetLength(1); c++)
                {
                    if (matrix[r, c] == UnavailableSymbol)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                    }
                    else if (matrix[r, c] == WallSymbol)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Gray;
                    }

                    Console.Write("{0, 3}", matrix[r, c]);
                }

                Console.WriteLine();
            }
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine(new String('-', 40));
        }

        private static void FillMatrix()
        {
            Random randomGenerator = new Random();

            for (int r = 0; r < matrix.GetLength(0); r++)
            {
                for (int c = 0; c < matrix.GetLength(1); c++)
                {
                    int randomNumber = randomGenerator.Next(0, 101);
                    if (randomNumber < 30)
                    {
                        matrix[r, c] = WallSymbol;
                    }
                    else
                    {
                        matrix[r, c] = InitialSymbol;
                    }
                }
            }
        }
    }
}
