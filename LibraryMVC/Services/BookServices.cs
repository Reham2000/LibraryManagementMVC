using LibraryMVC.Data;
using LibraryMVC.Models;

namespace LibraryMVC.Services
{
    public class BookServices
    {
        private readonly AppDbContext _context;
        public BookServices(AppDbContext context)
        {
            _context = context;
        }
        public List<Book> GetAll()
        {
            return _context.Books.ToList();
        }
        public bool Add(Book book)
        {
            _context.Books.Add(book);
            return _context.SaveChanges() >= 0;
        }
    }
}
