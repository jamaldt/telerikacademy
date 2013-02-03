using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _18_Extract_all_emails_from_text
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = @"regex to validate email address noteworthy: (1) It allows usernames with 1 or 2 alphanum characters, or 3+ chars can have -._ 
in the middle. username may NOT start/end with -._ or any other non alphanumeric character. (2) It allows heirarchical domain names (e.g. me@really.big.com).
Similar -._ placement rules there. (3) It allows 2-9 character alphabetic-only TLDs (that oughta cover museum and adnauseum :&gt;). (4) No IP email addresses 
though -- I wouldn't Want to accept that kind of address.
Matches 	
e@eee.com | eee@e-e.com | eee@ee.eee.museum
Non-Matches 	
.@eee.com | eee@e-.com | eee@ee.eee.eeeeeeeeee
Author 	Rating: The rating for this expression. Rob Eberhardt
Title 	Test Details Pattern Title
Expression 	
(\w[-._\w]*\w@\w[-._\w]*\w\.\w{2,3})
Description 	
This is my all-time favourite e-mail validator. I've used it for years and it's never failed me :-)
Matches 	
foo@bar.com | foobar@foobar.com.au
Non-Matches 	
foo@bar | $$$@bar.com
Author 	Rating: The rating for this expression. Darren Neimke
Title 	Test Details Pattern Title
Expression 	
(?<user>(?:(?:[^ \t\(\)\<\>@,;\:\\\""\.\[\]\r\n]+)|(?:\""(?:(?:[^\""\\\r\n])|(?:\\.))*\""))(?:\.(?:(?:[^ \t\(\)\<\>@,;\:\\\""\.\[\]\r\n]+)|(?:\""(?:(?:[^\""\\\r\n])|(?:\\.))*\"")))*)@(?<domain>(?:(?:[^ \t\(\)\<\>@,;\:\\\""\.\[\]\r\n]+)|(?:\[(?:(?:[^\[\]\\\r\n])|(?:\\.))*\]))(?:\.(?:(?:[^ \t\(\)\<\>@,;\:\\\""\.\[\]\r\n]+)|(?:\[(?:(?:[^\[\]\\\r\n])|(?:\\.))*\])))*)
Description 	
Validates email addresses according to the RFC 822 specification. The only exception is the exclusion of control characters, which should be sufficient for human input from a keyboard.
Matches 	
Trais.Gray@domain.biz | ""Funny email"".notfunny@glxs.biz | ok@[funny domain].co.za
Non-Matches 	
""TravisGray""extra@ domain.biz Please contact us by phone (+359 222 222 222) or by email at
example@abv.bg or at baj.ivan@yahoo.co.uk. This is not email:
test@test. This also: @telerik.com. Neither this: a@a.b.";
            Regex email = new Regex(@"[A-Za-z0-9]([\w-_.]*\w)*@[A-Za-z0-9]([\w-_.]*\w)*\.[A-Za-z]{2,3}");
            Match match = email.Match(text);

            while (match.Success)
            {
                Console.WriteLine(match.Value);
                match = match.NextMatch();
            }
           
        }
    }
}
