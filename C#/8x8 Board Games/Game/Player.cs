using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameEngine
{
    public class Player
    {
        private FigureColor color;

        public Player(FigureColor figureColor)
        {
            // TODO: Complete member initialization
            this.color = figureColor;
        }
        internal PlayerMoveDTO Move(Figure[,] board)
        {
            return new PlayerMoveDTO();
        }
    }
}
