using FlashShop.Models;
using FlashShop.Repository;
using Microsoft.AspNetCore.Mvc;

namespace FlashShop.Controllers
{
    public class CategoryController : Controller
    {
        private readonly DataContext _dataContext;
        public CategoryController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public  IActionResult Index(int id)
        {
            var category = _dataContext.Categories.Where(c => c.CategoryId == id).FirstOrDefault();
            if (category == null) 
                return RedirectToAction("Index", "Home");

            var bookByCategory = _dataContext.Books.Where(c => c.CategoryId == category.CategoryId);

            return View(bookByCategory);
        }
    }
}
