using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameEngine
{
    public interface IGame
    {
        Figure[,] Board { get; }
        bool isEndGame();
        bool isMoveValid(PlayerMoveDTO playerMoveDTO);
        void MoveFigure(PlayerMoveDTO playerMoveDTO);
    }
}
