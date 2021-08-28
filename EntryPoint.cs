using System;
using TaskManager.DAL;
using TaskManager.Utilities;

namespace TaskManager
{
    public class EntryPoint
    {
        private readonly ITaskRepository _taskRepository;

        public EntryPoint(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        public void Run()
        {
            MyDisplay.Menu();

            Console.BackgroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("Task list: \n");
            Console.ResetColor();
            var items = _taskRepository.GetTasks();
            items.ForEach(item =>
            {
                Console.WriteLine($"[{item.Id}] {item.Title}");
            });

            Console.Write("\nChoose Your Option: ");
            var option = Console.ReadLine();

            switch (option)
            {
                case "0":
                    return;

                case "1":
                    {
                        Console.WriteLine("\nEnter new task: ");
                        var title = Console.ReadLine();
                        _taskRepository.AddTask(new Models.Task { Title = title });
                        MyDisplay.Success();
                    }
                    break;

                case "2":
                    {
                        Console.WriteLine("Id of task to change: ");
                        var id = Int32.Parse(Console.ReadLine());

                        Console.WriteLine("Insert new task: ");
                        var title = Console.ReadLine();

                        var task = _taskRepository.GetTask(id);
                        task.Title = title;
                        _taskRepository.UpdateTask(task);
                        MyDisplay.Success();
                    }
                    break;

                case "3":
                    {
                        Console.WriteLine("Id task to delete: ");
                        var id = Int32.Parse(Console.ReadLine());

                        _taskRepository.DeleteTask(id);
                        MyDisplay.Success();
                    }
                    break;
                default:
                    MyDisplay.Failure();
                    Console.WriteLine("Invalid option");
                    break;
            }
            Run();
        }
    }
}
