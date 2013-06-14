using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Factory_Method
{
    public class Games
    {
        public static void PlayGame(IGameFactory factory) 
        {
            IGame s = factory.GetGame();
            while(s.Move())
            {
                //blank intentionaly
            }
        }

        public static void Main(String[] args)
        {
            PlayGame(new CheckersFactory());
            PlayGame(new ChessFactory());
        }
    }
}
