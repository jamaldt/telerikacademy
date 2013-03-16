using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animals
{
    class Kitten : Cat
    {
        public int Age { get { return age; } }

        public Kitten(int age, String name)
            : base(age, name, false)
        {
        }

        public override String MakeSound(String s)
        {
            String sex = isMale ? "male" : "female";
            return "Kitten is " + sex + " " + base.MakeSound(s);
        }
    }
}
