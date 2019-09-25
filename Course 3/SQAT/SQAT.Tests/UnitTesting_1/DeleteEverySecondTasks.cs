using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SQAT.UnitTesting.UnitTesting_1;

namespace SQAT.Tests.UnitTesting_1
{
    [TestClass]
    public class DeleteEverySecondTests
    {
        private bool CompareTwoStringArrays(string[] first, string[] second)
        {
            if (first.Length != second.Length) return false;

            return !first.Where((t, i) => !t.Equals(second[i])).Any();
        }

        #region Input

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void DeleteEverySecond_inputNULL()
        {
            // Arrange
            // var input = null;
            // Act.
            ArrayManipulating.DoTaskTest(null);
            // Assert
            // var expected = 0;
        }

        [TestMethod]
        public void DeleteEverySecond_inputEmptyString()
        {
            // Arrange
            var input = "";
            // Act.
            var actual = ArrayManipulating.DoTaskTest(input);
            // Assert
            var expected = new[] { "" };
            Assert.AreEqual(true, CompareTwoStringArrays(actual, expected));
        }

        [TestMethod]
        public void DeleteEverySecond_inputWrong()
        {
            // Arrange
            var input = "1;2;3 4,5,5";
            // Act.
            var actual = ArrayManipulating.DoTaskTest(input);
            // Assert
            var expected = new[] { "1;2;34", "5" };
            Assert.AreEqual(true, CompareTwoStringArrays(actual, expected));
        }

        [TestMethod]
        public void DeleteEverySecond_inputDifferentTypes()
        {
            // Arrange
            var input = "1, abc, 4.5, 12, f";
            // Act.
            var actual = ArrayManipulating.DoTaskTest(input);
            // Assert
            var expected = new[] { "1", "4.5", "f" };
            Assert.AreEqual(true, CompareTwoStringArrays(actual, expected));
        }

        #endregion

        #region Func

        [TestMethod]
        public void DeleteEverySecond_inputOneDigit()
        {
            // Arrange
            var input = "1";
            // Act.
            var actual = ArrayManipulating.DoTaskTest(input);
            // Assert
            var expected = new[] { "1" };
            Assert.AreEqual(true, CompareTwoStringArrays(actual, expected));
        }

        [TestMethod]
        public void DeleteEverySecond_inputTwoDigit()
        {
            // Arrange
            var input = "1, 2.5";
            // Act.
            var actual = ArrayManipulating.DoTaskTest(input);
            // Assert
            var expected = new[] { "1" };
            Assert.AreEqual(true, CompareTwoStringArrays(actual, expected));
        }

        [TestMethod]
        public void DeleteEverySecond_inputMany()
        {
            // Arrange
            var input = "1, 2, 3, 4, 5";
            // Act.
            var actual = ArrayManipulating.DoTaskTest(input);
            // Assert
            var expected = new[] { "1", "3", "5" };
            Assert.AreEqual(true, CompareTwoStringArrays(actual, expected));
        }

        #endregion
    }
}
