using System;
using System.Linq;
using DLLibs;

namespace SQAT.UnitTesting.UnitTesting_1
{
    public static class ArrayManipulating
    {
        /// <summary>
        /// Do task in normal mode
        /// </summary>
        public static void DoTask()
        {
            var inputStr = Read.String("Enter Array");
            Print.Array(GetArrayWithDeletedEverySecondDigit(inputStr));
        }

        /// <summary>
        /// Do task in test env.
        /// </summary>
        /// <param name="input">Input test value</param>
        /// <returns>Result of the algorithm</returns>
        public static string[] DoTaskTest(string input)
        {
            var inputStr = Read.StringTest(input);
            return GetArrayWithDeletedEverySecondDigit(inputStr);
        }

        /// <summary>
        ///     Function is converting string to double array with skipping every second digit
        /// </summary>
        /// <param name="inputStr">Input string</param>
        /// <returns>Double array with deleted every second array</returns>
        private static string[] GetArrayWithDeletedEverySecondDigit(string inputStr)
        {
            string[] array;
            try
            {
                var digitCounter = 0;
                array = inputStr.Replace(" ", "")
                                .Split(',')
                                .Where(el => digitCounter++ % 2 == 0)
                                .ToArray();
            }
            catch
            {
                throw new FormatException();
            }

            return array;
        }
    }
}