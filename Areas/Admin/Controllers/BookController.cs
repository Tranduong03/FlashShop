using FlashShop.Models;
using FlashShop.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;


namespace FlashShop.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BookController : Controller
    {
        private readonly DataContext _dataContext;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public BookController(DataContext dataContext, IWebHostEnvironment webHostEnvironment)
        {
            _dataContext = dataContext;
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _dataContext.Books.OrderBy(b => b.BookId).Include(c => c.Categories).Include(nxb => nxb.Publisher).ToListAsync());
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
                TempData["successAdmin"] = "Thêm sách thành công vào Cơ sở dữ liệu";
                return RedirectToAction("Index");               
            }
            else
            {
                TempData["errorAdmin"] = "Model có một vài thứ đang bị lỗi";
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

            if (ModelState.IsValid)
            {
                var title = await _dataContext.Books.FirstOrDefaultAsync(b => b.Title == book.Title);
                if (title != null)
                {
                    ModelState.AddModelError("", "Sản phẩm này đã tồn tại");
                    TempData["errorAdmin"] = "Tên sản phẩm trùng với sản phẩm khác";
                    //return View(book);
                }

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

                _dataContext.Update(book);
                await _dataContext.SaveChangesAsync();
                TempData["successAdmin"] = "Cập nhật thông tin sản phẩm thành công vào Cơ sở dữ liệu";
                return RedirectToAction("Index");
            }
            else
            {
                TempData["errorAdmin"] = "Model có một vài thứ đang bị lỗi";
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

    }
}
