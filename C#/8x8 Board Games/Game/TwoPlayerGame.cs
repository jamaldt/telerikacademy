using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameEngine
{
    public class TwoPlayerGame
    {

        private static Player player1 = new Player(FigureColor.White);
        private static Player player2 = new Player(FigureColor.Black);

        public static void PlayGame(IGameFactory factory)
        {
            IGame game = factory.GetGame();
            PlayerMoveDTO playerMoveDTO;

            while (true)
            {
                do
                {
                    // Избира фигура, която иска да премести. Връща новата позиция на избраната фигура заедно с фигурара
                    // или нейните координати.
                    playerMoveDTO = player1.Move(game.Board);
                }
                while (!game.isMoveValid(playerMoveDTO));

		// местим фигурата на дъската
                game.MoveFigure(playerMoveDTO);
                if (game.isEndGame())
                {
                    return;
                }

                do
                {
                    // Избира фигура, която иска да премести. Връща новата позиция на избраната фигура заедно с фигурара
                    // или нейните координати.
                    playerMoveDTO = player2.Move(game.Board);
                }
                while (!game.isMoveValid(playerMoveDTO));

                game.MoveFigure(playerMoveDTO);
                if (game.isEndGame())
                {
                    return;
                }
            }

        }

        public static void Main(String[] args)
        {
	        
        //while (true) 
        //{
        //int X = ShowMenu();
        //switch (X)
        //    {
        //        case 1:
        //        PlayGame(new CheckersFactory());
        //    break;
        //    case 2:
        //    PlayGame(new ChessFactory());
        //    break;
        //}
            //Position p = new Position(2, 3);
            //Pawn pp = new Pawn(FigureColor.White, FigureType.Pawn, p);


//-------------------------Test figures
            //King is ok
            //Queen is ok
            //Rook is ok
            //Knight is ok
            //Bishop is ok 
            //Pawn is ok

            Console.WriteLine("Create new rook at (5, 7)");
            Console.WriteLine("Valid moves are:");
            Rook myRook = new Rook(FigureColor.White, FigureType.Rook, new Position(5, 7));
            foreach (Position pos in myRook.ValidMoves)
            {
                Console.WriteLine("{0}, {1}", pos.X, pos.Y);
            }
            Console.WriteLine("Move to new position (5,5)");
            Console.WriteLine("New Valid moves are:");
            myRook.Move(new Position(5,5));
            foreach (Position pos in myRook.ValidMoves)
            {
                Console.WriteLine("{0}, {1}", pos.X, pos.Y);
            }

//-------------------------Test figures
	    }

        }

        //private static int ShowMenu()
        //{
        //    return 2;
        //}

    }

