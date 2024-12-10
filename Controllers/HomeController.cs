using System.Diagnostics;
using System.Globalization;
using System.Text;
using FlashShop.Models;
using FlashShop.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


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

        public IActionResult Index(int pg=1)
        {
            List<BookModel> products = _dataContext.Books
                .Include(b => b.Categories) 
                .Include(b => b.Publisher) 
                .ToList();

            const int pageSize = 3;

            if (pg < 1)
            {
                pg = 1;
            }
            int ResCount = products.Count;

            var pager = new Paginate(ResCount, pg, pageSize);

            int recSkip = (pg - 1) * pageSize;

            var data = products.Skip(recSkip).Take(pager.PageSize).ToList();

            ViewBag.Pager = pager;

            return View(data);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Map()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error(int statuscode)
        {
            if (statuscode == 404)
            {
                return View("NotFound");
            }
            else
            {
				return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
			}         
        }

        //public async Task<IActionResult> Search(string searchTerm)
        //{
        //    var products = await _dataContext.Books
        //        .Where(p => p.Title.Contains(searchTerm))
        //        .ToListAsync();
        //    ViewBag.Keyword = searchTerm;
        //    return View(products);
        //}

        public IActionResult Search(string searchTerm)
        {
            string normalizedSearchTerm = RemoveDiacritics(searchTerm.ToLower());

            var products = _dataContext.Books.AsEnumerable()
                .Where(p => RemoveDiacritics(p.Title.ToLower()).Contains(normalizedSearchTerm) ||
                            RemoveDiacritics(p.Description.ToLower()).Contains(normalizedSearchTerm) ||
                            RemoveDiacritics(p.Author.ToLower()).Contains(normalizedSearchTerm))
                .ToList();

            ViewBag.Keyword = searchTerm;
            return View(products);
        }


        private string RemoveDiacritics(string text)
        {
            if (string.IsNullOrEmpty(text))
                return text;

            var normalizedText = text.Normalize(NormalizationForm.FormD);
            var stringBuilder = new StringBuilder();

            foreach (var c in normalizedText)
            {
                var unicodeCategory = CharUnicodeInfo.GetUnicodeCategory(c);
                if (unicodeCategory != UnicodeCategory.NonSpacingMark)
                {
                    stringBuilder.Append(c);
                }
            }
            return stringBuilder.ToString().Normalize(NormalizationForm.FormC);
        }
    }
}
