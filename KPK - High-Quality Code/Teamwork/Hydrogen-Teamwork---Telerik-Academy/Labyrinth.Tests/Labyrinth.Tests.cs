using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Labyrinth.Tests
{
    [TestClass]
    public class LabyrinthTests
    {
        private Cell[,] LabyrinthDataFromStringArray(string[] rawData)
        {
            Cell[,] result = new Cell[Labyrinth.LabyrinthSize, Labyrinth.LabyrinthSize];

            for (int row = 0; row < Labyrinth.LabyrinthSize; row++)
            {
                for (int column = 0; column < Labyrinth.LabyrinthSize; column++)
                {
                    result[row, column] = new Cell(row, column, rawData[row][column]);
                }
            }

            return result;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "The start position cannot be null")]
        public void Position_NullValue()
        {
            PlayerPosition startPosition = new PlayerPosition();
            startPosition = null;
            Labyrinth labyrinth = new Labyrinth(startPosition);
        }

        [TestMethod]
        public void IsOnBoarderTest()
        {
            PlayerPosition startPosition = new PlayerPosition(3, 3);
            Labyrinth labyrinth = new Labyrinth(startPosition);
            var privateObject = new PrivateObject(labyrinth);
            var actual = privateObject.Invoke("IsOnBorder", 6, 6);

            Assert.AreEqual(true, actual);
        }

        [TestMethod]
        public void IsGameWonTestTrue()
        {
            PlayerPosition startPosition = new PlayerPosition(3, 3);
            Labyrinth labyrinth = new Labyrinth(startPosition);
            var privateObject = new PrivateObject(labyrinth);
            var actual = privateObject.Invoke("IsGameWon", 6, 6);

            Assert.AreEqual(true, actual);
        }

        [TestMethod]
        public void IsGameWonTestFalse()
        {
            PlayerPosition startPosition = new PlayerPosition(3, 3);
            Labyrinth labyrinth = new Labyrinth(startPosition);
            var privateObject = new PrivateObject(labyrinth);
            var actual = privateObject.Invoke("IsGameWon", 3, 3);

            Assert.AreEqual(false, actual);
        }

        [TestMethod]
        public void LabyrinthMoveUpTest()
        {
            PlayerPosition startPosition = new PlayerPosition(3, 3);
            string[] rawData = new string[Labyrinth.LabyrinthSize]
            {
                "XXXXXXX",
                "X-X---X",
                "X---X-X",
                "X--*--X",
                "X-X----",
                "X-----X",
                "XXXXXXX"
            };
            Cell[,] board = LabyrinthDataFromStringArray(rawData);
            Labyrinth labyrinth = new Labyrinth(startPosition, board);
            var privateObject = new PrivateObject(labyrinth);
            privateObject.Invoke("ProcessMoveUp", 3, 3);
            string result =
                @"X X X X X X X 
X - X - - - X 
X - - * X - X 
X - - - - - X 
X - X - - - - 
X - - - - - X 
X X X X X X X 
";
            string expected = labyrinth.ToString();

            Assert.AreEqual(expected, result);                       
        }

        [TestMethod]
        public void LabyrinthMoveDownTest()
        {
            PlayerPosition startPosition = new PlayerPosition(3, 3);
            string[] rawData = new string[Labyrinth.LabyrinthSize]
            {
                "XXXXXXX",
                "X-X---X",
                "X---X-X",
                "X--*--X",
                "X-X----",
                "X-----X",
                "XXXXXXX"
            };

            Cell[,] board = LabyrinthDataFromStringArray(rawData);
            Labyrinth labyrinth = new Labyrinth(startPosition, board);
            var privateObject = new PrivateObject(labyrinth);
            privateObject.Invoke("ProcessMoveDown", 3, 3);
            string result =
                @"X X X X X X X 
X - X - - - X 
X - - - X - X 
X - - - - - X 
X - X * - - - 
X - - - - - X 
X X X X X X X 
";
            string expected = labyrinth.ToString();

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void LabyrinthMoveLeftTest()
        {
            PlayerPosition startPosition = new PlayerPosition(3, 3);

            string[] rawData = new string[Labyrinth.LabyrinthSize]
            {
                "XXXXXXX",
                "X-X---X",
                "X---X-X",
                "X--*--X",
                "X-X----",
                "X-----X",
                "XXXXXXX"
            };

            Cell[,] board = LabyrinthDataFromStringArray(rawData);

            Labyrinth labyrinth = new Labyrinth(startPosition, board);

            var privateObject = new PrivateObject(labyrinth);

            privateObject.Invoke("ProcessMoveLeft", 3, 3);

            string result =
                @"X X X X X X X 
X - X - - - X 
X - - - X - X 
X - * - - - X 
X - X - - - - 
X - - - - - X 
X X X X X X X 
";
            string expected = labyrinth.ToString();
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void LabyrinthMoveRight()
        {
            PlayerPosition startPosition = new PlayerPosition(3, 3);
            string[] rawData = new string[Labyrinth.LabyrinthSize]
            {
                "XXXXXXX",
                "X-X---X",
                "X---X-X",
                "X--*--X",
                "X-X----",
                "X-----X",
                "XXXXXXX"
            };
            Cell[,] board = LabyrinthDataFromStringArray(rawData);
            Labyrinth labyrinth = new Labyrinth(startPosition, board);

            var privateObject = new PrivateObject(labyrinth);
            privateObject.Invoke("ProcessMoveRight", 3, 3);

            string result =
                @"X X X X X X X 
X - X - - - X 
X - - - X - X 
X - - - * - X 
X - X - - - - 
X - - - - - X 
X X X X X X X 
";
            string expected = labyrinth.ToString();

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void IsExitPathAvailableTrue()
        {
            PlayerPosition startPosition = new PlayerPosition(3, 3);
            string[] rawData = new string[Labyrinth.LabyrinthSize]
            {
                "XXXXXXX",
                "X-X---X",
                "X---X-X",
                "X--*--X",
                "X-X----",
                "X-----X",
                "XXXXXXX"
            };
            Cell[,] board = LabyrinthDataFromStringArray(rawData);
            Labyrinth labyrinth = new Labyrinth(startPosition, board);
            var privateObject = new PrivateObject(labyrinth);
            var result = privateObject.Invoke("ExitPathAvailable");

            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public void IsExitPathAvailableFalse()
        {
            PlayerPosition startPosition = new PlayerPosition(3, 3);
            string[] rawData = new string[Labyrinth.LabyrinthSize]
            {
                "XXXXXXX",
                "X-X---X",
                "X---X-X",
                "X--*--X",
                "X-X---X",
                "X-----X",
                "XXXXXXX"
            };

            Cell[,] board = LabyrinthDataFromStringArray(rawData);
            Labyrinth labyrinth = new Labyrinth(startPosition, board);
            var privateObject = new PrivateObject(labyrinth);
            var result = privateObject.Invoke("ExitPathAvailable");

            Assert.AreEqual(false, result);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void IsExitPathAvailableFalseWithNullPosition()
        {
            PlayerPosition startPosition = new PlayerPosition(3, 3);
            string[] rawData = new string[Labyrinth.LabyrinthSize]
            {
                "XXXXXXX",
                "X-X---X",
                "X---X-X",
                "X--*--X",
                "X-X---X",
                "X-----X",
                "XXXXXXX"
            };

            Cell[,] board = LabyrinthDataFromStringArray(rawData);
            Labyrinth labyrinth = new Labyrinth(null, board);
            var privateObject = new PrivateObject(labyrinth);
            var result = privateObject.Invoke("ExitPathAvailable");
        }

        [TestMethod]
        public void IsWonWithEscapeFalse()
        {
            PlayerPosition startPosition = new PlayerPosition(3, 3);
            string[] rawData = new string[Labyrinth.LabyrinthSize]
            {
                "XXXXXXX",
                "X-X---X",
                "X---X-X",
                "X--*--X",
                "X-X---X",
                "X-----X",
                "XXXXXXX"
            };
            Cell[,] board = LabyrinthDataFromStringArray(rawData);
            Labyrinth labyrinth = new Labyrinth(startPosition, board);
            var result = labyrinth.IsWonWithEscape;

            Assert.AreEqual(false, result);
        }

        [TestMethod]
        public void GetBoardTest()
        {
        }

        [TestMethod]
        public void PlayerCommandUp()
        {
            PlayerPosition startPosition = new PlayerPosition(3, 3);

            string[] rawData = new string[Labyrinth.LabyrinthSize]
            {
                "XXXXXXX",
                "X-X---X",
                "X---X-X",
                "X--*--X",
                "X-X----",
                "X-----X",
                "XXXXXXX"
            };

            Cell[,] board = LabyrinthDataFromStringArray(rawData);

            Labyrinth labyrinth = new Labyrinth(startPosition, board);

            var privateObject = new PrivateObject(labyrinth);

            int x = 3;
            int y = 3;

            privateObject.Invoke("ProcessMove", "u", x, y);

            string result =
                @"X X X X X X X 
X - X - - - X 
X - - * X - X 
X - - - - - X 
X - X - - - - 
X - - - - - X 
X X X X X X X 
";
            string expected = labyrinth.ToString();
            Assert.AreEqual(expected, result);  
        }

        [TestMethod]
        public void PlayerCommanDownTest()
        {
            PlayerPosition startPosition = new PlayerPosition(3, 3);

            string[] rawData = new string[Labyrinth.LabyrinthSize]
            {
                "XXXXXXX",
                "X-X---X",
                "X---X-X",
                "X--*--X",
                "X-X----",
                "X-----X",
                "XXXXXXX"
            };

            Cell[,] board = LabyrinthDataFromStringArray(rawData);

            Labyrinth labyrinth = new Labyrinth(startPosition, board);

            var privateObject = new PrivateObject(labyrinth);
            int x = 3;
            int y = 3;
            privateObject.Invoke("ProcessMove", "d", x, y);

            string result =
                @"X X X X X X X 
X - X - - - X 
X - - - X - X 
X - - - - - X 
X - X * - - - 
X - - - - - X 
X X X X X X X 
";
            string expected = labyrinth.ToString();
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void PlayerCommanLeftTest()
        {
            PlayerPosition startPosition = new PlayerPosition(3, 3);

            string[] rawData = new string[Labyrinth.LabyrinthSize]
            {
                "XXXXXXX",
                "X-X---X",
                "X---X-X",
                "X--*--X",
                "X-X----",
                "X-----X",
                "XXXXXXX"
            };

            Cell[,] board = LabyrinthDataFromStringArray(rawData);

            Labyrinth labyrinth = new Labyrinth(startPosition, board);

            var privateObject = new PrivateObject(labyrinth);
            int x = 3;
            int y = 3;
            privateObject.Invoke("ProcessMove", "l", x, y);

            string result =
                @"X X X X X X X 
X - X - - - X 
X - - - X - X 
X - * - - - X 
X - X - - - - 
X - - - - - X 
X X X X X X X 
";
            string expected = labyrinth.ToString();
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void PlayerCommandRight()
        {
            PlayerPosition startPosition = new PlayerPosition(3, 3);

            string[] rawData = new string[Labyrinth.LabyrinthSize]
            {
                "XXXXXXX",
                "X-X---X",
                "X---X-X",
                "X--*--X",
                "X-X----",
                "X-----X",
                "XXXXXXX"
            };

            Cell[,] board = LabyrinthDataFromStringArray(rawData);

            Labyrinth labyrinth = new Labyrinth(startPosition, board);

            var privateObject = new PrivateObject(labyrinth);
            int x = 3;
            int y = 3;
            privateObject.Invoke("ProcessMove", "r", x, y);

            string result =
                @"X X X X X X X 
X - X - - - X 
X - - - X - X 
X - - - * - X 
X - X - - - - 
X - - - - - X 
X X X X X X X 
";
            string expected = labyrinth.ToString();
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void PlayerCommandRestart()
        {
            PlayerPosition startPosition = new PlayerPosition(3, 3);

            string[] rawData = new string[Labyrinth.LabyrinthSize]
            {
                "XXXXXXX",
                "X-X---X",
                "X---X-X",
                "X--*--X",
                "X-X----",
                "X-----X",
                "XXXXXXX"
            };

            Cell[,] board = LabyrinthDataFromStringArray(rawData);

            Labyrinth labyrinth = new Labyrinth(startPosition, board);

            var privateObject = new PrivateObject(labyrinth);
            int x = 3;
            int y = 3;
            privateObject.Invoke("ProcessMove", "restart", x, y);

            Assert.AreEqual(true, labyrinth.IsGameRestarted);
        }

        [TestMethod]
        public void PlayerCommandExit()
        {
            PlayerPosition startPosition = new PlayerPosition(3, 3);

            string[] rawData = new string[Labyrinth.LabyrinthSize]
            {
                "XXXXXXX",
                "X-X---X",
                "X---X-X",
                "X--*--X",
                "X-X----",
                "X-----X",
                "XXXXXXX"
            };

            Cell[,] board = LabyrinthDataFromStringArray(rawData);

            Labyrinth labyrinth = new Labyrinth(startPosition, board);

            var privateObject = new PrivateObject(labyrinth);
            int x = 3;
            int y = 3;
            privateObject.Invoke("ProcessMove", "exit", x, y);

            Assert.AreEqual(false, labyrinth.IsRunning);
        }

        [TestMethod]
        public void PlayerCommandTopTest()
        {
            PlayerPosition startPosition = new PlayerPosition(3, 3);

            string[] rawData = new string[Labyrinth.LabyrinthSize]
            {
                "XXXXXXX",
                "X-X---X",
                "X---X-X",
                "X--*--X",
                "X-X----",
                "X-----X",
                "XXXXXXX"
            };

            Cell[,] board = LabyrinthDataFromStringArray(rawData);

            Labyrinth labyrinth = new Labyrinth(startPosition, board);

            var privateObject = new PrivateObject(labyrinth);

            ScoreBoard scoreBoard = new ScoreBoard();
            scoreBoard.AddNewScore(4, "Pesho");
            scoreBoard.AddNewScore(7, "Gosho");
            scoreBoard.AddNewScore(5, "Dragan");
            labyrinth.ScoreBoard = scoreBoard;
            string actual = labyrinth.ScoreBoard.ToString();
            string expected = @"
Top 5:

1. Pesho ---> 4 moves
2. Dragan ---> 5 moves
3. Gosho ---> 7 moves


";
            int x = 3;
            int y = 3;
            privateObject.Invoke("ProcessMove", "top", x, y);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "The board cannot be null")]
        public void LabyrinthConstructorNullTest()
        {
            Labyrinth labyrinth = new Labyrinth(new PlayerPosition(0, 0), null);
        }

        [TestMethod]
        public void ValidRandomGenerate()
        {
            PlayerPosition startPosition = new PlayerPosition(3, 3);

            string[] rawData = new string[Labyrinth.LabyrinthSize]
            {
                "XXXXXXX",
                "X-X---X",
                "X---X-X",
                "X--*--X",
                "X-X----",
                "X-----X",
                "XXXXXXX"
            };

            Cell[,] board = LabyrinthDataFromStringArray(rawData);

            Labyrinth labyrinth = new Labyrinth(startPosition, board);

            var privateObject = new PrivateObject(labyrinth);

            privateObject.Invoke("Generate");

            string result =
                @"X X X X X X X 
X - X - - - X 
X - - - X - X 
X - - * - - X 
X - X - - - - 
X - - - - - X 
X X X X X X X 
";
            string expected = labyrinth.ToString();
            Assert.AreNotEqual(labyrinth.ToString(), result);
        }
    }
}