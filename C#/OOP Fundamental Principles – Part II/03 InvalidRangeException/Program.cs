using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_InvalidRangeException
{
    class Program
    {
        static void Main(string[] args)
        {
            InvalidRangeException<int> intException =
                new InvalidRangeException<int>("Value has to be in range [1..100]!", 1, 100);
            InvalidRangeException<DateTime> dateException =
                new InvalidRangeException<DateTime>("Date must be  in range [1.1.1980..31.12.2013]!",
                new DateTime(1980, 1, 1), new DateTime(2013, 12, 31));

            Console.Write("Enter number: ");
            int number = int.Parse(Console.ReadLine());
            if (number < intException.Min || number > intException.Max)
            {
                throw intException;
            }

            Console.WriteLine();

            Console.Write("Enter date: ");
            DateTime date = DateTime.Parse(Console.ReadLine());
            if (date < dateException.Min || date > dateException.Max)
            {
                throw dateException;
            }
        }
    }
}
