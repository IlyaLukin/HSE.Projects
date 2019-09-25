using System;
using DLLibs;
using SQAT.UnitTesting.UnitTesting_1;

namespace SQAT.UnitTesting
{
    internal class Program
    {
        private static readonly string[] MenuItems =
            {
                "Task 1. Delete every second value from the array.",
                "Task 2. Quadratic solutions.",
                "Task 3. Is beat queen?",
                "Exit."
            };

        private static void Main()
        {
            while (true)
            {
                var indexOfMenuItem = Print.Menu(0, MenuItems);
                switch (indexOfMenuItem)
                {
                    case 1:
                    {
                        ArrayManipulating.DoTask();
                        break;
                    }
                    case 2:
                    {
                        QuadraticSolution.DoTask();
                        break;
                    }
                    case 3:
                    {
                        IsBeatQueen.DoTask();
                        break;
                    }
                    default: return;
                }

                Console.Write("Для продолжения нажмите любую клавишу . . .");
                Console.ReadKey();
            }
        }
    }
}