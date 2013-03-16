using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School
{
    class Student : People 
    {
        private int id;
        public int Id { get { return id; } }

        public Student(String name, int id)
            : base(name)
        {
            this.id = id;
        }

    }
}
