using System;

namespace DLLibs
{
    public class Print
    {
        /// <summary>
        ///     Print menu to Console
        /// </summary>
        /// <param name="skipMenuItemsPerStep">How many items of the menu items will be skipped</param>
        /// <param name="menuItemsArray">Array of the menu items</param>
        /// <returns>Index of the menu item</returns>
        public static int Menu(int skipMenuItemsPerStep, params string[] menuItemsArray)
        {
            Console.Clear();
            Console.CursorVisible = false;
            var y = 1;
            int tek = 0,
                tekOld = 0;
            var x = 1;
            var ok = false;
            for (var i = 0;
                 i < menuItemsArray.Length;
                 i++)
            {
                Console.SetCursorPosition(x, y + i);
                if (i % (skipMenuItemsPerStep + 1) == 0)
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.BackgroundColor = ConsoleColor.Black;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.BackgroundColor = ConsoleColor.Black;
                }

                Console.Write(menuItemsArray[i]);
            }

            do
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.BackgroundColor = ConsoleColor.Black;
                Console.SetCursorPosition(x, y + tekOld);
                Console.Write(menuItemsArray[tekOld] + " ");
                Console.ForegroundColor = ConsoleColor.Black;
                Console.BackgroundColor = ConsoleColor.White;
                Console.SetCursorPosition(x, y + tek);
                Console.Write(menuItemsArray[tek]);
                tekOld = tek;
                var key = Console.ReadKey();
                switch (key.Key)
                {
                    case ConsoleKey.DownArrow:
                        tek += skipMenuItemsPerStep + 1;
                        break;
                    case ConsoleKey.UpArrow:
                        tek -= skipMenuItemsPerStep + 1;
                        break;
                    case ConsoleKey.Enter:
                        ok = true;
                        break;
                }

                if (tek >= menuItemsArray.Length) tek = 0;
                else if (tek < 0) tek = menuItemsArray.Length - 1;
            } while (!ok);

            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Clear();
            return tek + 1;
        }

        /// <summary>
        ///     Print array to Console
        /// </summary>
        /// <param name="printedArray">Array to out to Console</param>
        public static void Array(Array printedArray)
        {
            foreach (var valueInArray in printedArray) Console.Write("{0} ", valueInArray);

            Console.WriteLine();
        }
    }
}