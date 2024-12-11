using FlashShop.Repository;
using Microsoft.AspNetCore.Mvc;

namespace FlashShop.Controllers
{
    public class PublisherController : Controller
    {
        private readonly DataContext _dataContext;
        public PublisherController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public IActionResult Index(int id)
        {
            var publisher = _dataContext.Publishers.Where(p => p.PublisherId == id).FirstOrDefault();
            if (publisher == null)
                return RedirectToAction("Index", "Home");

            var bookByNXB = _dataContext.Books.Where(c => c.PublisherId == publisher.PublisherId);

            return View(bookByNXB);
        }
    }
}
