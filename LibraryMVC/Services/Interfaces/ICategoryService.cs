using LibraryMVC.Models;
using LibraryMVC.Response;

namespace LibraryMVC.Services.Interfaces
{
    public interface ICategoryService
    {
         BaseResponse<List<Category>> GetAll();
        BaseResponse Add(Category model);
        BaseResponse Update(Category model);
        BaseResponse<Category> GetById(int id);
        BaseResponse Delete(int id);
    }
}
