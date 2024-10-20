using Microsoft.AspNetCore.Mvc;

namespace FlashShop.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
