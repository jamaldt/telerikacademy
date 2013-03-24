using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Shapes
{
    class Program
    {
        static void Main(string[] args)
        {
            Shape[] shapes = { new Rectangle(2, 2), new Triangle(2, 2), new Circle(2) };
            foreach (var shape in shapes)
            {
                Console.WriteLine(shape.CalculateSurface());
            }
        }
    }
}
