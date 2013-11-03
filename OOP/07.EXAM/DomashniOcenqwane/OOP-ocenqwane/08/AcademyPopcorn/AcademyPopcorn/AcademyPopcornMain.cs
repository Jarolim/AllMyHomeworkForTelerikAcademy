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

            engine.AddObject(new TailObject(new MatrixCoords(10, 5), new char[1,1] {{'%'}}, 5));

            for (int i = startCol; i < endCol; i++)
            {
                Block currBlock2 = new Block(new MatrixCoords(startRow + 1, i));
                engine.AddObject(currBlock2);
                ExplodingBlock currBlock3 = new ExplodingBlock(new MatrixCoords(startRow + 2, i));
                engine.AddObject(currBlock3);
                GiftBlock currBlock4 = new GiftBlock(new MatrixCoords(startRow + 3, i));
                engine.AddObject(currBlock4);

            }

            for (int i = startCol - 1; i <= endCol; i++)
            {
                IndestructibleBlock currBlock = new IndestructibleBlock(new MatrixCoords(startRow, i));
                engine.AddObject(currBlock);
            }

            for (int i = startRow; i <= WorldRows; i++)
            {
                IndestructibleBlock currBlock1 = new IndestructibleBlock(new MatrixCoords(i, startCol - 1));
                IndestructibleBlock currBlock2 = new IndestructibleBlock(new MatrixCoords(i, endCol      ));
                engine.AddObject(currBlock1);
                engine.AddObject(currBlock2);
            }

            //MeteoriteBall theBall = new MeteoriteBall(new MatrixCoords(WorldRows / 2, 0),
            //    new MatrixCoords(-1, 1));
            Ball theBall = new Ball(new MatrixCoords(WorldRows / 2, 0),
                new MatrixCoords(-1, 1));


            engine.AddObject(theBall);

            Gift gift = new Gift(new MatrixCoords(8, 20));
            engine.AddObject(gift);

            Racket theRacket = new Racket(new MatrixCoords(WorldRows - 1, WorldCols / 2), RacketLength);

            engine.AddObject(theRacket);
        }

        static void Main(string[] args)
        {
            IRenderer renderer = new ConsoleRenderer(WorldRows, WorldCols);
            IUserInterface keyboard = new KeyboardInterface();

            Engine gameEngine = new Engine(renderer, keyboard);

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
