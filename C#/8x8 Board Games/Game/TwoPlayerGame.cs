using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JerryMouse
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
	    
	    while (true) 
	    {
		int X = ShowMenu();
		switch (X)
	        {
	            case 1:
		        PlayGame(new CheckersFactory());
			break;
		    case 2:
			PlayGame(new ChessFactory());
			break;
		}
	    }

        }

        private static int ShowMenu()
        {
            return 2;
        }

    }
}
