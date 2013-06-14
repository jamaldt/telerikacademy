using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Factory_Method
{
    public class Chess : IGame
    {
        private int moves = 0;
        private static readonly int MOVES = 4;

        public bool Move()
        {
            Console.WriteLine("Chess move " + this.moves);
            this.moves = this.moves + 1;
            return this.moves != MOVES;
        }
    }
}
