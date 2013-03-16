using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School
{
    class School
    {
        List<Class> classes = new List<Class>();

        public School(List<Class> classes)
        {
            this.classes = classes;
        }
    }
}
