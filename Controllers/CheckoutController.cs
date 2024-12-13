using FlashShop.Repository;
using FlashShop.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;

namespace FlashShop.Controllers
{
    public class CheckoutController : Controller
    {
        private readonly DataContext _dataContext;

        public CheckoutController(DataContext context)
        {
            _dataContext = context;
        }

        [HttpGet]
        [HttpGet]
        public async Task<IActionResult> Checkout()
        {
            var userEmail = User.FindFirstValue(ClaimTypes.Email);
            if (userEmail == null)
            {
                return RedirectToAction("Login", "Account");
            }

            // Lấy thông tin người dùng từ bảng Users
            var user = await _dataContext.Users.FirstOrDefaultAsync(u => u.Email == userEmail);
            if (user == null)
            {
                TempData["error"] = "Không tìm thấy thông tin người dùng.";
                return RedirectToAction("Login", "Account");
            }

            // Lấy thông tin chi tiết người dùng từ bảng UserDetails
            var userDetails = await _dataContext.UserDetails.FirstOrDefaultAsync(u => u.UserId == user.Id);

            // Nếu không có thông tin chi tiết người dùng, tạo mới
            if (userDetails == null)
            {
                userDetails = new UserDetail
                {
                    UserId = user.Id,
                    FullName = user.FullName,
                    PhoneNumber = user.PhoneNumber,
                    Address = user.Address
                };
                _dataContext.UserDetails.Add(userDetails);
                await _dataContext.SaveChangesAsync();
            }

            // Tạo CheckoutViewModel để hiển thị thông tin người dùng
            var checkoutViewModel = new CheckoutViewModel
            {
                UserName = user.UserName,
                Email = user.Email,
                FullName = userDetails.FullName,
                PhoneNumber = userDetails.PhoneNumber,
                Address = userDetails.Address
            };

            // Trả về View với CheckoutViewModel
            return View(checkoutViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Checkout(CheckoutViewModel model)
        {
            var userEmail = User.FindFirstValue(ClaimTypes.Email);
            if (userEmail == null)
            {
                return RedirectToAction("Login", "Account");
            }

            // Lấy thông tin người dùng từ bảng Users
            var user = await _dataContext.Users.FirstOrDefaultAsync(u => u.Email == userEmail);
            if (user == null)
            {
                TempData["error"] = "Không tìm thấy thông tin người dùng.";
                return RedirectToAction("Login", "Account");
            }

            // Lấy thông tin chi tiết người dùng từ bảng UserDetails
            var userDetails = await _dataContext.UserDetails.FirstOrDefaultAsync(u => u.UserId == user.Id);

            if (userDetails == null)
            {
                // Nếu không có thông tin, thêm mới
                userDetails = new UserDetail
                {
                    UserId = user.Id,
                    FullName = model.FullName,
                    PhoneNumber = model.PhoneNumber,
                    Address = model.Address
                };
                _dataContext.UserDetails.Add(userDetails);
            }
            else
            {
                // Nếu đã có thông tin, cập nhật
                userDetails.FullName = model.FullName;
                userDetails.PhoneNumber = model.PhoneNumber;
                userDetails.Address = model.Address;
                _dataContext.UserDetails.Update(userDetails);
            }

            await _dataContext.SaveChangesAsync();

            // Xử lý đơn hàng sau khi cập nhật thông tin người dùng
            var ordercode = Guid.NewGuid().ToString();
            var orderItem = new OrderModel
            {
                OrderCode = ordercode,
                UserName = userEmail,
                Status = 1,
                dateTime = DateTime.Now
            };
            _dataContext.Add(orderItem);

            // Lấy giỏ hàng từ session
            List<CartItemModel> cartItems = HttpContext.Session.GetJson<List<CartItemModel>>("Cart") ?? new List<CartItemModel>();

            foreach (var cart in cartItems)
            {
                // Tạo chi tiết đơn hàng
                var orderdetails = new OrderDetails
                {
                    UserName = userEmail,
                    OrderCode = ordercode,
                    BookId = cart.BookId,
                    Price = cart.Price,
                    Quantity = cart.Quantity
                };
                _dataContext.Add(orderdetails);

                // Giảm số lượng sách trong kho
                var book = await _dataContext.Books.FindAsync(cart.BookId);
                if (book != null)
                {
                    if (book.Quantity >= cart.Quantity)
                    {
                        book.Quantity -= cart.Quantity;
                    }
                    else
                    {
                        TempData["error"] = $"Không đủ số lượng sách '{book.Title}' trong kho!";
                        return RedirectToAction("Index", "Cart");
                    }
                }
                else
                {
                    TempData["error"] = $"Sách với ID {cart.BookId} không tồn tại!";
                    return RedirectToAction("Index", "Cart");
                }
            }

            _dataContext.SaveChanges();

            // Xóa giỏ hàng trong session
            HttpContext.Session.Remove("Cart");
            TempData["success"] = "Checkout thành công, vui lòng chờ duyệt đơn hàng";
            return RedirectToAction("History", "Account");
        }

    }
}