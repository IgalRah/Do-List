using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using TaskManager.Data;
using TaskManager.Models;

namespace TaskManager.DAL
{
    public class TaskRepository : ITaskRepository
    {
        private readonly ApplicationDbContext _context;

        public TaskRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Task> GetTasks()
        {
            return _context.Tasks.ToList();
        }

        public Task GetTask(int id)
        {
            return _context.Tasks.Find(id);
        }

        public void AddTask(Task task)
        {
            _context.Tasks.Add(task);
        }

        public void UpdateTask(Task task)
        {
            _context.Entry(task).State = EntityState.Modified;
        }

        public void DeleteTask(int id)
        {
            var task = _context.Tasks.Find(id);
            _context.Tasks.Remove(task);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
                disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(disposing: true);
            System.GC.SuppressFinalize(this);
        }
    }
}
