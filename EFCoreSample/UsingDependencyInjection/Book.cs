using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCoreSample.UsingDependencyInjection
{
    [Table("Books")]
    public class Book
    {
        public int BookId { get; set; }
        public string Title { get; set; }
        public string Publisher { get; set; }
    }

}
