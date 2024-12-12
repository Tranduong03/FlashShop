using FlashShop.Repository;
using FlashShop.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Security.Claims;

namespace FlashShop.Controllers
{
	public class CheckoutController : Controller
	{
		private readonly DataContext _dataContext;

		public CheckoutController(DataContext context)
		{
			_dataContext = context;
		}

		public async Task<IActionResult> Checkout()
		{
			var userEmail = User.FindFirstValue(ClaimTypes.Email);
			if (userEmail == null)
			{
				return RedirectToAction("Login", "Account");
			}
			else
			{
				var ordercode = Guid.NewGuid().ToString();
				var orderItem = new OrderModel
				{
					OrderCode = ordercode,
					UserName = userEmail,
					Status = 1,
					dateTime = DateTime.Now
				};
				_dataContext.Add(orderItem);
				_dataContext.SaveChanges();

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
				return RedirectToAction("Index", "Cart");
			}
		}

	}
}