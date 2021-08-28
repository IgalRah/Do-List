using System;
using System.Collections.Generic;
using TaskManager.Models;

namespace TaskManager.DAL
{
    public interface ITaskRepository : IDisposable
    {
        List<Task> GetTasks();
        Task GetTask(int id);
        void AddTask(Task task);
        void UpdateTask(Task task);
        void DeleteTask(int id);
        void Save();
    }
}
