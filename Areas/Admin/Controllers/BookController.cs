using FlashShop.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace FlashShop.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BookController : Controller
    {
        private readonly DataContext _dataContext;
        public BookController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public IActionResult Index()
        {
            return View(_dataContext.Books.OrderByDescending(b => b.BookId).Include(c => c.Categories).ToListAsync());
        }
    }
}
