using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Shapes
{
    class Rectangle : Shape
    {
        private int p1;
        private int p2;

        public Rectangle(double height, double width)
        {
            this.width = width;
            this.height = height;
        }

        public override double CalculateSurface()
        {
            return height * width;
        }
    }
}
