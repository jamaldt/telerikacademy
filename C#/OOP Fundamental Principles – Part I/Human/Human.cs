using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Human
{
    abstract class Human
    {
        protected String firstName;
        protected String lastName;

        public String Name { get { return firstName + " " + lastName; } }
        public String FirstName { get { return firstName; } }
        public String LastName { get { return lastName; } }
    }
}
