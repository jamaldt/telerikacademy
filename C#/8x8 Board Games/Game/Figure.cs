using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JerryMouse
{
    public abstract class Figure
    {
        protected FigureColor color;
        protected FigureType type;
        protected Position position;

        internal Figure(FigureColor color, FigureType type, Position position)
        {
            this.color = color;
            this.type = type;
            this.position = position;
        }


        public int X { get { return position.X; } }
        public int Y { get { return position.Y; } }
        public FigureColor Color { get { return color; } }
        public FigureType Type { get { return type; } }


        public void Move(Position pos)
        {
            position = pos;
        }
    }
}
