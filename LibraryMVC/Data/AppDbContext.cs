using LibraryMVC.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryMVC.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }

        public DbSet<Book> Books { get; set; }
    }
}
