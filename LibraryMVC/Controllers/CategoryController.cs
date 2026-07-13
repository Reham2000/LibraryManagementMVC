using LibraryMVC.Models;
using LibraryMVC.Services;
using LibraryMVC.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LibraryMVC.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        public IActionResult Index()
        {
            var Categories = _categoryService.GetAll();
            return View(Categories);
        }
        #region Create Category
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Category model)
        {
            if(! ModelState.IsValid) 
                return View(model);
            var result = _categoryService.Add(model);
            if (result.Success)
            {
                TempData["success"] = "Category Added Successfully!";
                return RedirectToAction(nameof(Index));
            }
            else
            {
                TempData["error"] = "Category Already Exist!";
                return View(model);
            }    

        }
        #endregion
        #region Update Category
        public IActionResult Edit(int id)
        {

            var category = _categoryService.GetById(id).Data;
            if (category == null)
                {
                TempData["error"] = $"Category with Id {id} Not Found!";
                return RedirectToAction(nameof(Index));
            }
            return View(category);
        }
        [HttpPost]
        public IActionResult Edit(Category model)
        {
            if (_categoryService.GetById(model.Id).Data == null)
            {
                TempData["error"] = $"Category with Id {model.Id} Not Found!";
                return RedirectToAction(nameof(Index));
            }
            if (!ModelState.IsValid)
                return View(model);
            var result = _categoryService.Update(model);
            if (result.Success)
            {
                TempData["success"] = "Category Updated Successfully!";
                return RedirectToAction(nameof(Index));
            }
            else
            {
                TempData["error"] = "Category Not Found!";
                return View(model);
            }
        }
        #endregion
        #region Details

        public IActionResult Details(int id)
        {
            var category = _categoryService.GetById(id).Data;
            if(category == null)
            {
                TempData["error"] = $"Category with Id {id} Not Found!";
                return RedirectToAction(nameof(Index));
            }
            return View(category);
        }
        #endregion
        #region Delete Category
        public IActionResult Delete(int id)
        {
            var result = _categoryService.Delete(id);
            if (result.Success)
            {
                TempData["success"]  =" Category Deleted Successfully!";
                return RedirectToAction(nameof(Index));
            }
            else
            {
                TempData["error"] = $"Category with Id {id} Not Found!";
                return RedirectToAction(nameof(Index));
            }
        }
        #endregion



    }
}
