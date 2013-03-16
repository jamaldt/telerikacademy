using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School
{
    abstract class People : IComment
    {
        protected String name;
        public String Name { get { return name; } }

        public People(String name)
        {
            this.name = name;
        }

        public string Comment { get; set; }

    }
}
