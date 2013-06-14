using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Factory_Method
{
    public class Checkers : IGame
    {
        private int moves = 0;
        private static readonly int MOVES = 3;

        public bool Move()
        {
            Console.WriteLine("Checkers move " + this.moves);
            this.moves = this.moves + 1;
            return this.moves != MOVES;
        }
    }
}
