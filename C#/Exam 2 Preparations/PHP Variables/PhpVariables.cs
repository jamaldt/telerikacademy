using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PHP_Variables
{
    class PhpVariables
    {
        static void Main(string[] args)
        {
           
            string text;// = ReadInput();
            
            text = @"<?php
$browser = $_SERVER['HTTP_USER_AGENT'] ;
$arr = array();
$arr[$zero] = $browser;
var_dump($arr);
?>";
            text = @"<?php
/* This is $var1 in comments */
$var3 = ""Some string \$var4 with var escaped."";
echo $var5; echo(""$foo,$bar"");
// Another comment with variable $var2
?>";

            text += @"<?php
# this is $comment
$valid_var='""text""...{$valid_var}';
$just=""Just another var $Just..."";$just=$code;
?>
$string_var = '""\'\'\\$important_var!!!""\\{$varvarvar}';";

            text = ReadInput();

            Regex phpVar = new Regex(@"\$[A-Za-z_][A-Za-z0-9_]*");
            Regex comments = new Regex(@"(/\*(.*?)\*/)|(//(.*?)\n)|(#(.*?)\n)", RegexOptions.Singleline);
            Regex escapedSymbols = new Regex(@"(\\['""\\]+)(\$[A-Za-z0-9_]+)"); // if escaped $ but not escapped something else  *\\$  '\\$ "\\$ 
            Regex escapedDolar = new Regex(@"\\\$");

            //ShowMatches(escapedSymbols.Match(text));
            text = escapedSymbols.Replace(text, "$2");
            //Console.WriteLine(text);
            text = escapedDolar.Replace(text, " ");
            text = comments.Replace(text, " ");
            Match match = phpVar.Match(text);
            string tmp;
            Dictionary<string, int> dict = new Dictionary<string, int>();
            while (match.Success)
            {
                tmp = match.Value;
                //tmp = tmp.Trim(new char[]{' ', '{', '}', '[', ']', '=', '\'', '\"', '\n', '.', ';', '$', '(', ')', '!'});
                tmp = tmp.TrimStart('$');
                if (!dict.ContainsKey(tmp))
                {
                    dict.Add(tmp, 0);
                }
                match = match.NextMatch();
            }
            Console.WriteLine(dict.Count);
            List<string> vars = dict.Keys.ToList();
            vars.Sort(StringComparer.Ordinal);

            foreach (var item in vars)
            {
                Console.WriteLine(item);
            }


        }

        private static void ShowMatches(Match match)
        {
            Console.WriteLine("####### MATCHES ########################################");
            while (match.Success)
            {
                Console.WriteLine(match.Value);
                match = match.NextMatch();
            }
            Console.WriteLine("####### END MATCHES ####################################");
        }

        static string ReadInput()
        {
            StringBuilder inputData = new StringBuilder();
            while (true)
            {
                string line = Console.ReadLine().Trim(); // optimization: trimming redundant whitespace characters 
                inputData.AppendLine(line);
                if (line == "?>") break; // Last line
            }
            return inputData.ToString();
        }

    }
}
