using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Proxy
{
    public class SimpleProxyDemo
    {
        public static void Consumer(IProxy iface)
        {
            iface.DoSomething();
            iface.SomethingElse("bonobo");
        }
        public static void Main(String[] args)
        {
            Consumer(new RealObject());
            Consumer(new SimpleProxy(new RealObject()));
        }
    }
}
