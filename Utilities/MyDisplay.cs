using System;
using TaskManager.Models;

namespace TaskManager.Utilities
{
    public partial class MyDisplay
    {
        public static void Menu()
        {
            Console.BackgroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("\nTo-Do List: \n");
            Console.ResetColor();

            Console.WriteLine("1. Watch your list");
            Console.WriteLine("2. Add task to list");
            Console.WriteLine("3. Edit your task");
            Console.WriteLine("4. Remove task from list");
            Console.WriteLine();
        }

        public static void Task(Task doList)
        {
            Console.WriteLine();
            Console.WriteLine("Task List: ");
            Console.WriteLine("--------------------");
            Console.WriteLine($"Id: {doList.Id} - Task: {doList.Title}");
        }

        public static void Success()
        {

        }
    }
}
