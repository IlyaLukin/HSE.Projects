using System;

namespace DLLibs
{
    public class Read
    {
        #region Normal Case Func

        /// <summary>
        ///     Input string from Console
        /// </summary>
        /// <param name="message">Message for user</param>
        /// <returns>String value which be inserted into console</returns>
        public static string String(string message)
        {
            Console.Write(message + ": ");
            return Console.ReadLine();
        }

        /// <summary>
        ///     Input Int32 from Console
        /// </summary>
        /// <param name="message">Message for user</param>
        /// <returns>Int32 value which be inserted into console</returns>
        public static int Int32(string message)
        {
            Console.Write(message + ": ");
            var inputStr = Console.ReadLine();
            var isInt32Inserted = int.TryParse(inputStr, out var inputDigit);
            if (isInt32Inserted) return inputDigit;

            throw new FormatException();
        }

        /// <summary>
        ///     Input Int32 from Console
        /// </summary>
        /// <returns>Int32 value which be inserted into console</returns>
        public static int Int32()
        {
            var inputStr = Console.ReadLine();
            var isInt32Inserted = int.TryParse(inputStr, out var inputDigit);
            if (isInt32Inserted) return inputDigit;

            throw new FormatException();
        }

        /// <summary>
        ///     Input Double from Console
        /// </summary>
        /// <param name="message">Message for user</param>
        /// <returns>Double value which be inserted into console</returns>
        public static double Double(string message)
        {
            Console.Write(message + ": ");
            var inputStr = Console.ReadLine();
            var isInt32Inserted = double.TryParse(inputStr, out var inputDigit);
            if (isInt32Inserted) return inputDigit;

            throw new FormatException();
        }

        /// <summary>
        /// Input Int32 Digit between min and max
        /// </summary>
        /// <param name="min">Min</param>
        /// <param name="max">Max</param>
        /// <returns>Inserted Int32 value</returns>
        public static int RangeInt32(int min, int max)
        {
            var inputStr = Console.ReadLine();
            var isInt32Inserted = int.TryParse(inputStr, out var inputDigit);
            if (!isInt32Inserted) throw new FormatException();
            if (inputDigit < min || inputDigit > max) throw new ArgumentOutOfRangeException();

            return inputDigit;
        }

        #endregion

        #region Test Env. Func

        /// <summary>
        /// Input Int32 Digit between min and max in Test Env.
        /// </summary>
        /// <param name="input">Input value</param>
        /// <param name="min">Min</param>
        /// <param name="max">Max</param>
        /// <returns>Inserted Int32 value</returns>
        public static int RangeInt32Test(string input, int min, int max)
        {
            var inputStr = input;
            var isInt32Inserted = int.TryParse(inputStr, out var inputDigit);
            if (!isInt32Inserted) throw new FormatException();
            if (inputDigit < min || inputDigit > max) throw new ArgumentOutOfRangeException();

            return inputDigit;
        }

        /// <summary>
        ///     Input string from Test Env.
        /// </summary>
        /// <param name="input">Input string</param>
        /// <returns>Parsed input value</returns>
        public static string StringTest(string input)
        {
            return input;
        }

        /// <summary>
        ///     Input Int32 from Test Env.
        /// </summary>
        /// <param name="input">Input string</param>
        /// <returns>Parsed input value to Int32</returns>
        public static int Int32Test(string input)
        {
            var inputStr = input;
            var isInt32Inserted = int.TryParse(inputStr, out var inputDigit);
            if (isInt32Inserted) return inputDigit;

            throw new FormatException();
        }

        /// <summary>
        ///     Input Double from Test Env.
        /// </summary>
        /// <param name="input">Input string</param>
        /// <returns>Parsed input value to Double</returns>
        public static double DoubleTest(string input)
        {
            var inputStr = input;
            var isInt32Inserted = double.TryParse(inputStr, out var inputDigit);
            if (isInt32Inserted) return inputDigit;

            throw new FormatException();
        }

        #endregion
    }
}