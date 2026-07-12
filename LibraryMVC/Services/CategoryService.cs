using LibraryMVC.Models;
using LibraryMVC.Repossitories.Interfaces;

namespace LibraryMVC.Services
{
    public class CategoryService
    {
        private readonly IUnitOfWork _unitOfWork;
        public CategoryService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public List<Category> GetAll()
        {
            return _unitOfWork.Category.GetAll();
        }
        public bool Add(Category model)
        {
            if (_unitOfWork.Category.Exists(b => b.Name == model.Name))
                return false;
            _unitOfWork.Category.Add(model);
            return _unitOfWork.Save() > 0;
        }
        public bool Update(Category model)
        {
            var oldData = GetById(model.Id);
            oldData.Name = model.Name;
            

            _unitOfWork.Category.Update(oldData);
            return _unitOfWork.Save() > 0;
        }
        public Category GetById(int id)
        {
            return _unitOfWork.Category.GetById(id);
            //return _context.Books.FirstOrDefault(x => x.Id == id);
            //return _context.Books.SingleOrDefault(x => x.Id == id);
        }
        public bool Delete(int id)
        {
            var model = GetById(id);
            if (model == null)
                return false;
            _unitOfWork.Category.Delete(model);
            return _unitOfWork.Save() > 0;

        }
    }
}
