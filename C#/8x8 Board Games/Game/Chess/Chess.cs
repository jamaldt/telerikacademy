using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JerryMouse
{
    public class Chess : IGame
    {

        private Figure[,] board = new Figure[8, 8];



        public bool isEndGame()
        {
            throw new NotImplementedException();
        }

        public bool isMoveValid(PlayerMoveDTO playerMoveDTO)
        {
            throw new NotImplementedException();
	    // 
        }

        public void MoveFigure(PlayerMoveDTO playerMoveDTO)
        {
            board[playerMoveDTO.figure.X, playerMoveDTO.figure.Y] = null;
            board[playerMoveDTO.position.X, playerMoveDTO.position.Y] = playerMoveDTO.figure;
        }

        public Figure[,] GetBoard()
        {
            throw new NotImplementedException();
        }
    }
}
