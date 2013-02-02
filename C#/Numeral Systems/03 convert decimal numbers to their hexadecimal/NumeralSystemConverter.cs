using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07_convert_from_base_S_to_base_D
{
    class NumeralSystemConverter
    {
        private int number;

        public NumeralSystemConverter(string num, int baseSystem)
        {    
            number = ConvertToDec(num, baseSystem);                        
        }

        public string ConvertToBase(int baseSystem)
        {
            int n = number;
            StringBuilder num = new StringBuilder();
            char c;
            do
            {
                c = IntToLetter(n % baseSystem);
                num.Append(c);
                n /= baseSystem;
            }
            while (n > 0);

            char tmp;
            for (int i = 0; i < num.Length/2; i++)
			{
                tmp = num[i];
                num[i] = num[num.Length - i - 1];
                num[num.Length - i - 1] = tmp;
			}
            return num.ToString();
        }

        private char IntToLetter(int n)
        {

            if (n < 10)
            {
                return (char)(48+n);
            }
            else if (n < 36)
            {
                return (char)(55 + n);
            }
            else
            {
                throw new Exception("FOR NOW IT WORKS MAX FROM 0 to Z");
            }
        }

        private int ConvertToDec(string num, int baseSystem)
        {
            int n = 0;
            int s;
            for (int i = 0; i < num.Length; i++)
            {
                s = LetterToInt(num[i]);
                if (s >= baseSystem)
                {
                    throw new FormatException("DIGITS IN NUMBER ARE NOT IN BASE FORMAT");
                }
                n += s * (int)Math.Pow(baseSystem, num.Length - i - 1);
            }
            return n;
        }        

        private static int LetterToInt(char f)
        {
            if (f <= '9' && f >= '0')
            {
                return int.Parse(f.ToString());
            }
            else if (f >= 'A' && f <= 'Z')
            {
                return (int)f - 55;
            }
            else if (f >= 'a' && f <= 'z')
            {
                return (int)f - 87; 
            }
            else
            {
                throw new FormatException("DIGITS IN NUMBER ARE NOT IN VALID FORMAT A-Za-z0-9");
            }
        }
    }
}
