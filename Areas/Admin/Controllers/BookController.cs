using FlashShop.Models;
using FlashShop.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;


namespace FlashShop.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class BookController : Controller
    {
        private readonly DataContext _dataContext;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public BookController(DataContext dataContext, IWebHostEnvironment webHostEnvironment)
        {
            _dataContext = dataContext;
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task<IActionResult> Index(int pg = 1)
        {
            const int pageSize = 6;

            if (pg < 1) 
            {
                pg = 1;
            }

            var booksQuery = _dataContext.Books
                .Include(b => b.Categories)
                .Include(b => b.Publisher)
                .OrderBy(b => b.BookId);

            int resCount = await booksQuery.CountAsync();
            var pager = new Paginate(resCount, pg, pageSize);

            int recSkip = (pg - 1) * pageSize;

            var data = await booksQuery
                .Skip(recSkip)
                .Take(pager.PageSize)
                .ToListAsync();

            ViewBag.Pager = pager;

            return View(data);
        }


        public IActionResult Create()
        {
            ViewBag.Categories = new SelectList(_dataContext.Categories, "CategoryId", "CategoryName");
            ViewBag.Publishers = new SelectList(_dataContext.Publishers, "PublisherId", "PublisherName");

            var currentYear = DateTime.Now.Year;
            var years = Enumerable.Range(currentYear - 99, 100).Select(x => x.ToString()).ToList();  
            ViewBag.Years = new SelectList(years);
            
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(BookModel book)
        {
            ViewBag.Categories = new SelectList(_dataContext.Categories, "CategoryId", "CategoryName", book.CategoryId);
            ViewBag.Publishers = new SelectList(_dataContext.Publishers, "PublisherId", "PublisherName", book.PublisherId);


            if (ModelState.IsValid) 
            {
                var title = await _dataContext.Books.FirstOrDefaultAsync(b => b.Title == book.Title);
                if (title != null)
                {
                    ModelState.AddModelError("", "Sản phẩm này đã tồn tại");
                    return View(book);
                }
                else
                {
                    if (book.ImgLinkUpload != null)
                    {
                        string uploadsDir = Path.Combine(_webHostEnvironment.WebRootPath, "images/book");
                        string imageName = Guid.NewGuid().ToString() + "_" + book.ImgLinkUpload.FileName;
                        string filePath = Path.Combine(uploadsDir, imageName);

                        FileStream fs = new FileStream(filePath, FileMode.Create);
                        await book.ImgLinkUpload.CopyToAsync(fs);
                        fs.Close();
                        book.ImgLink = imageName;
                    }
                }
                _dataContext.Add(book);
                await _dataContext.SaveChangesAsync();
                TempData["successAdmin"] = "Thêm sách mới thành công";
                return RedirectToAction("Index");               
            }
            else
            {
                TempData["errorAdmin"] = "Thêm sách mới thất bại, thử lại !";
                List<string> errors = new List<string>();
                foreach (var value in ModelState.Values)
                {
                    foreach (var error in value.Errors)
                    {
                        errors.Add(error.ErrorMessage);
                    }
                }
                string errorMessage = string.Join("\n", errors);
                errorMessage += book.Categories;

                return BadRequest(errorMessage);
            }
        }

        public async Task<IActionResult> Edit(int id)
        {
            BookModel book = await _dataContext.Books.FindAsync(id);
            if (book == null)
            {
                TempData["errorAdmin"] = "Không tìm thấy sách với ID được cung cấp!";
                return NotFound();
            }

            ViewBag.Categories = new SelectList(_dataContext.Categories, "CategoryId", "CategoryName", book.CategoryId);
            ViewBag.Publishers = new SelectList(_dataContext.Publishers, "PublisherId", "PublisherName", book.PublisherId);

            var currentYear = DateTime.Now.Year;
            var years = Enumerable.Range(currentYear - 99, 100).Select(x => x.ToString()).ToList();
            ViewBag.Years = new SelectList(years, book.Publication?.ToString());

            return View(book);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, BookModel book)
        {
            ViewBag.Categories = new SelectList(_dataContext.Categories, "CategoryId", "CategoryName", book.CategoryId);
            ViewBag.Publishers = new SelectList(_dataContext.Publishers, "PublisherId", "PublisherName", book.PublisherId);

            var currentYear = DateTime.Now.Year;
            var years = Enumerable.Range(currentYear - 99, 100).Select(x => x.ToString()).ToList();
            ViewBag.Years = new SelectList(years, book.Publication?.ToString());

            var existingBook = await _dataContext.Books.FindAsync(id);

            if (ModelState.IsValid)
            {
                if (existingBook == null)
                {
                    TempData["errorAdmin"] = "Không tìm thấy sách với ID được cung cấp!";
                    return NotFound();
                }

                var title = await _dataContext.Books.FirstOrDefaultAsync(b => b.Title == book.Title && b.BookId != id);
                if (title != null)
                {
                    ModelState.AddModelError("", "Sản phẩm này đã tồn tại");
                    TempData["errorAdmin"] = "Tên sản phẩm trùng với sản phẩm khác";
                    return View(book);
                }

                if (book.ImgLinkUpload != null)
                {
                    // Xóa ảnh cũ nếu tồn tại
                    if (!string.IsNullOrEmpty(existingBook.ImgLink))
                    {
                        string oldImagePath = Path.Combine(_webHostEnvironment.WebRootPath, "images/book", existingBook.ImgLink);
                        if (System.IO.File.Exists(oldImagePath))
                        {
                            System.IO.File.Delete(oldImagePath);
                        }
                    }

                    // Lưu ảnh mới
                    string uploadsDir = Path.Combine(_webHostEnvironment.WebRootPath, "images/book");
                    string imageName = Guid.NewGuid().ToString() + "_" + book.ImgLinkUpload.FileName;
                    string filePath = Path.Combine(uploadsDir, imageName);

                    using (var fs = new FileStream(filePath, FileMode.Create))
                    {
                        await book.ImgLinkUpload.CopyToAsync(fs);
                    }

                    existingBook.ImgLink = imageName;
                }

                // Cập nhật thông tin sách
                existingBook.Title = book.Title;
                existingBook.Price = book.Price;
                existingBook.Quantity = book.Quantity;
                existingBook.Description = book.Description;
                existingBook.Author = book.Author;
                existingBook.Publication = book.Publication;
                existingBook.Point = book.Point;
                existingBook.CategoryId = book.CategoryId;
                existingBook.PublisherId = book.PublisherId;

                await _dataContext.SaveChangesAsync();
                TempData["successAdmin"] = "Cập nhật thông tin sản phẩm thành công";
                return RedirectToAction("Index");
            }

            TempData["errorAdmin"] = "Có lỗi xảy ra! Hãy thử lại";
            return View(book);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var book = await _dataContext.Books.FindAsync(id);
            if (book == null)
            {
                TempData["errorAdmin"] = "Không tìm thấy sản phẩm để xóa!";
                return NotFound();
            }

            if (!string.Equals(book.ImgLink, "No_image.jpg", StringComparison.OrdinalIgnoreCase))
            {
                string uploadsDir = Path.Combine(_webHostEnvironment.WebRootPath, "images/book");
                string oldfileImg = Path.Combine(uploadsDir, book.ImgLink);
                if (System.IO.File.Exists(oldfileImg))
                {
                    System.IO.File.Delete(oldfileImg);
                }
            }

            // Xóa sách khỏi cơ sở dữ liệu
            _dataContext.Books.Remove(book);
            await _dataContext.SaveChangesAsync();

            TempData["successAdmin"] = "Sản phẩm đã được xóa thành công!";
            return RedirectToAction("Index");
        }

    }
}
