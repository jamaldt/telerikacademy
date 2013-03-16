using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animals
{
    class Tomcat : Cat
    {

        public Tomcat(int age, String name)
            : base(age, name, true)
        {
        }

        public override String MakeSound(String s)
        {
            String sex = isMale ? "male" : "female";
            return "Tomcat is " + sex + " " + base.MakeSound(s);
        }
    }
}
