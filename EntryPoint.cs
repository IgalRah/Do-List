using System;
using System.Linq;
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

            Console.Write("Choose Your Option: ");
            var option = Console.ReadLine();

            switch (option)
            {
                case "0":
                    return;

                case "1":
                    {
                        var items = _taskRepository.GetTasks();
                        Console.WriteLine(items.Select(item => item.Title));
                    }
                    break;

                case "2":
                    {
                        Console.WriteLine("\nEnter new task: ");
                        var title = Console.ReadLine();
                        _taskRepository.AddTask(new Models.Task { Title = title });
                    }
                    break;

                case "3":
                    {
                        Console.WriteLine("Id of task to change: ");
                        var id = Int32.Parse(Console.ReadLine());


                        Console.WriteLine("Insert new task: ");
                        var title = Console.ReadLine();

                        var task = _taskRepository.GetTask(id);
                        task.Title = title;
                        _taskRepository.UpdateTask(task);
                    }
                    break;

                case "4":
                    {
                        Console.WriteLine("Id task to delete: ");
                        var id = Int32.Parse(Console.ReadLine());

                        _taskRepository.DeleteTask(id);
                    }
                    break;

                default:
                    Run();
                    break;
            }
        }
    }
}
