using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Matrix;
namespace MatrixTests

{
    [TestClass]
    public class MatrixTests
    {
        [TestMethod]
        public void MatrixInitialize()
        {
            int[,] test = { { 1, 2, 3 }, { 1, 2, 3 }, { 1, 2, 3 } };
            Matrix<int> testMatrix = new Matrix<int>(test);
            CollectionAssert.AreEqual(test, testMatrix.PullMatrix());            
        }

        [TestMethod]
        public void MatrixInitializeFloat()
        {
            float[,] test = { { 1, 2, 3 }, { 1, 2, 3 }, { 1, 2, 3 } };
            Matrix<float> testMatrix = new Matrix<float>(test);
            CollectionAssert.AreEqual(test, testMatrix.PullMatrix() );
        }

        [TestMethod]
        public void MatrixInitializeEmpty()
        {
            Matrix<int> testMatrix = new Matrix<int>(2,2);
            testMatrix[1, 1] = 5;
            int t = testMatrix[1,1];
            Assert.AreEqual(5, t);
        }
    }
}
