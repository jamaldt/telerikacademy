using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Point3d
{
    class Path
    {
        private List<Point3D> path;

        public Path()
        {
            path = new List<Point3D>();
        }

        public ReadOnlyCollection<Point3D> Path
        {
            get
            {
                return path.AsReadOnly();
            }
        }

        public void AddPoint(Point3D p)
        {
            path.Add(p);
        }

    }
}
