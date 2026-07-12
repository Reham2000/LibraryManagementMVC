using LibraryMVC.Data;
using LibraryMVC.Models;
using LibraryMVC.Repossitories.Interfaces;

namespace LibraryMVC.Repossitories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        public IGenaricRepo<Book> Books { get; }
        public IGenaricRepo<Category> Category { get; }
        public UnitOfWork(AppDbContext context)
        {
            _context = context;
            Books = new GenaricRepo<Book>(_context);
            Category = new GenaricRepo<Category>(_context);
        }
        public int Save()
        {
            return _context.SaveChanges();
        }
    }
}
