using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_Person
{
    class Person
    {
        private int? age;

        public int? Age
        {
            get { return age; }
            set { age = value; }
        }

        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public Person(string name, int? age = null)
        {
            this.Name = name;
            this.Age = age;
        }

        public override string ToString()
        {
            if (Age == null)
                return Name + ", is unaged :)";
            else
                return Name + " is " + Age.ToString() + " old.";
        }
    }
}
