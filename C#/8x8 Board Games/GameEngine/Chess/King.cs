using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameEngine
{
    internal class King : Figure
    {
        internal King(FigureColor color, FigureType type, Position position)
            : base(color, type, position)
        {
            switch (color)
            {
                case FigureColor.Black:
                    draw = "\u265A";
                    break;
                case FigureColor.White:
                    draw = "\u2654";
                    break;
            }
        }

        public override void CalculateValidMoves(Position currentPosition)
        {
            for (int i = -1; i < 2; i++)
            {
                for (int j = -1; j < 2; j++)
                {
                    if (i == 0 && j == 0)
                    {
                        continue;
                    }
                    else if (currentPosition.X + i >= 0 && currentPosition.X + i <= 7 && currentPosition.Y + j >= 0 && currentPosition.Y + j <= 7) 
                    {
                        Position p = new Position();
                        p.X = currentPosition.X + i;
                        p.Y = currentPosition.Y + j;
                        this.validMoves.Add(p);
                    }                    
                }
            }
        }
    }
}
