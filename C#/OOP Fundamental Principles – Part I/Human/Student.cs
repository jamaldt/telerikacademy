using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Human
{
    class Student : Human
    {
        private int grade;

        public int Grade { get { return grade; } }

        public Student(string firstName, string lastName, int grade)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.grade = grade;
        }
    }
}
