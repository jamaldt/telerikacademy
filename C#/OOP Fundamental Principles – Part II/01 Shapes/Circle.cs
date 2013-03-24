using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Shapes
{

    class Circle : Shape
    {
        public Circle(double radious)
        {
            this.width = radious;
        }

        public override double CalculateSurface()
        {
            return Math.PI * width * width / 4;
        }
    }
}
