using LibraryMVC.Models;
using LibraryMVC.Repossitories.Interfaces;
using LibraryMVC.Response;
using LibraryMVC.Services.Interfaces;

namespace LibraryMVC.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IUnitOfWork _unitOfWork;
        public CategoryService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public BaseResponse<List<Category>> GetAll()
        {
            return new BaseResponse<List<Category>>
            {
                Success = true,
                Errors= null,
                Message = "Data Retrived Successfully!",
                Data = _unitOfWork.Category.GetAll()
            };
        }
        public BaseResponse Add(Category model)
        {
            if (_unitOfWork.Category.Exists(b => b.Name == model.Name))
                return new BaseResponse
                {
                    Success = false,
                    Errors = null,
                    Message = "Name Already Exist"
                };
            _unitOfWork.Category.Add(model);
            if(_unitOfWork.Save() > 0)
            {
                return new BaseResponse
                {
                    Success = true,
                    Message = "Data Added Successfully"
                };
            }
            else
            {
                return new BaseResponse
                {
                    Success = false,
                    Message = "Data not Added"
                };
            }
        }
        public BaseResponse Update(Category model)
        {
            var oldData = GetById(model.Id).Data;
            oldData.Name = model.Name;
            

            _unitOfWork.Category.Update(oldData);
            if (_unitOfWork.Save() > 0)
            {
                return new BaseResponse
                {
                    Success = true,
                    Message = "Data Updated Successfully"
                };
            }
            else
            {
                return new BaseResponse
                {
                    Success = false,
                    Message = "Data not Updated"
                };
            }
        }
        public BaseResponse<Category> GetById(int id)
        {
            return new BaseResponse<Category>
            {
                Success = true,
                Message = "Data Retrived Successfully",
                Data = _unitOfWork.Category.GetById(id)
            };
            //return _context.Books.FirstOrDefault(x => x.Id == id);
            //return _context.Books.SingleOrDefault(x => x.Id == id);
        }
        public BaseResponse Delete(int id)
        {
            var model = GetById(id).Data;
            if (model == null)
                return new BaseResponse
                {
                    Success = false,
                    Message = "Item Not Found"
                };
            _unitOfWork.Category.Delete(model);
            if (_unitOfWork.Save() > 0)
            {
                return new BaseResponse
                {
                    Success = true,
                    Message = "Data Deleted Successfully"
                };
            }
            else
            {
                return new BaseResponse
                {
                    Success = false,
                    Message = "Data not Deleted"
                };
            }

        }
    }
}
