using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameEngine
{
    internal class Pawn : Figure
    {
        private bool isFirstMove = true;

        internal Pawn(FigureColor color, FigureType type, Position position)
            : base(color, type, position)
        {
            switch (color)
            {
                case FigureColor.Black:
                    draw = "\u265F";
                    break;
                case FigureColor.White:
                    draw = "\u2659";
                    break;
            }
        }

        public override void CalculateValidMoves(Position pos)
        {
            Position p = new Position();
            if (color == FigureColor.White)
            {
                if (isFirstMove)
	            {
                    p.Y = pos.Y - 2;
                    p.X = pos.X;
		            this.validMoves.Add(p);
                    p.Y = pos.Y - 1;
                    p.X = pos.X;
                    this.validMoves.Add(p);
                    
                }
                else
	            {
                    p.Y = pos.Y - 1;
                    p.X = pos.X;
                    this.validMoves.Add(p);
	            }
            }
            else if (color == FigureColor.Black)
            {
                if (isFirstMove)
                {
                    p.Y = pos.Y + 2;
                    this.validMoves.Add(p);
                    p.Y = pos.Y + 1;
                    this.validMoves.Add(p);
                }
                else
                {
                    p.Y = pos.Y + 1;
                    this.validMoves.Add(p);
                }
            }
            else
            {
                throw new ArgumentException();
            }
        }
    }
}
