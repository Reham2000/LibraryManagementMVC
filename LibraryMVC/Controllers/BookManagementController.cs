using LibraryMVC.Models;
using LibraryMVC.Services;
using LibraryMVC.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LibraryMVC.Controllers
{
    public class BookManagementController : Controller
    {
        // DI for BookServices
        private readonly IBookService _bookServices;
        private readonly ICategoryService _categoryServices;
        public BookManagementController(IBookService bookServices, ICategoryService categoryServices)
        {
            _bookServices = bookServices;
            _categoryServices = categoryServices;
        }
        public IActionResult Index()
        {
            var Books = _bookServices.GetAll();
            return View(Books);
        }
        // get
        [HttpGet]
        public IActionResult Create()
        {
            var categories = _categoryServices.GetAll().Data;
            ViewBag.Categories = new SelectList((IEnumerable<Category>)categories,
                                                    "Id", "Name");
            return View();
        }
        [HttpPost]
        public IActionResult Create(Book book)
        {
            if(! ModelState.IsValid)
            {
                var categories = _categoryServices.GetAll().Data;
                ViewBag.Categories = new SelectList((IEnumerable<Category>)categories,
                                "Id", "Name",book.CatId);
                return View(book);
            }

            if(_bookServices.Add(book))
                TempData["Message"] = "Book Added Successfully";
            else
                TempData["Message"] = "Book Already Exists";
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var categories = _categoryServices.GetAll().Data;
            ViewBag.Categories = new SelectList((IEnumerable<Category>)categories,
                                                    "Id", "Name");
            var book = _bookServices.GetById(id);
            return View(book);
        }
        [HttpPost]
        public IActionResult Edit(Book book)
        {
            if (!ModelState.IsValid)
            {
                var categories = _categoryServices.GetAll().Data;
                ViewBag.Categories = new SelectList((IEnumerable<Category>)categories,
                                                        "Id", "Name");
                return View(book);
            }
            _bookServices.Update(book);
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public IActionResult Details(int id)
        {
            var book = _bookServices.GetById(id);
            return View(book);
        }
        
        public IActionResult Delete(int id)
        {
            _bookServices.Delete(id);
            return RedirectToAction(nameof(Index));
        }

    }
}
