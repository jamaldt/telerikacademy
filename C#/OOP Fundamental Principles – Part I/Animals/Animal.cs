using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animals
{
    abstract class Animal : ISound
    {

	public int Age { get { return age; } }

        protected int age;
        protected String name;
        protected bool isMale;

        public virtual String MakeSound(string s)
        {
            return s;
        }
    }
}
