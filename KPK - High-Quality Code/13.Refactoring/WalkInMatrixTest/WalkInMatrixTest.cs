using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RotatingMatrix;

namespace Matrix.Tests
{
	[TestClass]
	public class WalkInMatrixTest
	{
        [TestMethod]
        public void ToStringTestSide6()
        {
            int n = 6;
            WalkInMatrix matrixActual = new WalkInMatrix(n);
            string expected = "   1  16  17  18  19  20\r\n" +
                               "  15   2  27  28  29  21\r\n" +
                               "  14  31   3  26  30  22\r\n" +
                               "  13  36  32   4  25  23\r\n" +
                               "  12  35  34  33   5  24\r\n" +
                               "  11  10   9   8   7   6\r\n";

            string actual = matrixActual.ToString();

            Assert.AreEqual(expected, actual);
        }
	}
}
