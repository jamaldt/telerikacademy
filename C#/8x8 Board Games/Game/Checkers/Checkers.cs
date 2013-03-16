using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JerryMouse
{
    public class Checkers : IGame
    {
        private Figure[,] board = new Figure[8, 8];


        public Figure[,] Board
        {
            get
            {
                // TODO: implement deep copy of board field and return it
                throw new NotImplementedException();
            }
        }

        public bool isEndGame()
        {
            throw new NotImplementedException();
        }

        public bool isMoveValid(PlayerMoveDTO playerMoveDTO)
        {
            throw new NotImplementedException();
        }

        public void MoveFigure(PlayerMoveDTO playerMoveDTO)
        {
            throw new NotImplementedException();
        }
    }
}
