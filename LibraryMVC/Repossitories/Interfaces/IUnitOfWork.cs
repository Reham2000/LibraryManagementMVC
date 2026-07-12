using LibraryMVC.Models;

namespace LibraryMVC.Repossitories.Interfaces
{
    public interface IUnitOfWork
    {
        IGenaricRepo<Book> Books { get; }
        IGenaricRepo<Category> Category { get; }
        int Save();

    }
}
