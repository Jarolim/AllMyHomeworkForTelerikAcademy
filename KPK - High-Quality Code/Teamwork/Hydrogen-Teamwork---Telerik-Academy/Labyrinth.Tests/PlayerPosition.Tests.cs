using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Labyrinth.Tests
{
	[TestClass]
	public class PlayerPositionTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "The value cannot be negative")]
        public void SetPositionYNegativeTest()
        {
            PlayerPosition position = new PlayerPosition(-2, 2);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "The value cannot be negative")]
        public void SetPositionXNegativeTest()
        {
            PlayerPosition position = new PlayerPosition(2,-2);
        }
    }
}