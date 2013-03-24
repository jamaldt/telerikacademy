using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameEngine
{
    internal class Queen : Figure
    {
        internal Queen(FigureColor color, FigureType type, Position position)
            : base(color, type, position)
        {
            switch (color)
            {
                case FigureColor.Black:
                    draw = "\u265B";
                    break;
                case FigureColor.White:
                    draw = "\u2655";
                    break;
            }
        }

        public override void CalculateValidMoves(Position currentPosition)
        {
            Figure.AddHorizontalMoves(currentPosition, this);
            Figure.AddVerticalMoves(currentPosition, this);
            Figure.AddDiagonalMoves(currentPosition, this);
        }
    }
}
