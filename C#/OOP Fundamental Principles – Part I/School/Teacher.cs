using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School
{
    class Teacher : People
    {
        List<Disciplines> disciplines = new List<Disciplines>();

        public List<Disciplines> Disciplines
        {
            get
            {
                return disciplines; // TODO: return deep copy
            }
        }

        public Teacher(String name, List<Disciplines> disc)
            : base(name)
        {
            disciplines = disc;
        }

    }
}
