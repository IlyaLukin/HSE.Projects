using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SQAT.UnitTesting.UnitTesting_1;

namespace SQAT.Tests.UnitTesting_1
{
    [TestClass]
    public class QuadraticSolutionTests
    {
        #region Input

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void QuadraticSolution_inputFirstNULL() {
            // Arrange
            // var input = null;
            // Act.
            QuadraticSolution.DoTaskTest(null, "1", "2");
            // Assert
            // var expected = 0;
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void QuadraticSolution_inputSecondNULL() {
            // Arrange
            // var input = null;
            // Act.
            QuadraticSolution.DoTaskTest("1", null, "2");
            // Assert
            // var expected = 0;
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void QuadraticSolution_inputThirdNULL() {
            // Arrange
            // var input = null;
            // Act.
            QuadraticSolution.DoTaskTest("2", "1", null);
            // Assert
            // var expected = 0;
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void QuadraticSolution_inputFirstEmpty() {
            // Arrange
            // var input = null;
            // Act.
            QuadraticSolution.DoTaskTest("", "1", "2");
            // Assert
            // var expected = 0;
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void QuadraticSolution_inputSecondEmpty() {
            // Arrange
            // var input = null;
            // Act.
            QuadraticSolution.DoTaskTest("1", "", "2");
            // Assert
            // var expected = 0;
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void QuadraticSolution_inputThirdEmpty() {
            // Arrange
            // var input = null;
            // Act.
            QuadraticSolution.DoTaskTest("2", "1", "");
            // Assert
            // var expected = 0;
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void QuadraticSolution_inputFirstNonDigit() {
            // Arrange
            // var input = null;
            // Act.
            QuadraticSolution.DoTaskTest("a", "1", "2");
            // Assert
            // var expected = 0;
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void QuadraticSolution_inputSecondNonDigit() {
            // Arrange
            // var input = null;
            // Act.
            QuadraticSolution.DoTaskTest("1", "a", "2");
            // Assert
            // var expected = 0;
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void QuadraticSolution_inputThirdNonDigit() {
            // Arrange
            // var input = null;
            // Act.
            QuadraticSolution.DoTaskTest("2", "1", "a");
            // Assert
            // var expected = 0;
        }

        #endregion

        #region Func

        [TestMethod]
        public void QuadraticSolution_inputAllZeros()
        {
            // Arrange
            var inputA = "0";
            var inputB = "0";
            var inputC = "0";
            // Act.
            var actual = QuadraticSolution.DoTaskTest(inputA, inputB, inputC);
            // Assert
            var expected = "Inf.";
            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void QuadraticSolution_inputFirstTwoZeros()
        {
            // Arrange
            var inputA = "0";
            var inputB = "0";
            var inputC = "12";
            // Act.
            var actual = QuadraticSolution.DoTaskTest(inputA, inputB, inputC);
            // Assert
            var expected = "No sol.";
            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void QuadraticSolution_inputFirstZero()
        {
            // Arrange
            var inputA = "0";
            var inputB = "12";
            var inputC = "12";
            // Act.
            var actual = QuadraticSolution.DoTaskTest(inputA, inputB, inputC);
            // Assert
            var expected = "x = -1";
            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void QuadraticSolution_resultComplex()
        {
            // Arrange
            var inputA = "24";
            var inputB = "12";
            var inputC = "12";
            // Act.
            var actual = QuadraticSolution.DoTaskTest(inputA, inputB, inputC);
            // Assert
            var expected = "No sol. (complex value can be)";
            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void QuadraticSolution_twoRepeatableValues()
        {
            // Arrange
            var inputA = "1";
            var inputB = "-4";
            var inputC = "4";
            // Act.
            var actual = QuadraticSolution.DoTaskTest(inputA, inputB, inputC);
            // Assert
            var expected = "x1 = x2 = 2";
            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void QuadraticSolution_inputSecondTwoZeros()
        {
            // Arrange
            var inputA = "1";
            var inputB = "0";
            var inputC = "0";
            // Act.
            var actual = QuadraticSolution.DoTaskTest(inputA, inputB, inputC);
            // Assert
            var expected = "x1 = x2 = 0";
            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void QuadraticSolution_inputFirstAndThirdZeros()
        {
            // Arrange
            var inputA = "0";
            var inputB = "5";
            var inputC = "0";
            // Act.
            var actual = QuadraticSolution.DoTaskTest(inputA, inputB, inputC);
            // Assert
            var expected = "x = 0";
            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void QuadraticSolution_inputSecondZero()
        {
            // Arrange
            var inputA = "1";
            var inputB = "0";
            var inputC = "-4";
            // Act.
            var actual = QuadraticSolution.DoTaskTest(inputA, inputB, inputC);
            // Assert
            var expected = "x1 = -2; x2 = 2";
            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void QuadraticSolution_inputDoubleNegative()
        {
            // Arrange
            var inputA = "-1,3";
            var inputB = "1,5";
            var inputC = "4,09";
            // Act.
            var actual = QuadraticSolution.DoTaskTest(inputA, inputB, inputC);
            // Assert
            var expected = "x1 = 2,442; x2 = -1,288";
            Assert.AreEqual(actual, expected);
        }

        #endregion
    }
}
