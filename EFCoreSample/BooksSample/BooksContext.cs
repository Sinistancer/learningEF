using EFCoreSample.Intro;
using Microsoft.EntityFrameworkCore;

namespace EFCoreSample.BooksSample
{
    public class BooksContext : DbContext
    {
        private const string ConnectionString = @"Server=localhost;Database=learning;User Id=sa;Password=P@ssw0rd";
        public DbSet<Book> Books { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(ConnectionString);
        }
    }
}
