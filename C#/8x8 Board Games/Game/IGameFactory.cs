using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JerryMouse
{
    public interface IGameFactory
    {
        IGame GetGame();
    }
}
