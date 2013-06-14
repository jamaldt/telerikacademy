using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _15_Replace_one_tag_with_another
{
    //Write a program that replaces in a HTML document given as string all the tags
    //<a href="…">…</a> with corresponding tags [URL=…]…/URL]. Sample HTML fragment:

    //<p>Please visit <a href="http://academy.telerik. com">our site</a> to choose
    //a training course. Also visit <a href="www.devbg.org">our forum</a> to discuss the courses.</p>

    //<p>Please visit [URL=http://academy.telerik. com]our site[/URL] to choose a training course.
    //Also visit [URL=www.devbg.org]our forum[/URL] to discuss the courses.</p>

    class Program
    {
        static void Main(string[] args)
        {
            string html = @"<p>Please visit <a href=""http://academy.telerik. com"">our site</a> to choose a training course. Also visit <a href=""www.devbg.org"">our forum</a> to discuss the courses.</p>";
            Regex aTag = new Regex(@"<a href=""(.*?)"">(.*?)</a>");
            
            /*
            Match match = aTag.Match(html);
            while (match.Success)
            {
                Console.WriteLine(match);
                match = match.NextMatch();
            }
            Console.WriteLine("END");
            */

            Console.WriteLine(aTag.Replace(html, "[URL=$1]$2[/URL]"));
        }


    }
}
