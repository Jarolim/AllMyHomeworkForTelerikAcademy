using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CountNumberInArray;
namespace TestCountNumber
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestWithOne()
        {
            int[] numbers = { 1, 1, 2, 2, 3, 3, 5, 5, 4, 4, 4, 7, 8, 8, 9, 9, 9 };
            int res = CountNumbersInArray.CountNumber(1, numbers);
            Assert.AreEqual(2, res);
        }
        [TestMethod]
        public void TestWithTwo()
        {
            int[] numbers = { 1, 1, 2, 2, 3, 3, 5, 5, 4, 4, 4, 7, 8, 8, 9, 9, 9 };
            int res = CountNumbersInArray.CountNumber(2, numbers);
            Assert.AreEqual(2, res);
        }
        [TestMethod]
        public void TestWithThree()
        {
            int[] numbers = { 1, 1, 2, 2, 3, 3, 5, 5, 4, 4, 4, 7, 8, 8, 9, 9, 9 };
            int res = CountNumbersInArray.CountNumber(3, numbers);
            Assert.AreEqual(2, res);
        }
        [TestMethod]
        public void TestWithFour()
        {
            int[] numbers = { 1, 1, 2, 2, 3, 3, 5, 5, 4, 4, 4, 7, 8, 8, 9, 9, 9 };
            int res = CountNumbersInArray.CountNumber(4, numbers);
            Assert.AreEqual(3, res);
        }
        [TestMethod]
        public void TestWithFive()
        {
            int[] numbers = { 1, 1, 2, 2, 3, 3, 5, 5, 4, 4, 4, 7, 8, 8, 9, 9, 9 };
            int res = CountNumbersInArray.CountNumber(5, numbers);
            Assert.AreEqual(2, res);
        }
        [TestMethod]
        public void TestWithSix()
        {
            int[] numbers = { 1, 1, 2, 2, 3, 3, 5, 5, 4, 4, 4, 7, 8, 8, 9, 9, 9 };
            int res = CountNumbersInArray.CountNumber(6, numbers);
            Assert.AreEqual(0, res);
        }
        [TestMethod]
        public void TestWithSeven()
        {
            int[] numbers = { 1, 1, 2, 2, 3, 3, 5, 5, 4, 4, 4, 7, 8, 8, 9, 9, 9 };
            int res = CountNumbersInArray.CountNumber(7, numbers);
            Assert.AreEqual(1, res);
        }
        [TestMethod]
        public void TestWithEight()
        {
            int[] numbers = { 1, 1, 2, 2, 3, 3, 5, 5, 4, 4, 4, 7, 8, 8, 9, 9, 9 };
            int res = CountNumbersInArray.CountNumber(8, numbers);
            Assert.AreEqual(2, res);
        }
        [TestMethod]
        public void TestWithNine()
        {
            int[] numbers = { 1, 1, 2, 2, 3, 3, 5, 5, 4, 4, 4, 7, 8, 8, 9, 9, 9 };
            int res = CountNumbersInArray.CountNumber(9, numbers);
            Assert.AreEqual(3, res);
        }
    }
}
