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
        public static readonly LoggerFactory MyLoggerFactory
            = new LoggerFactory(new[] {
                 new ConsoleLoggerProvider((category, level)
                    => category == DbLoggerCategory.Database.Command.Name
                       && level == LogLevel.Information, true)
            });

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder
                .UseLoggerFactory(MyLoggerFactory)
                .UseSqlServer(ConnectionString);
        }
    }
}
