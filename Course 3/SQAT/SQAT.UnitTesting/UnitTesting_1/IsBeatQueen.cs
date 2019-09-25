using System;
using System.Collections.Generic;
using DLLibs;

namespace SQAT.UnitTesting.UnitTesting_1
{
    public class IsBeatQueen
    {
        /// <summary>
        /// Do task in normal case
        /// </summary>
        public static void DoTask()
        {
            var n = Read.Int32("Insert number of queens");
            if (n == 0) throw new FormatException();

            var x = new int[n];
            var y = new int[n];
            Console.WriteLine("Insert coordinates:");
            for (var i = 0;
                 i < n;
                 i++)
            {
                Console.Write("x[{0}] = ", i + 1);
                x[i] = Read.RangeInt32(1, 8);
                Console.Write("y[{0}] = ", i + 1);
                y[i] = Read.RangeInt32(1, 8);
            }

            Console.WriteLine(!BeatQueen(x, y) ? "YES" : "NO");
        }

        /// <summary>
        /// Do task in test env.
        /// </summary>
        /// <param name="inputN">Number of pairs of coordinates</param>
        /// <param name="inputCoordinates">Input coordinates</param>
        public static string DoTaskTest(string inputN, params string[] inputCoordinates)
        {
            var n = Read.Int32Test(inputN);
            if (n == 0) throw new FormatException();
            var x = new int[n];
            var y = new int[n];

            var coordinateIndex = 0;
            for (var i = 0;
                 i < inputCoordinates.Length;
                 i += 2)
            {
                x[coordinateIndex] = Read.RangeInt32Test(inputCoordinates[i], 1, 8);
                y[coordinateIndex] = Read.RangeInt32Test(inputCoordinates[i + 1], 1, 8);
                coordinateIndex++;
            }

            return !BeatQueen(x, y) ? "YES" : "NO";
        }

        /// <summary>
        ///     Is one of the queen beat another
        /// </summary>
        /// <param name="coordinateX">Array of the queen X</param>
        /// <param name="coordinateY">Array of the queen Y</param>
        /// <returns>
        ///     True/False
        /// </returns>
        private static bool BeatQueen(IReadOnlyList<int> coordinateX, IReadOnlyList<int> coordinateY)
        {
            for (var xIndex = 0;
                 xIndex < coordinateX.Count;
                 xIndex++)
            {
                for (var yIndex = xIndex + 1;
                     yIndex < coordinateY.Count;
                     yIndex++)
                    if (coordinateX[xIndex] == coordinateX[yIndex] ||
                        coordinateY[xIndex] == coordinateY[yIndex] ||
                        Math.Abs(coordinateX[xIndex] - coordinateX[yIndex]) ==
                        Math.Abs(coordinateY[xIndex] - coordinateY[yIndex]))
                        return false;
            }

            return true;
        }
    }
}