using System;

namespace TaskManager.Utilities
{
    public partial class MyDisplay
    {

        public static void Menu()
        {
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.WriteLine("\nTo-Do List: \n");
            Console.ResetColor();

            Console.WriteLine("1. Add task to list");
            Console.WriteLine("2. Edit your task");
            Console.WriteLine("3. Remove task from list");
            Console.WriteLine();
        }

        public static void Success()
        {
            Console.WriteLine();
            Console.BackgroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("Success");
            Console.ResetColor();
        }
        public static void Failure()
        {
            Console.WriteLine();
            Console.BackgroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("Fail");
            Console.ResetColor();
        }

    }
}
