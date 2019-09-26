using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SQAT.XP;

namespace SQAT.Tests.XP
{
    [TestClass]
    public class XPCalculatorTests
    {
        private const double Dif = 0.00001;

        #region Functions

        #region Test data

        /// <summary>
        /// Testing data for the function PressPlus
        /// </summary>
        public static IEnumerable<object[]> PressPlusDataTesting
        {
            get
            {
                yield return new object[] { 1, 1, 2 };
                yield return new object[] { 1, -1, 0 };
                yield return new object[] { -1, 1, 0 };
                yield return new object[] { -10, 1, -9 };
                yield return new object[] { -10.11, 1.9, -8.21 };
            }
        }

        /// <summary>
        /// Testing data for the function PressMinus
        /// </summary>
        public static IEnumerable<object[]> PressMinusDataTesting
        {
            get
            {
                yield return new object[] { 1, 1, 0 };
                yield return new object[] { 1, -1, 2 };
                yield return new object[] { -1, 1, -2 };
                yield return new object[] { -10, 1, -11 };
                yield return new object[] { -10.11, 1.9, -12.01 };
            }
        }

        /// <summary>
        /// Testing data for the function PressMultiply
        /// </summary>
        public static IEnumerable<object[]> PressMultiplyDataTesting
        {
            get
            {
                yield return new object[] { 1, 1, 1 };
                yield return new object[] { 1, -1, -1 };
                yield return new object[] { -1, 1, -1 };
                yield return new object[] { -10, -1, 10 };
                yield return new object[] { -10.11, 1.9, -19.209 };
                yield return new object[] { -10.11, 0, 0 };
                yield return new object[] { 0, -12, 0 };
            }
        }

        /// <summary>
        /// Testing data for the function PressDivide
        /// </summary>
        public static IEnumerable<object[]> PressDivideDataTesting
        {
            get
            {
                yield return new object[] { 1, 1, 1 };
                yield return new object[] { 1, -1, -1 };
                yield return new object[] { -1, 1, -1 };
                yield return new object[] { -10, -1, 10 };
                yield return new object[] { -10.11, 1.9, -5.32105 };
                yield return new object[] { 0, 1.9, 0 };
            }
        }

        /// <summary>
        /// Testing data for the function PressDisplay
        /// </summary>
        public static IEnumerable<object[]> PressDisplayDataTesting
        {
            get
            {
                yield return new object[] { 1, 1 };
                yield return new object[] { -1, -1 };
                yield return new object[] { 2.1, 2.1 };
                yield return new object[] { -10.12, -10.12 };
                yield return new object[] { 0, 0 };
            }
        }

        #endregion

        /// <summary>
        /// Testing function PressDisplay
        /// </summary>
        /// <param name="a">first param</param>
        /// <param name="expected">expected result</param>
        [DataTestMethod]
        [DynamicData(nameof(PressDisplayDataTesting))]
        [TestCategory("OutputDataWithFunctions")]
        public void PressDisplayOneItem(double a, double expected)
        {
            // Act.
            var calculator = new Calculator();
            calculator.PressDisplay(a);
            calculator.PressEnter();
            var actual = calculator.Display;
            // Assert
            Assert.AreEqual(Math.Abs(expected - actual) < Dif, true);
        }

        /// <summary>
        /// Testing function PressPlus
        /// </summary>
        /// <param name="a">first param</param>
        /// <param name="b">second param</param>
        /// <param name="expected">expected result</param>
        [DataTestMethod]
        [DynamicData(nameof(PressPlusDataTesting))]
        [TestCategory("Functions")]
        public void PressPlusTwoItem(double a, double b, double expected)
        {
            // Act.
            var calculator = new Calculator();
            calculator.PressDisplay(a);
            calculator.PressPlus();
            calculator.PressDisplay(b);
            calculator.PressEnter();
            var actual = calculator.Display;
            // Assert
            Assert.AreEqual(Math.Abs(expected - actual) < Dif, true);
        }

        /// <summary>
        /// Testing function PressDivide
        /// </summary>
        /// <param name="a">first param</param>
        /// <param name="b">second param</param>
        /// <param name="expected">expected result</param>
        [DataTestMethod]
        [DynamicData(nameof(PressMinusDataTesting))]
        [TestCategory("Functions")]
        public void PressMinusTwoItem(double a, double b, double expected)
        {
            // Act.
            var calculator = new Calculator();
            calculator.PressDisplay(a);
            calculator.PressMinus();
            calculator.PressDisplay(b);
            calculator.PressEnter();
            var actual = calculator.Display;
            // Assert
            Assert.AreEqual(Math.Abs(expected - actual) < Dif, true);
        }

        /// <summary>
        /// Testing function PressMultiply
        /// </summary>
        /// <param name="a">first param</param>
        /// <param name="b">second param</param>
        /// <param name="expected">expected result</param>
        [DataTestMethod]
        [DynamicData(nameof(PressMultiplyDataTesting))]
        [TestCategory("Functions")]
        public void PressMultiplyTwoItem(double a, double b, double expected)
        {
            // Act.
            var calculator = new Calculator();
            calculator.PressDisplay(a);
            calculator.PressMultiply();
            calculator.PressDisplay(b);
            calculator.PressEnter();
            var actual = calculator.Display;
            // Assert
            Assert.AreEqual(Math.Abs(expected - actual) < Dif, true);
        }

        /// <summary>
        /// Testing function PressDivide
        /// </summary>
        /// <param name="a">first param</param>
        /// <param name="b">second param</param>
        /// <param name="expected">expected result</param>
        [DataTestMethod]
        [DynamicData(nameof(PressDivideDataTesting))]
        [TestCategory("Functions")]
        public void PressDivideTwoItem(double a, double b, double expected)
        {
            // Act.
            var calculator = new Calculator();
            calculator.PressDisplay(a);
            calculator.PressDivide();
            calculator.PressDisplay(b);
            calculator.PressEnter();
            var actual = calculator.Display;
            // Assert
            Assert.AreEqual(Math.Abs(expected - actual) < Dif, true);
        }

        #endregion

        #region Input data

        [DataTestMethod]
        [DataRow("1", 1)]
        [DataRow("-1", -1)]
        [TestCategory("InputData")]
        public void InputInt32(string a, double expected)
        {
            // Act.
            var actual = DLLibs.Read.DoubleTest(a);
            // Assert
            Assert.AreEqual(Math.Abs(expected - actual) < Dif, true);
        }

        [DataTestMethod]
        [DataRow("1,01", 1.01)]
        [DataRow("-1,01", -1.01)]
        [TestCategory("InputData")]
        public void InputDouble(string a, double expected)
        {
            // Act.
            var actual = DLLibs.Read.DoubleTest(a);
            // Assert
            Assert.AreEqual(Math.Abs(expected - actual) < Dif, true);
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        [TestCategory("InputData")]
        public void InputString()
        {
            // Arrange
            var a = "12aaa";
            // Act.
            DLLibs.Read.DoubleTest(a);
            // Assert
            // var expected = 3;
            // Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [TestCategory("InputData")]
        public void InputZero()
        {
            // Arrange
            var a = "0";
            // Act.
            var actual = DLLibs.Read.DoubleTest(a);
            // Assert
            var expected = 0;
            Assert.AreEqual(Math.Abs(expected - actual) < Dif, true);
        }

        [TestMethod]
        [TestCategory("InputData")]
        [ExpectedException(typeof(DivideByZeroException))]
        public void InputZeroInDivide()
        {
            // Arrange 
            var a = -1;
            var b = 0;
            // Act.
            var calculator = new Calculator();
            calculator.PressDisplay(a);
            calculator.PressDivide();
            calculator.PressDisplay(b);
            calculator.PressEnter();
        }

        #endregion

        #region Out data

        [DataTestMethod]
        [DynamicData(nameof(PressDisplayDataTesting))]
        [TestCategory("OutData")]
        public void AllVariationOfInput(double a, double expected)
        {
            PressDisplayOneItem(a, expected);
        }

        #endregion

        #region Allowable range

        [DataTestMethod]
        [DataRow("12345", 12345)]
        [DataRow("-12345", -12345)]
        [DataRow("1,3456789023456789123456789123456789123456789", 1.3456789023456789123456789123456789123456789)]
        [DataRow("-1,3456789023456789123456789123456789123456789", -1.3456789023456789123456789123456789123456789)]
        [DataRow("123456789123456789123456789123456789,12", 123456789123456789123456789123456789.12)]
        [DataRow("-123456789123456789123456789123456789,12", -123456789123456789123456789123456789.12)]
        [TestCategory("AllowableRange")]
        public void InputNormalCase(string a, double expected)
        {
            // Act.
            var actual = DLLibs.Read.DoubleTest(a);
            // Assert
            Assert.AreEqual(Math.Abs(expected - actual) < Dif, true);
        }

        [DataTestMethod]
        [DataRow(-1234578122345671111, -123457812234567, (-1234578122345671111 - 123457812234567))]
        [DataRow(1234578122345671111, 123457812234567, (123457812234567 + 1234578122345671111))]
        [TestCategory("InputData")]
        public void PressPlusBigData(double a, double b, double expected)
        {
            // Act.
            var calculator = new Calculator();
            calculator.PressDisplay(a);
            calculator.PressPlus();
            calculator.PressDisplay(b);
            calculator.PressEnter();
            var actual = calculator.Display;
            // Assert 
            Assert.AreEqual(Math.Abs(expected - actual) < Dif, true);
        }

        [DataTestMethod]
        [DataRow(1234578122345671111, -123457812234567, (1234578122345671111 + 123457812234567))]
        [DataRow(-1234578122345671111, 123457812234567, (-1234578122345671111 - 123457812234567))]
        [TestCategory("InputData")]
        public void PressMinusBigData(double a, double b, double expected)
        {
            // Act.
            var calculator = new Calculator();
            calculator.PressDisplay(a);
            calculator.PressMinus();
            calculator.PressDisplay(b);
            calculator.PressEnter();
            var actual = calculator.Display;
            // Assert 
            Assert.AreEqual(Math.Abs(expected - actual) < Dif, true);
        }

        [DataTestMethod]
        [DataRow(-1234578122345671111, -123457812234567, (123457812234567.0 * 1234578122345671111.0))]
        [DataRow(1234578122345671111, 123457812234567, (1234578122345671111.0 * 123457812234567.0))]
        [TestCategory("InputData")]
        public void PressMultiplyBigData(double a, double b, double expected)
        {
            // Act.
            var calculator = new Calculator();
            calculator.PressDisplay(a);
            calculator.PressMultiply();
            calculator.PressDisplay(b);
            calculator.PressEnter();
            var actual = calculator.Display;
            // Assert 
            Assert.AreEqual(Math.Abs(expected - actual) < Dif, true);
        }

        #endregion

        #region Length of data

        [DataTestMethod]
        [DataRow(1)]
        [DataRow(2)]
        [DataRow(3)]
        [DataRow(100)]
        [DataRow(1000)]
        [TestCategory("LengthInputData")]
        public void PressPlusLengthInputTesting(int size)
        {
            // Act.
            var calculator = new Calculator();
            Random rnd = new Random(42);
            double expected = 0;
            for (int i = 0; i < size; i++)
            {
                var item = (double)rnd.Next(42);
                expected += item;
                calculator.PressDisplay(item);
                if (i + 1 != size) calculator.PressPlus();
            }
            calculator.PressEnter();
            var actual = calculator.Display;
            // Assert.
            Assert.AreEqual(Math.Abs(expected - actual) < Dif, true);
        }

        [DataTestMethod]
        [DataRow(2)]
        [DataRow(3)]
        [DataRow(100)]
        [DataRow(1000)]
        [TestCategory("LengthInputData")]
        public void PressMinusLengthInputTesting(int size)
        {
            // Act.
            var calculator = new Calculator();
            Random rnd = new Random(42);
            double expected = 0;
            for (int i = 0; i < size; i++)
            {
                var item = (double)rnd.Next(42);
                expected = i == 0
                               ? item
                               : expected - item;
                calculator.PressDisplay(item);
                if (i + 1 != size) calculator.PressMinus();
            }
            calculator.PressEnter();
            var actual = calculator.Display;
            // Assert.
            Assert.AreEqual(Math.Abs(expected - actual) < Dif, true);
        }

        [DataTestMethod]
        [DataRow(1)]
        [DataRow(2)]
        [DataRow(3)]
        [DataRow(15)]
        [TestCategory("LengthInputData")]
        public void PressMultiplyLengthInputTesting(int size)
        {
            // Act.
            var calculator = new Calculator();
            Random rnd = new Random(42);
            double expected = 1;
            for (int i = 0; i < size; i++)
            {
                var item = (double)rnd.Next(6);
                expected *= item;
                calculator.PressDisplay(item);
                if (i + 1 != size) calculator.PressMultiply();
            }
            calculator.PressEnter();
            var actual = calculator.Display;
            // Assert.
            Assert.AreEqual(Math.Abs(expected - actual) < Dif, true);
        }

        [DataTestMethod]
        [DataRow(2)]
        [DataRow(3)]
        [DataRow(25)]
        [TestCategory("LengthInputData")]
        public void PressDivideLengthInputTesting(int size)
        {
            // Act.
            var calculator = new Calculator();
            Random rnd = new Random(42);
            double expected = 1;
            for (int i = 0; i < size; i++)
            {
                var item = (double)rnd.Next(1, 6);
                expected = i == 0
                                ? item
                                : expected / item;
                calculator.PressDisplay(item);
                if (i + 1 != size) calculator.PressDivide();
            }
            calculator.PressEnter();
            var actual = calculator.Display;
            // Assert.
            Assert.AreEqual(Math.Abs(expected - actual) < Dif, true);
        }

        #endregion

        #region Order of data

        #region Plus first

        [TestMethod]
        [TestCategory("OrderOfData")]
        public void PressPlusMinusTwoItem()
        {
            // Arrange
            var a = 1;
            var b = 2;
            var c = -3;
            // Act.
            var calculator = new Calculator();
            calculator.PressDisplay(a);
            calculator.PressPlus();
            calculator.PressDisplay(b);
            calculator.PressMinus();
            calculator.PressDisplay(c);
            calculator.PressEnter();
            var actual = calculator.Display;
            // Assert
            var expected = 6;
            Assert.AreEqual(Math.Abs(expected - actual) < Dif, true);
        }

        [TestMethod]
        [TestCategory("OrderOfData")]
        public void PressPlusDivideTwoItem()
        {
            // Arrange
            var a = 1;
            var b = 2;
            var c = -4;
            // Act.
            var calculator = new Calculator();
            calculator.PressDisplay(a);
            calculator.PressPlus();
            calculator.PressDisplay(b);
            calculator.PressDivide();
            calculator.PressDisplay(c);
            calculator.PressEnter();
            var actual = calculator.Display;
            // Assert
            var expected = 0.5;
            Assert.AreEqual(Math.Abs(expected - actual) < Dif, true);
        }

        [TestMethod]
        [TestCategory("OrderOfData")]
        public void PressPlusMultiplyTwoItem()
        {
            // Arrange
            var a = 1;
            var b = 2;
            var c = -3;
            // Act.
            var calculator = new Calculator();
            calculator.PressDisplay(a);
            calculator.PressPlus();
            calculator.PressDisplay(b);
            calculator.PressMultiply();
            calculator.PressDisplay(c);
            calculator.PressEnter();
            var actual = calculator.Display;
            // Assert
            var expected = -5;
            Assert.AreEqual(Math.Abs(expected - actual) < Dif, true);
        }

        #endregion

        #region Minus first

        [TestMethod]
        [TestCategory("OrderOfData")]
        public void PressMinusPlusTwoItem()
        {
            // Arrange
            var a = 1;
            var b = 2;
            var c = -3;
            // Act.
            var calculator = new Calculator();
            calculator.PressDisplay(a);
            calculator.PressMinus();
            calculator.PressDisplay(b);
            calculator.PressPlus();
            calculator.PressDisplay(c);
            calculator.PressEnter();
            var actual = calculator.Display;
            // Assert
            var expected = -4;
            Assert.AreEqual(Math.Abs(expected - actual) < Dif, true);
        }

        [TestMethod]
        [TestCategory("OrderOfData")]
        public void PressMinusDivideTwoItem()
        {
            // Arrange
            var a = 1;
            var b = 2;
            var c = -4;
            // Act.
            var calculator = new Calculator();
            calculator.PressDisplay(a);
            calculator.PressMinus();
            calculator.PressDisplay(b);
            calculator.PressDivide();
            calculator.PressDisplay(c);
            calculator.PressEnter();
            var actual = calculator.Display;
            // Assert
            var expected = 1.5;
            Assert.AreEqual(Math.Abs(expected - actual) < Dif, true);
        }

        [TestMethod]
        [TestCategory("OrderOfData")]
        public void PressMinusMultiplyTwoItem()
        {
            // Arrange
            var a = 1;
            var b = 2;
            var c = -3;
            // Act.
            var calculator = new Calculator();
            calculator.PressDisplay(a);
            calculator.PressMinus();
            calculator.PressDisplay(b);
            calculator.PressMultiply();
            calculator.PressDisplay(c);
            calculator.PressEnter();
            var actual = calculator.Display;
            // Assert
            var expected = 7;
            Assert.AreEqual(Math.Abs(expected - actual) < Dif, true);
        }

        #endregion

        #region Divide first

        [TestMethod]
        [TestCategory("OrderOfData")]
        public void PressDivideMinusTwoItem()
        {
            // Arrange
            var a = 1;
            var b = 2;
            var c = -3;
            // Act.
            var calculator = new Calculator();
            calculator.PressDisplay(a);
            calculator.PressDivide();
            calculator.PressDisplay(b);
            calculator.PressMinus();
            calculator.PressDisplay(c);
            calculator.PressEnter();
            var actual = calculator.Display;
            // Assert
            var expected = 3.5;
            Assert.AreEqual(Math.Abs(expected - actual) < Dif, true);
        }

        [TestMethod]
        [TestCategory("OrderOfData")]
        public void PressDividePlusTwoItem()
        {
            // Arrange
            var a = 1;
            var b = 2;
            var c = -3;
            // Act.
            var calculator = new Calculator();
            calculator.PressDisplay(a);
            calculator.PressDivide();
            calculator.PressDisplay(b);
            calculator.PressPlus();
            calculator.PressDisplay(c);
            calculator.PressEnter();
            var actual = calculator.Display;
            // Assert
            var expected = -2.5;
            Assert.AreEqual(Math.Abs(expected - actual) < Dif, true);
        }

        [TestMethod]
        [TestCategory("OrderOfData")]
        public void PressDivideMultiplyTwoItem()
        {
            // Arrange
            var a = 1;
            var b = 2;
            var c = -3;
            // Act.
            var calculator = new Calculator();
            calculator.PressDisplay(a);
            calculator.PressDivide();
            calculator.PressDisplay(b);
            calculator.PressMultiply();
            calculator.PressDisplay(c);
            calculator.PressEnter();
            var actual = calculator.Display;
            // Assert
            var expected = -1.5;
            Assert.AreEqual(Math.Abs(expected - actual) < Dif, true);
        }

        #endregion

        #region Multiply first

        [TestMethod]
        [TestCategory("OrderOfData")]
        public void PressMultiplyMinusTwoItem()
        {
            // Arrange
            var a = 2;
            var b = 2;
            var c = -3;
            // Act.
            var calculator = new Calculator();
            calculator.PressDisplay(a);
            calculator.PressPlus();
            calculator.PressDisplay(b);
            calculator.PressMinus();
            calculator.PressDisplay(c);
            calculator.PressEnter();
            var actual = calculator.Display;
            // Assert
            var expected = 7;
            Assert.AreEqual(Math.Abs(expected - actual) < Dif, true);
        }

        [TestMethod]
        [TestCategory("OrderOfData")]
        public void PressMultiplyPlusTwoItem()
        {
            // Arrange
            var a = 2;
            var b = 2;
            var c = -3;
            // Act.
            var calculator = new Calculator();
            calculator.PressDisplay(a);
            calculator.PressMultiply();
            calculator.PressDisplay(b);
            calculator.PressPlus();
            calculator.PressDisplay(c);
            calculator.PressEnter();
            var actual = calculator.Display;
            // Assert
            var expected = 1;
            Assert.AreEqual(Math.Abs(expected - actual) < Dif, true);
        }

        [TestMethod]
        [TestCategory("OrderOfData")]
        public void PressMultiplyDivideTwoItem()
        {
            // Arrange
            var a = 2;
            var b = 2;
            var c = -4;
            // Act.
            var calculator = new Calculator();
            calculator.PressDisplay(a);
            calculator.PressMultiply();
            calculator.PressDisplay(b);
            calculator.PressDivide();
            calculator.PressDisplay(c);
            calculator.PressEnter();
            var actual = calculator.Display;
            // Assert
            var expected = -1;
            Assert.AreEqual(Math.Abs(expected - actual) < Dif, true);
        }

        #endregion

        #endregion
    }
}
