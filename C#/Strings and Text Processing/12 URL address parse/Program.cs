using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _12_URL_address_parse
{
    //Write a program that parses an URL address given in the format:
    //[protocol]://[server]/[resource]
    /*and extracts from it the [protocol], [server] and [resource] elements. 
     * For example from the URL http://www.devbg.org/forum/index.php the following information should be extracted:
		[protocol] = "http"
		[server] = "www.devbg.org"
		[resource] = "/forum/index.php"
     */

    class Program
    {
        static void Main(string[] args)
        {
            string address = "http://www.devbg.org/forum/index.php";
            Regex protocol = new Regex(@"://");

            string[] prot = protocol.Split(address);
            string[] adr = prot[1].Split(new char[]{'/'}, 2);

            Console.WriteLine("[protocol] = " + prot[0]);
            Console.WriteLine("[server] = " + adr[0]);
            Console.WriteLine("[resource] = /" + adr[1]);

            Regex parsedAddress = new Regex("(.*)://(.*?)(/.*)");
            Match m = parsedAddress.Match(address);

            for (int i = 0; i < m.Groups.Count; i++)
            {
                Console.WriteLine("m[{0}]: {1}",i,m.Groups[i]);
            }


        }
    }
}
