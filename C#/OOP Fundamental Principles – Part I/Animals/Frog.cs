using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animals
{
    class Frog : Animal
    {

        public Frog(int age, String name, bool isMale)
        {
            this.age = age;
            this.name = name;
            this.isMale = isMale;
        }

        public override String MakeSound(String s)
        {
            return name + " says: kva-kva " + s;
        }
    }
}
