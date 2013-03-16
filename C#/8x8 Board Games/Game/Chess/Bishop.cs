using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JerryMouse
{
    internal class Bishop : Figure
    {
        internal Bishop(FigureColor color, FigureType type, Position position)
            : base(color, type, position)
        {
        }
    }
}
