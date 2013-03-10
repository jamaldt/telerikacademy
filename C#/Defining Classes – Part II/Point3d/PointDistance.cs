using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Point3d
{
    static class PointDistance
    {
        public static int Calculate(Point3D first, Point3D second)
        {
            int x = (first.X - second.X) * (first.X - second.X);
            int y = (first.Y - second.Y) * (first.Y - second.Y);
            int z = (first.Z - second.Z) * (first.Z - second.Z);
            return (int) Math.Sqrt(x + y + z);
        }
    }
}
