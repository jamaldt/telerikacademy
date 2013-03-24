using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameEngine
{
    internal class Knight : Figure
    {
        internal Knight(FigureColor color, FigureType type, Position position)
            : base(color, type, position)
        {
        }
        
        protected bool IsPositionOnBoard(Position p)
        {
            if (p.X >= 0 && p.X <= 7 && p.Y >= 0 && p.Y <= 7)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public override void CalculateValidMoves(Position currentPosition)
        {
            Position p = new Position(0,0);
            for (int i = -2; i <= 2; i++)
			{
                for (int j = -2; j <= 2; j++)
                {
                    if (i * j == 2 || i * j == -2)
                    {
                        if (IsPositionOnBoard(p))
                        {
                            try
                            {
                                p.X = currentPosition.X + i;
                                p.Y = currentPosition.Y + j;
                                this.validMoves.Add(p);
                            }
                            catch (ArgumentOutOfRangeException)
                            {

                                continue;
                            }
                            
                        }
                    
                    }
                    
                }
			}
        }
    }
}
