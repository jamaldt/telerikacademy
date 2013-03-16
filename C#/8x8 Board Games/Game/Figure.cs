using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JerryMouse
{
    public abstract class Figure
    {
        FigureColor color;
        FigureType type;

        Figure(FigureColor color, FigureType type)
        {
            this.color = color;
            this.type = type;
        }

        Position position = new Position();

        public int X { get { return position.X; } }
        public int Y { get { return position.Y; } }


        public void Move(Position pos)
        {
            position = pos;
        }
    }
}
