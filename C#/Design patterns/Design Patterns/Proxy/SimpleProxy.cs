using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Proxy
{
    public class SimpleProxy : IProxy
    {
        private IProxy proxied;

        public SimpleProxy(IProxy proxied)
        {
            this.proxied = proxied;
        }
        public void DoSomething()
        {
            Console.WriteLine("SimpleProxy doSomething");
            proxied.DoSomething();
        }
        public void SomethingElse(String arg)
        {
            Console.WriteLine("SimpleProxy somethingElse " + arg);
            proxied.SomethingElse(arg);
        }
    }
}
