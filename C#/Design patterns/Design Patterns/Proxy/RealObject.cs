using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Proxy
{
    public class RealObject : IProxy
    {
        public void DoSomething()
        {
            Console.WriteLine("doSomething"); 
        }
        public void SomethingElse(String arg)
        {
            Console.WriteLine("somethingElse " + arg);
        }
    }
}
