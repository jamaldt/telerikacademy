using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameEngine
{
    public class Checkers : IGame
    {
        private Figure[,] board = new Figure[8, 8];


        public Figure[,] Board
        {
            get
            {
                Figure[,] newBoard = new Figure[8, 8];
                for (int col = 0; col < 8; col++)
                {
                    for (int row = 0; row < 8; row++)
                    {
                        newBoard[col, row] = this.board[col, row];
                    }
                }
                return newBoard;
            }
        }

        public bool isEndGame() // nedovyrsheno ima proverki izvyn razmerite na board
        {
            bool blackCanMove = false;
            bool whiteCanMove = false;
            for (int i = 0; i < 8; i++)
            {
                for (int y = 0; y < 8; y++)
                {
                    if (this.board[i, y].Color == FigureColor.Black && !blackCanMove)
                    {
                        if ((this.board[i + 1, y + 1] == null || this.board[i + 1, y - 1] == null) ||
                            (this.board[i + 1, y + 1].Color == FigureColor.Black && this.board[i + 2, y + 2] == null) ||
                            (this.board[i + 1, y - 1].Color == FigureColor.Black && this.board[i + 2, y - 2] == null))
                        {
                            blackCanMove = true;
                        }

                    }
                    else if (this.board[i, y].Color == FigureColor.White && !whiteCanMove)
                    {
                        if ((this.board[i + 1, y + 1] == null || this.board[i + 1, y - 1] == null) ||
                            (this.board[i + 1, y + 1].Color == FigureColor.White && this.board[i + 2, y + 2] == null) ||
                            (this.board[i + 1, y - 1].Color == FigureColor.White && this.board[i + 2, y - 2] == null))
                        {
                            whiteCanMove = true;
                        }
                    }
                }
            }

            if (blackCanMove && whiteCanMove)
            {
                return true;
            }
            return false;
        }

        public bool isMoveValid(PlayerMoveDTO playerMoveDTO) // ne se razbira koi cvqt e na hod !!!
        {
            if (playerMoveDTO.position.X >= 0 && playerMoveDTO.position.X < 8 &&
                playerMoveDTO.position.Y >= 0 && playerMoveDTO.position.Y < 8 &&
                this.board[playerMoveDTO.position.Y, playerMoveDTO.position.X] == null)
            {
                return true;
            }
            return false;
        }

        public void MoveFigure(PlayerMoveDTO playerMoveDTO)
        {
            this.board[playerMoveDTO.figure.Y, playerMoveDTO.figure.X] = null;
            playerMoveDTO.figure.Move(playerMoveDTO.position);
            this.board[playerMoveDTO.position.Y, playerMoveDTO.position.X] = playerMoveDTO.figure;
        }
    }
}
