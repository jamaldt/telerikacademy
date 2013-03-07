using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mbile_phone_device
{
    class GSMTest
    {
        public static void Main()
        {
            Gsm[] gsm = new Gsm[]{
		    new Gsm("Xperia", "Sony"),
		    new Gsm("P4350", "HTC"),
		    new Gsm("iGnome", "Apple"),
		    };

            foreach (var phone in gsm)
            {
                Console.WriteLine(phone);
                Console.WriteLine();
            }

            Console.WriteLine();
            Console.WriteLine(Gsm.IPhone4S);
        }


    }
}
