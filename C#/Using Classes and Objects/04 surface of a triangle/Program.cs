using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_surface_of_a_triangle
{
    //Write methods that calculate the surface of a triangle by given:
    //Side and an altitude to it; Three sides; Two sides and an angle between them. Use System.Math.
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("a:5 and h:6 = " + TriangleSurface(5,6));
            Console.WriteLine("a:5, b:10 and c:6  = " + TriangleSurface(5,10,6));
            Console.WriteLine("a:5 b:6 and alfa:60 = " + TriangleSurface(5,6,60));

        }

        static double TriangleSurface(double a, double h)
        {
            return ((a * h) / 2);
        }

        static double TriangleSurface(double a, double b, double c)
        {
            double p = ((a + b + c) / 2);
            return Math.Sqrt(p * (p - a) * (p - b) * (p - c));
        }

        static double TriangleSurface(double a, double b, int alfa)
        {
            double pi = Math.PI;
            double sin = Math.Sin((alfa * pi) / 180);
            return ((a * b * sin) / 2);
        }

    }
}
