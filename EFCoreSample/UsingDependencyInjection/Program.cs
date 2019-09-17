using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;

namespace EFCoreSample.UsingDependencyInjection
{
    public class Program
    {
        [Obsolete]
        static async Task Main()
        {
            Program p = new Program();
            p.InitializeServices();
            p.ConfigureLogging();
            var service = p.Container.GetService<BooksService>();
            await service.AddBooksAsync();
            await service.ReadBooksAsync();
            p.Container.Dispose();
        }

        [Obsolete]
        private void InitializeServices()
        {
            const string ConnectionString =
              @"Server=localhost;Database=learning;User Id=sa;Password=P@ssw0rd";
            var services = new ServiceCollection();
            services.AddTransient<BooksService>()
              .AddEntityFrameworkSqlServer()
              .AddDbContext<BooksContext>(options =>
                options.UseSqlServer(ConnectionString)
                .UseLoggerFactory(MyLoggerFactory));
            services.AddLogging();

            Container = services.BuildServiceProvider();
        }

        public ServiceProvider Container { get; private set; }

        [Obsolete]
        public static readonly LoggerFactory MyLoggerFactory
            = new LoggerFactory(new[] {
                 new ConsoleLoggerProvider((category, level)
                    => category == DbLoggerCategory.Database.Command.Name
                       && level == LogLevel.Information, true)
            });

        [Obsolete]
        private void ConfigureLogging()
        {
            ILoggerFactory loggerFactory = Container.GetService<ILoggerFactory>();

            loggerFactory.AddConsole(LogLevel.Information);
        }


    }
}
