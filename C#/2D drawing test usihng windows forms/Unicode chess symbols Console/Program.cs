using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unicode_chess_symbols_Console
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Console.OutputEncoding = System.Text.Encoding.UTF8;
            System.Console.WriteLine("پارسی");
            Console.WriteLine();
            String chess = "\u2654 \u2655 \u2656 \u2657 \u2658 \u2659";
            Console.WriteLine("Chess Symbols http://en.wikipedia.org/wiki/Chess_symbols_in_Unicode");
            Console.WriteLine(chess);

        }
    }
}
