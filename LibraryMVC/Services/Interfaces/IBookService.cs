using LibraryMVC.Models;

namespace LibraryMVC.Services.Interfaces
{
    public interface IBookService
    {
         List<Book> GetAll();
         bool Add(Book book);
         bool Update(Book book);
         Book GetById(int id);
         bool Delete(int id);
    }
}
