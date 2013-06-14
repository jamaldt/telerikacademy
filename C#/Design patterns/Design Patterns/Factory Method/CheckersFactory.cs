using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Factory_Method
{
    public class CheckersFactory : IGameFactory
    {
        public IGame GetGame()
        {
            return new Checkers();
        }
    }
}
