using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyPopcorn
{
    class AcademyPopcornMain
    {
        const int WorldRows = 23;
        const int WorldCols = 40;
        const int RacketLength = 6;

        static void Initialize(Engine engine)
        {
            int startRow = 3;
            int startCol = 2;
            int endCol = WorldCols - 2;

            for (int i = startCol; i < endCol; i++)
            {
                Block currBlock = new Block(new MatrixCoords(startRow, i));
                engine.AddObject(currBlock);
            }

	    // add exploading block
            for (int i = 0; i < 3; i+=3)
            {
                Block block = new ExplodingBlock(new MatrixCoords(startRow + 1, 5 + i));
                engine.AddObject(block);
            }

            // left and right wall
            for (int row = 0; row < WorldRows; row++)
            {
                Block indestructableBlockLeft = new IndestructibleBlock(new MatrixCoords(row, 0));
                Block indestructableBlockRight = new IndestructibleBlock(new MatrixCoords(row, WorldCols - 1));
                engine.AddObject(indestructableBlockLeft);
                engine.AddObject(indestructableBlockRight);
            }

            // ceiling wall
            for (int col = 0; col < WorldCols; col++)
            {
                Block indestructableBlock = new IndestructibleBlock(new MatrixCoords(0, col));
                engine.AddObject(indestructableBlock);
            }

	    // add unpassable blocks
            for (int col = WorldCols / 2 - 2; col < WorldCols / 2 + 3 ; col++)
            {
                Block block = new UnpassableBlock(new MatrixCoords(5, col));
		engine.AddObject(block);
            }

	    // add gift blocks
            for (int i = 0; i < 2; i++)
            {
		Block block = new GiftBlock(new MatrixCoords(1, WorldRows / 2 + i));
		engine.AddObject(block);
            }

            char[,] trailObjImage = 
            {
		{ ' ', 'o', ' '},
		{ 'o', 'o', 'o'},
		{ ' ', 'o', ' '},
            };
            // let's test trail object
            GameObject trailObj = new TrailObject(new MatrixCoords(WorldRows / 2, WorldCols / 2), trailObjImage, 100);
            engine.AddObject(trailObj);

            Ball theBall = new MeteoriteBall(new MatrixCoords(WorldRows / 2, 0), new MatrixCoords(-1, 1));
            //Ball theBall = new UnstoppableBall(new MatrixCoords(WorldRows / 2, 0), new MatrixCoords(-1, 1));

            engine.AddObject(theBall);

            Racket theRacket = new Racket(new MatrixCoords(WorldRows - 1, WorldCols / 2), RacketLength);

            engine.AddObject(theRacket);
        }

        static void Main(string[] args)
        {
            IRenderer renderer = new ConsoleRenderer(WorldRows, WorldCols);
            IUserInterface keyboard = new KeyboardInterface();

            Engine gameEngine = new Engine(renderer, keyboard, 100);

            keyboard.OnLeftPressed += (sender, eventInfo) =>
            {
                gameEngine.MovePlayerRacketLeft();
            };

            keyboard.OnRightPressed += (sender, eventInfo) =>
            {
                gameEngine.MovePlayerRacketRight();
            };

            Initialize(gameEngine);

            //

            gameEngine.Run();
        }
    }
}
