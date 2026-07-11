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

            _bookServices.Add(book);
            return RedirectToAction(nameof(Index));
        }

    }
}
