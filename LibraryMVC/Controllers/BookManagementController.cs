using LibraryMVC.Models;
using LibraryMVC.Services;
using Microsoft.AspNetCore.Mvc;

namespace LibraryMVC.Controllers
{
    public class BookManagementController : Controller
    {
        // DI for BookServices
        private readonly BookServices _bookServices;
        public BookManagementController(BookServices bookServices)
        {
            _bookServices = bookServices;

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
            return View();
        }
        [HttpPost]
        public IActionResult Create(Book book)
        {
            if(! ModelState.IsValid)
                return View(book);

            if(_bookServices.Add(book))
                TempData["Message"] = "Book Added Successfully";
            else
                TempData["Message"] = "Book Already Exists";
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var book = _bookServices.GetById(id);
            return View(book);
        }
        [HttpPost]
        public IActionResult Edit(Book book)
        {
            if (!ModelState.IsValid)
                return View(book);
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
