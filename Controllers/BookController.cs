using FlashShop.Repository;
using Microsoft.AspNetCore.Mvc;

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

        public IActionResult Details(int ?id)
        {
            if (id == null) return RedirectToAction("Index", "Home");
            var bookById = _dataContext.Books.Where(b => b.BookId == id).FirstOrDefault();

            return View(bookById);
        }
    }
}
