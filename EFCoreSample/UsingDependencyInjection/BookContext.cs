using System;
using EFCoreSample.Intro;
using Microsoft.EntityFrameworkCore;

namespace EFCoreSample.UsingDependencyInjection
{
    public class BooksContext : DbContext
    {
        public BooksContext(DbContextOptions<BooksContext> options) : base(options) { }

        public DbSet<Book> Books { get; set; }
        
    }
}
