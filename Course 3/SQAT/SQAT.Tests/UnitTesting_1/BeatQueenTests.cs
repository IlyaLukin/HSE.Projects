using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SQAT.UnitTesting.UnitTesting_1;

namespace SQAT.Tests.UnitTesting_1
{
    [TestClass]
    public class BeatQueenTests
    {
        #region Input

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void DeleteEverySecond_inputNumberOfQueenNULL()
        {
            // Arrange
            // var input = null;
            // Act.
            IsBeatQueen.DoTaskTest(null);
            // Assert
            // var expected = 0;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void DeleteEverySecond_inputXNegative()
        {
            // Arrange
            var inputN = "1";
            var inputCoordinates = new[] { "-1", "2" };
            // Act.
            IsBeatQueen.DoTaskTest(inputN, inputCoordinates);
            // Assert
            // var expected = 0;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void DeleteEverySecond_inputYNegative()
        {
            // Arrange
            var inputN = "1";
            var inputCoordinates = new[] { "4", "-2" };
            // Act.
            IsBeatQueen.DoTaskTest(inputN, inputCoordinates);
            // Assert
            // var expected = 0;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void DeleteEverySecond_inputXZero()
        {
            // Arrange
            var inputN = "1";
            var inputCoordinates = new[] { "0", "4" };
            // Act.
            IsBeatQueen.DoTaskTest(inputN, inputCoordinates);
            // Assert
            // var expected = 0;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void DeleteEverySecond_inputXMoreThanEight()
        {
            // Arrange
            var inputN = "1";
            var inputCoordinates = new[] { "10", "4" };
            // Act.
            IsBeatQueen.DoTaskTest(inputN, inputCoordinates);
            // Assert
            // var expected = 0;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void DeleteEverySecond_inputYZero()
        {
            // Arrange
            var inputN = "1";
            var inputCoordinates = new[] { "4", "0" };
            // Act.
            IsBeatQueen.DoTaskTest(inputN, inputCoordinates);
            // Assert
            // var expected = 0;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void DeleteEverySecond_inputYMoreThanEight()
        {
            // Arrange
            var inputN = "1";
            var inputCoordinates = new[] { "4", "14" };
            // Act.
            IsBeatQueen.DoTaskTest(inputN, inputCoordinates);
            // Assert
            // var expected = 0;
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void DeleteEverySecond_inputNumberOfQueenDouble()
        {
            // Arrange
            var input = "1,3";
            // Act.
            IsBeatQueen.DoTaskTest(input);
            // Assert
            // var expected = 0;
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void DeleteEverySecond_inputNumberOfQueenString()
        {
            // Arrange
            var input = "a";
            // Act.
            IsBeatQueen.DoTaskTest(input);
            // Assert
            // var expected = 0;
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void DeleteEverySecond_inputNumberOfQueenZero()
        {
            // Arrange
            var input = "0";
            // Act.
            IsBeatQueen.DoTaskTest(input);
            // Assert
            // var expected = 0;
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void DeleteEverySecond_inputXCoordinateNULL()
        {
            // Arrange
            var inputN = "2";
            var inputCoordinates = new[] { null, "1", "2", "3" };
            // Act.
            IsBeatQueen.DoTaskTest(inputN, inputCoordinates);
            // Assert
            // var expected = 0;
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void DeleteEverySecond_inputYCoordinateNULL()
        {
            // Arrange
            var inputN = "2";
            var inputCoordinates = new[] { "1", null, "2", "3" };
            // Act.
            IsBeatQueen.DoTaskTest(inputN, inputCoordinates);
            // Assert
            // var expected = 0;
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void DeleteEverySecond_inputYCoordinateEmpty()
        {
            // Arrange
            var inputN = "2";
            var inputCoordinates = new[] { "1", "", "2", "3" };
            // Act.
            IsBeatQueen.DoTaskTest(inputN, inputCoordinates);
            // Assert
            // var expected = 0;
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void DeleteEverySecond_inputXCoordinateEmpty()
        {
            // Arrange
            var inputN = "2";
            var inputCoordinates = new[] { "", "1", "3", "4" };
            // Act.
            IsBeatQueen.DoTaskTest(inputN, inputCoordinates);
            // Assert
            // var expected = 0;
        }

        #endregion

        #region Func

        [TestMethod]
        public void DeleteEverySecond_inputSizeOne()
        {
            // Arrange
            var inputN = "1";
            var inputCoordinates = new[] { "1", "1" };
            // Act.
            var actual = IsBeatQueen.DoTaskTest(inputN, inputCoordinates);
            // Assert
            var expected = "NO";
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void DeleteEverySecond_inputOneLineX()
        {
            // Arrange
            var inputN = "2";
            var inputCoordinates = new[] { "1", "1", "1", "2" };
            // Act.
            var actual = IsBeatQueen.DoTaskTest(inputN, inputCoordinates);
            // Assert
            var expected = "YES";
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void DeleteEverySecond_inputOneLineY()
        {
            // Arrange
            var inputN = "2";
            var inputCoordinates = new[] { "1", "1", "2", "1" };
            // Act.
            var actual = IsBeatQueen.DoTaskTest(inputN, inputCoordinates);
            // Assert
            var expected = "YES";
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void DeleteEverySecond_inputDiagonalQueens()
        {
            // Arrange
            var inputN = "2";
            var inputCoordinates = new[] { "1", "1", "3", "3" };
            // Act.
            var actual = IsBeatQueen.DoTaskTest(inputN, inputCoordinates);
            // Assert
            var expected = "YES";
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void DeleteEverySecond_inputForAnswerNo()
        {
            // Arrange
            var inputN = "2";
            var inputCoordinates = new[] { "1", "1", "4", "3" };
            // Act.
            var actual = IsBeatQueen.DoTaskTest(inputN, inputCoordinates);
            // Assert
            var expected = "NO";
            Assert.AreEqual(expected, actual);
        }

        #endregion
    }
}
