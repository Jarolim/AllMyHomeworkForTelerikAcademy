using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Labyrinth.Tests
{
    [TestClass]
    public class CellTests
    {
        [TestMethod]
        public void CellGetterValueTest()
        {
            int row = 3;
            int column = 3;
            char value = '-';
            Cell cell = new Cell(row, column, value);

            Assert.AreEqual(cell.Value, value);
        }

        [TestMethod]
        public void CellGetterRowTest()
        {
            int row = 3;
            int column = 3;
            char value = '-';
            Cell cell = new Cell(row, column, value);

            Assert.AreEqual(cell.Row, row);
        }

        [TestMethod]
        public void CellGetterColumnTest()
        {
            int row = 3;
            int column = 3;
            char value = '-';
            Cell cell = new Cell(row, column, value);

            Assert.AreEqual(cell.Column, column);
        }

        [TestMethod]
        public void CellCloneTest()
        {
            int row = 3;
            int column = 3;
            char value = '-';
            Cell cell = new Cell(row, column, value);

            Assert.IsTrue(cell.Equals(cell.Clone()));
        }
    }
}
