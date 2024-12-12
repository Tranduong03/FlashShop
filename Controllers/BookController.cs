using FlashShop.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FlashShop.Controllers
{
    public class BookController : Controller
    {
        private readonly DataContext _dataContext;

        public BookController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public IActionResult Index()
        {
            return View();
        }

        //public IActionResult Details(int? id)
        //{
        //    if (id == null) return RedirectToAction("Index", "Home");
        //    var bookById = _dataContext.Books.Where(b => b.BookId == id).FirstOrDefault();

        //    return View(bookById);
        //}
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return RedirectToAction("Index", "Home");

            var bookById = _dataContext.Books.Where(b => b.BookId == id).FirstOrDefault();

            var relatedBooks = await _dataContext.Books
                .Where(b => b.CategoryId == bookById.CategoryId && b.BookId != bookById.BookId)
                .Take(4)
                .ToListAsync();

            ViewBag.RelatedBooks = relatedBooks;

            return View(bookById);
        }
    }
}