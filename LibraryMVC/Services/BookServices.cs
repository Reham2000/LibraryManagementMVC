using LibraryMVC.Data;
using LibraryMVC.Models;
using LibraryMVC.Repossitories;
using LibraryMVC.Repossitories.Interfaces;

namespace LibraryMVC.Services
{
    public class BookServices
    {
        // logic for book services
        private readonly IUnitOfWork _unitOfWork;
        public BookServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public List<Book> GetAll()
        {
            //return _context.Books.ToList();
            return _unitOfWork.Books.GetAll();
        }
        public bool Add(Book book)
        {
            if(_unitOfWork.Books.Exists(b => b.Title == book.Title))
                return false;
             _unitOfWork.Books.Add(book);
            return _unitOfWork.Save() > 0;
        }
        public bool Update(Book book)
        {
            var oldData = GetById(book.Id);
            oldData.Title = book.Title;
            oldData.Author = book.Author;
            oldData.Category = book.Category;
            oldData.Price = book.Price;
            oldData.Quentity = book.Quentity;

             _unitOfWork.Books.Update(oldData);
            return _unitOfWork.Save() > 0;
        }
        public Book GetById(int id)
        {
            return _unitOfWork.Books.GetById(id);
            //return _context.Books.FirstOrDefault(x => x.Id == id);
            //return _context.Books.SingleOrDefault(x => x.Id == id);
        }
        public bool Delete(int id)
        {
            var book = GetById(id);
            if (book == null)
                return false;
             _unitOfWork.Books.Delete(book);
            return _unitOfWork.Save() > 0;  

        }
    }
}
