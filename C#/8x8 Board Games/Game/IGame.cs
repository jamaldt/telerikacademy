using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JerryMouse
{
    public interface IGame
    {
        bool isEndGame();
        bool isMoveValid(PlayerMoveDTO playerMoveDTO);
        void MoveFigure(PlayerMoveDTO playerMoveDTO);
        Figure[,] GetBoard();
    }
}
