using EFCoreSample.Intro;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;

namespace EFCoreSample.BooksSample
{
    public class BooksContext : DbContext
    {
        private const string ConnectionString = @"Server=localhost;Database=learning;User Id=sa;Password=P@ssw0rd";
        public DbSet<Book> Books { get; set; }

        [System.Obsolete]
        public static readonly LoggerFactory MyLoggerFactory
            = new LoggerFactory(new[] {
                 new ConsoleLoggerProvider((category, level)
                    => category == DbLoggerCategory.Database.Command.Name
                       && level == LogLevel.Information, true)
            });

        [System.Obsolete]
#pragma warning disable CS0809 // Obsolete member overrides non-obsolete member
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#pragma warning restore CS0809 // Obsolete member overrides non-obsolete member
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder
                .UseLoggerFactory(MyLoggerFactory)
                .UseSqlServer(ConnectionString);
        }
    }
}
