using System;
using DLLibs;

namespace SQAT.UnitTesting.UnitTesting_1
{
    public class QuadraticSolution
    {
        /// <summary>
        /// Do task in normal case
        /// </summary>
        public static void DoTask()
        {
            var a = Read.Double("Insert first coefficient");
            var b = Read.Double("Insert second coefficient");
            var c = Read.Double("Insert third coefficient");
            var solution = Solve(a, b, c);
            Console.Write("Solution: ");
            switch (solution[0])
            {
                case -3:
                    {
                        Console.Write("Inf.");
                        break;
                    }
                case -2:
                    {
                        Console.Write("No sol.");
                        break;
                    }
                case -1:
                    {
                        Console.Write("{0}", solution[1]);
                        break;
                    }
                case 0:
                    {
                        Console.Write("No sol.");
                        break;
                    }
                case 1:
                    {
                        Console.Write("{0}", solution[1]);
                        break;
                    }
                case 2:
                    {
                        Console.Write("x1={0}; x2={1}", solution[1], solution[2]);
                        break;
                    }
            }
        }

        /// <summary>
        /// Do task in test env.
        /// </summary>
        public static string DoTaskTest(string inputA, string inputB, string inputC)
        {
            var a = Read.DoubleTest(inputA);
            var b = Read.DoubleTest(inputB);
            var c = Read.DoubleTest(inputC);
            var solution = Solve(a, b, c);
            switch (solution[0])
            {
                case -3: return "Inf.";
                case -2: return "No sol.";
                case -1: return $"x = {solution[1]}";
                case 0: return "No sol. (complex value can be)";
                case 1: return $"x1 = x2 = {Math.Round(solution[1], 3)}";
                case 2: return $"x1 = {Math.Round(solution[1], 3)}; x2 = {Math.Round(solution[2], 3)}";
            }

            return null;
        }


        /// <summary>
        ///     Find quadratic solution
        /// </summary>
        /// <param name="a">First k</param>
        /// <param name="b">Second k</param>
        /// <param name="c">Third k</param>
        /// <returns>
        ///     Return array (len = 3):
        ///     [0]=2 - 2 real roots
        ///     [0]=1 - 1 real root
        ///     [0]=0 - no roots
        ///     [0]=-1 - one real root (a==0)
        ///     [0]=-2 - no root (a==0; b==0)
        ///     [0]=-3 - inf (a==b==c==0)
        /// </returns>
        private static double[] Solve(double a, double b, double c)
        {
            var solution = new double[3];
            //case smth equal zero
            if (Math.Abs(a) <= 0)
            {
                if (Math.Abs(b) <= 0)
                {
                    if (Math.Abs(c) <= 0)
                    {
                        solution[0] = -3;
                        return solution;
                    }

                    solution[0] = -2;
                    return solution;
                }

                solution[0] = -1;
                solution[1] = -c / b;
                return solution;
            }

            //main case
            var d = Math.Pow(b, 2) - 4 * a * c;

            if (Math.Abs(d) <= 0)
            {
                solution[0] = 1;
                solution[1] =
                    solution[1] =
                        -b / (2 * a);
                return solution;
            }

            //complex case
            if (d < 0)
            {
                solution[0] = 0;
                return solution;
            }

            if (b >= 0) d = -0.5 * (b + Math.Sqrt(d));
            else d = -0.5 * (b - Math.Sqrt(d));

            solution[0] = 2;
            solution[1] = d / a;
            solution[2] = c / d;
            return solution;
        }
    }
}