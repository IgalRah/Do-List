using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TaskManager.DAL;
using TaskManager.Data;

namespace TaskManager
{
    class Program
    {
        static void Main(string[] args)
        {
            var services = ConfigureServices();
            var serviceProvider = services.BuildServiceProvider();

            var entryPoint = serviceProvider.GetService<EntryPoint>();
            entryPoint.Run();
        }

        private static IConfiguration GetConfiguration()
            => new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: false)
                .Build();

        public static IServiceCollection ConfigureServices()
        {
            var configuration = GetConfiguration();
            var connectionString = configuration.GetConnectionString("Default");

            return new ServiceCollection()
                .AddDbContext<ApplicationDbContext>(options =>
                    options.UseSqlServer(connectionString))
                .AddSingleton<ITaskRepository, TaskRepository>()
                .AddSingleton<EntryPoint>();
        }
    }
}
