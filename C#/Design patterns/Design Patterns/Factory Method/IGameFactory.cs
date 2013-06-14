using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Factory_Method
{
    public interface IGameFactory
    {
        IGame GetGame();
    }
}
