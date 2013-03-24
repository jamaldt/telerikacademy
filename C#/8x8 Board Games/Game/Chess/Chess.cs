using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameEngine
{
    public class Chess : IGame
    {
        private Figure[,] board = new Figure[8, 8]
	#region board declaration
        {
	    {
		new Rook(FigureColor.Black, FigureType.Rook, new Position(0,0)),
		new Knight(FigureColor.Black, FigureType.Rook, new Position(0,1)),
		new Bishop(FigureColor.Black, FigureType.Rook, new Position(0,2)),
		new Queen(FigureColor.Black, FigureType.Rook, new Position(0,3)),
		new King(FigureColor.Black, FigureType.Rook, new Position(0,4)),
		new Bishop(FigureColor.Black, FigureType.Rook, new Position(0,5)),
		new Knight(FigureColor.Black, FigureType.Rook, new Position(0,6)),
		new Rook(FigureColor.Black, FigureType.Rook, new Position(0,7)) 
	    },
	    {
		new Pawn(FigureColor.Black, FigureType.Rook, new Position(1,0)),
		new Pawn(FigureColor.Black, FigureType.Rook, new Position(1,1)),
		new Pawn(FigureColor.Black, FigureType.Rook, new Position(1,2)),
		new Pawn(FigureColor.Black, FigureType.Rook, new Position(1,3)),
		new Pawn(FigureColor.Black, FigureType.Rook, new Position(1,4)),
		new Pawn(FigureColor.Black, FigureType.Rook, new Position(1,5)),
		new Pawn(FigureColor.Black, FigureType.Rook, new Position(1,6)),
		new Pawn(FigureColor.Black, FigureType.Rook, new Position(1,7)) 
	    },
	    { null,  null,  null,  null,  null,  null,  null,  null},
	    { null,  null,  null,  null,  null,  null,  null,  null},
	    { null,  null,  null,  null,  null,  null,  null,  null},
	    { null,  null,  null,  null,  null,  null,  null,  null},
	    {
		new Pawn(FigureColor.White, FigureType.Rook, new Position(6,0)),
		new Pawn(FigureColor.White, FigureType.Rook, new Position(6,1)),
		new Pawn(FigureColor.White, FigureType.Rook, new Position(6,2)),
		new Pawn(FigureColor.White, FigureType.Rook, new Position(6,3)),
		new Pawn(FigureColor.White, FigureType.Rook, new Position(6,4)),
		new Pawn(FigureColor.White, FigureType.Rook, new Position(6,5)),
		new Pawn(FigureColor.White, FigureType.Rook, new Position(6,6)),
		new Pawn(FigureColor.White, FigureType.Rook, new Position(6,7)) 
	    },
	    {
		new Rook(FigureColor.White, FigureType.Rook, new Position(7,0)),
		new Knight(FigureColor.White, FigureType.Rook, new Position(7,1)),
		new Bishop(FigureColor.White, FigureType.Rook, new Position(7,2)),
		new Queen(FigureColor.White, FigureType.Rook, new Position(7,3)),
		new King(FigureColor.White, FigureType.Rook, new Position(7,4)),
		new Bishop(FigureColor.White, FigureType.Rook, new Position(7,5)),
		new Knight(FigureColor.White, FigureType.Rook, new Position(7,6)),
		new Rook(FigureColor.White, FigureType.Rook, new Position(7,7)) 
	    },
        };
	#endregion



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
            board[playerMoveDTO.figure.X, playerMoveDTO.figure.Y] = null;
            board[playerMoveDTO.position.X, playerMoveDTO.position.Y] = playerMoveDTO.figure;
        }

    }
}
