using FlashShop.Models;
using FlashShop.Models.ViewModels;
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

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return RedirectToAction("Index", "Home");

            var bookById = await _dataContext.Books
                .Include(b => b.Ratings)
                .FirstOrDefaultAsync(b => b.BookId == id);

            if (bookById == null)
            {
                TempData["error"] = "Không tìm thấy sách.";
                return RedirectToAction("Index", "Home");
            }

            var relatedBooks = await _dataContext.Books
                .Where(b => b.CategoryId == bookById.CategoryId && b.BookId != bookById.BookId)
                .Take(4)
                .ToListAsync();

            ViewBag.RelatedBooks = relatedBooks;

            var viewModel = new BookDetailsViewModel
            {
                BookDetails = bookById
            };
            return View(viewModel);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CommentBook(RatingModel rating)
        {
            if (ModelState.IsValid)
            {
                var ratingEntity = new RatingModel
                {
                    BookId = rating.BookId,
                    Name = rating.Name,
                    Email = rating.Email,
                    Comment = rating.Comment,
                    Rating = rating.Rating
                };

                _dataContext.Ratings.Add(ratingEntity);
                await _dataContext.SaveChangesAsync();

                TempData["success"] = "Thêm đánh giá thành công";
                return Redirect(Request.Headers["Referer"]);
            }

            TempData["error"] = "Thêm đánh giá thất bại, thử lại sau";
            return RedirectToAction("Details", new { id = rating.BookId });
        }

    }
}
