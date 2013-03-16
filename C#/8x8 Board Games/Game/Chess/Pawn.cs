using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JerryMouse
{
    internal class Pawn : Figure
    {
        private bool isFirstMove = true;

        internal Pawn(FigureColor color, FigureType type, Position position)
            : base(color, type, position)
        {
        }


	// TODO: !!!
        public bool Move(int x, int y)
        {
            int[,] moves = 
            {
		{-1, 1},
		{ 0, 1},
		{ 1, 1}       };



            return false;

        }
    }
}
