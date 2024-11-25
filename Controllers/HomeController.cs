using System.Data.Entity;
using System.Diagnostics;
using FlashShop.Models;
using FlashShop.Repository;
using Microsoft.AspNetCore.Mvc;


namespace FlashShop.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly DataContext _dataContext;

        public HomeController(ILogger<HomeController> logger, DataContext context)
        {
            _logger = logger;
            _dataContext = context;
        }

        public IActionResult Home()
        {
            return View();
        }

        public IActionResult Index()
        {
            var products = _dataContext.Books.ToList();
            return View(products);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Map()
        {
            return View();
        }

        public IActionResult Product()
        {
            var products = _dataContext.Books.ToList();
            return View(products);
        }
        /*Tìm kiếm dựa theo "Title" và ""Description" thông qua từ khóa được gán vào "searchTerm"*/
        public async Task<IActionResult> Search(string searchTerm)
        {
            var products = _dataContext.Books
                .Where(p => p.Title.Contains(searchTerm) || p.Description.Contains(searchTerm))
                .ToList();

            ViewBag.Keyword = searchTerm;

            return View(products);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
