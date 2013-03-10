using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Point3d
{
    /*
     * Create a structure Point3D to hold a 3D-coordinate {X, Y, Z}
     * in the Euclidian 3D space. Implement the ToString() to enable 
     * printing a 3D point.
     */
    struct Point3D
    {
        private int x;
        private int z;
        private int y;

        private static readonly Point3D point0 = new Point3D(0, 0, 0);

        public Point3D(int x, int y, int z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        public int X { get { return x; } set { x = value; } }
        public int Y { get { return y; } set { y = value; } }
        public int Z { get { return z; } set { z = value; } }

        public static Point3D Point0
        {
            get
            {
                return point0;
            }
        }

        public override string ToString()
        {
            return "" + x + ", " + y + ", " + z;
        }
    }
}
