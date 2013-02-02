using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _25_Extract_text_from_html_page
{
    //Write a program that extracts from given HTML file its title (if available),
    //and its body text without the HTML tags. Example:
    class Program
    {
        static void Main(string[] args)
        {
            string str = @"<html>
                                <head><title>News</title></head>
                                <body>
                                    <p>
                                        <a href=""http://academy.telerik.com"">Telerik
                                        Academy</a>aims to provide<asd>TEST<asd> free real-world practical
                                        training for young people who want to turn into
                                        skillful .NET software engineers.
                                    </p>
                                </body>
                           </html>";

            string html = "";

            using (WebClient client = new WebClient())
            {
                try
                {
                    html = client.DownloadString("http://www.lipsum.com/");
                }
                catch (ArgumentNullException e)
                {
                    Console.WriteLine("null instead of address passed");
                }
                catch (WebException e)
                {
                    Console.WriteLine("error while DownloadString file");
                }
                catch (NotSupportedException e)
                {
                    Console.WriteLine("DownloadString() cann't be called");
                }

            }

            Regex regexTitle = new Regex(@"<title>(\s*\w.*)</title>", RegexOptions.Singleline);
            Regex regexBodyText = new Regex(@"<body>(.*)</body>", RegexOptions.Singleline);
            Regex regexBetweenTags = new Regex(@">([^<>]*\w+[^<>]*)<", RegexOptions.Singleline);

            string title = regexTitle.Match(html).Groups[1].Value;
            string body = regexBodyText.Match(html).Groups[1].Value;
            body = Regex.Replace(body, @"\s+", " ");
            //Console.WriteLine(body);
            //Console.WriteLine("### TEST ###");
            //body = Regex.Replace(body, @">\s+", ">");
            //body = Regex.Replace(body, @"\s+<", "<");

            Console.WriteLine("title: " + title);

            Match match = regexBetweenTags.Match(body);
            while (match.Success)
            {
                // Handle match here...
                Console.Write(match.Groups[1].Value + " ");                
                match = match.NextMatch();
            }
            Console.WriteLine();

        }
    }
}
