using FlashShop.Models;
using FlashShop.Models.ViewModels;
using FlashShop.Repository;
using Microsoft.AspNetCore.Mvc;

namespace FlashShop.Controllers
{
    public class CartController : Controller
    {
        private readonly DataContext _dataContext;
        public CartController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public IActionResult Index()        // View Cart
        {
            List<CartItemModel> cartItems = HttpContext.Session.GetJson<List<CartItemModel>> ("Cart") ?? new List<CartItemModel> ();
            CartItemViewModel cartVM = new()
            {
                CartItems = cartItems,
                GrandTotal = cartItems.Sum(x => x.Quantity * x.Price)
            }; 
            return View(cartVM);
        }

        public IActionResult Checkout() 
        {
            return View("Index", "Home");
        }

        public async Task<IActionResult> Add(int id)
        {
            var book = await _dataContext.Books.FindAsync(id);
            if (book == null)
            {
                TempData["error"] = "Sách không tồn tại!";
                return RedirectToAction("Index");
            }

            List<CartItemModel> cart = HttpContext.Session.GetJson<List<CartItemModel>>("Cart") ?? new List<CartItemModel>();

            CartItemModel cartItems = cart.Where(c => c.BookId == id).FirstOrDefault();

            if (cartItems == null)
            {
                cart.Add(new CartItemModel(book));
            }
            else
            {
                cartItems.Quantity += 1;
            }

            HttpContext.Session.SetJson("Cart", cart);

            TempData["success"] = "Thêm sách [" + book.Title + "] vào giỏ hàng thành công";
            return Redirect(Request.Headers["Referer"].ToString());
        }

        public IActionResult Decrease(int id)
        {
            List<CartItemModel> cart = HttpContext.Session.GetJson<List<CartItemModel>>("Cart");

            CartItemModel cartItem = cart.Where(b => b.BookId == id).FirstOrDefault();
            if (cartItem.Quantity > 1)
            {
                cartItem.Quantity -= 1;
            }
            else
            {
                cart.RemoveAll(b => b.BookId == id);
            }

            if (cart.Count == 0)
            {
                HttpContext.Session.Remove("Cart");
            }
            else
            {
                HttpContext.Session.SetJson("Cart", cart);
            }

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Increase(int id)
        {
            // Lấy danh sách giỏ hàng từ session
            List<CartItemModel> cart = HttpContext.Session.GetJson<List<CartItemModel>>("Cart");

            // Tìm sách trong giỏ hàng
            CartItemModel cartItem = cart.Where(b => b.BookId == id).FirstOrDefault();
            if (cartItem != null)
            {
                // Lấy thông tin sách từ cơ sở dữ liệu
                var book = await _dataContext.Books.FindAsync(id);
                if (book != null)
                {
                    // Kiểm tra nếu số lượng trong giỏ hàng chưa đạt tới số lượng tồn kho
                    if (cartItem.Quantity < book.Quantity)
                    {
                        cartItem.Quantity += 1;
                    }
                    else
                    {
                        TempData["error"] = $"Không thể thêm sách '{book.Title}', số lượng tối đa trong kho là {book.Quantity}.";
                    }
                }
                else
                {
                    TempData["error"] = "Sách không tồn tại!";
                }
            }

            // Cập nhật lại session giỏ hàng
            if (cart.Count == 0)
            {
                HttpContext.Session.Remove("Cart");
            }
            else
            {
                HttpContext.Session.SetJson("Cart", cart);
            }

            return RedirectToAction("Index");
        }


        public async Task<IActionResult> Remove(int id)
        {
            var book = await _dataContext.Books.FindAsync(id);

            if (book == null)
            {
                TempData["error"] = "Sách không tồn tại!";
                return RedirectToAction("Index");
            }

            List<CartItemModel> cart = HttpContext.Session.GetJson<List<CartItemModel>>("Cart");

            cart.RemoveAll(b => b.BookId == id);

            if (cart.Count == 0)
            {
                HttpContext.Session.Remove("Cart");
            }
            else
            {
                HttpContext.Session.SetJson("Cart", cart);
            }

            TempData["success"] = "Xoá sách [" + book.Title + "] khỏi giỏ hàng thành công";
            return RedirectToAction("Index");
        }

        public IActionResult Clear()
        {
            HttpContext.Session.Remove("Cart");
            TempData["success"] = "Xóa toàn bộ sách khỏi giỏ hàng thành công";
            return RedirectToAction("Index");
        }
    }
}
