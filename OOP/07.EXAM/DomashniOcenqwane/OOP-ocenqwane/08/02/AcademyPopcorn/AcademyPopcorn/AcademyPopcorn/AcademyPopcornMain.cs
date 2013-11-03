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
                
                // task 10
                if (i == 7)
                {
                    currBlock = new ExplodingBlock(new MatrixCoords(startRow, i));
                }

                //task 12
                else if (i == endCol - 3)
                {
                    currBlock = new GiftBlock(new MatrixCoords(startRow, i));
                }

                engine.AddObject(currBlock);
            }

            /* 07. Test the MeteoriteBall by replacing the normal ball in the AcademyPopcornMain.cs file.*/
            /* Ball theBall = new Ball(new MatrixCoords(WorldRows / 2, 0),
                new MatrixCoords(-1, 1));
            */
            Ball theBall = new MeteoriteBall(new MatrixCoords(WorldRows / 2 + 1, 0), new MatrixCoords(-1, 1));
            engine.AddObject(theBall);

            // 09. Test the UnpassableBlock and the UnstoppableBall by adding them to the engine in AcademyPopcornMain.cs file
           /* Ball theUnstopableBall = new UnstopableBall(new MatrixCoords(WorldRows / 2, 0), new MatrixCoords(-1, 1));
            engine.AddObject(theUnstopableBall);

            for (int i = 2; i < WorldCols / 2; i += 4)
            {
                engine.AddObject(new UnpassableBlocks(new MatrixCoords(4, i)));
            }
            */
            Racket theRacket = new Racket(new MatrixCoords(WorldRows - 1, WorldCols / 2), RacketLength);

            engine.AddObject(theRacket);

        }

        static void Main(string[] args)
        {
            IRenderer renderer = new ConsoleRenderer(WorldRows, WorldCols);
            IUserInterface keyboard = new KeyboardInterface();

           // Engine gameEngine = new Engine(renderer, keyboard);
            ShootEngineRacket gameEngine = new ShootEngineRacket(renderer, keyboard);

            keyboard.OnLeftPressed += (sender, eventInfo) =>
            {
                gameEngine.MovePlayerRacketLeft();
            };

            keyboard.OnRightPressed += (sender, eventInfo) =>
            {
                gameEngine.MovePlayerRacketRight();
            };
            // task 13
            //Engine gameEngineShoot = new ShootEngineRacket(renderer, keyboard);
            keyboard.OnActionPressed += (sender, eventInfo) =>
            {
                gameEngine.ShootPlayerRacket();
            };


            /* 01.The AcademyPopcorn class contains an IndestructibleBlock class. 
               Use it to create side and ceiling walls to the game. You can ONLY edit the AcademyPopcornMain.cs file.
            */
            for (int i = 2; i < WorldRows; i++)
            {
                IndestructibleBlock rightWall = new IndestructibleBlock(new MatrixCoords(i, WorldCols - 1));
                IndestructibleBlock leftWall = new IndestructibleBlock(new MatrixCoords(i, 0));
                gameEngine.AddObject(leftWall);
                gameEngine.AddObject(rightWall);
            }
            for (int i = 0; i < WorldCols; i++)
            {
                IndestructibleBlock topWall = new IndestructibleBlock(new MatrixCoords(2, i));
                gameEngine.AddObject(topWall);
            }
            // test 05 task
            TrailObject trailObject = new TrailObject(new MatrixCoords(5, 5), new char[,] { { '*' } }, 20);
            gameEngine.AddObject(trailObject);

           

            Initialize(gameEngine);

            //

            gameEngine.Run();
        }
    }
}
