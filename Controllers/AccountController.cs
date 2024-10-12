using FlashShop.Models;
using FlashShop.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FlashShop.Controllers
{
	public class AccountController : Controller
	{
		private readonly DataContext _context;

		// Constructor duy nhất để khởi tạo DataContext
		public AccountController(DataContext context)
		{
			_context = context;
		}

		[HttpGet]
		public IActionResult Login()
		{

			Console.WriteLine("LoginPage");
			return View(new AccountCheck());
		}

		[HttpGet]
		public IActionResult Register()
		{
			return View();
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Register(Customer customer)
		{
			if (ModelState.IsValid)
			{
				// Kiểm tra nếu tài khoản đã tồn tại
				var existingAccount = await _context.Customer
					.FirstOrDefaultAsync(c => c.Account == customer.Account);

				if (existingAccount != null)
				{
					ModelState.AddModelError("Account", "Account already exists.");
					return View(customer); // Hiển thị lại form với thông báo lỗi
				}

				// Lưu thông tin người dùng mới vào CSDL
				_context.Customer.Add(customer);
				await _context.SaveChangesAsync();

				// Chuyển hướng tới trang khác sau khi đăng ký thành công
				return RedirectToAction("Index", "Home");
			}

			// Nếu ModelState không hợp lệ, hiển thị lại form đăng ký
			return View(customer);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Login(AccountCheck checkAcc)
		{
			if (ModelState.IsValid)
			{
				// Tìm tài khoản trong cơ sở dữ liệu
				var user = await _context.Customer
					.FirstOrDefaultAsync(c => c.Account == checkAcc.Account && c.Password == checkAcc.Password);

				if (user != null)
				{
					// Đăng nhập thành công, chuyển hướng đến trang chính
					TempData["SuccessMessage"] = $"Đăng nhập thành công với tài khoản {user.Account}.";
                    Console.WriteLine("Login Success");
                    return RedirectToAction("Index", "Home");
				}
				else
				{
                    Console.WriteLine("Login Fail");
                    ModelState.AddModelError("", "Invalid login attempt.");
				}
			}
            else
            {
                // In ra lỗi nếu ModelState không hợp lệ
                foreach (var error in ModelState.Values.SelectMany(v => v.Errors))
                {
                    Console.WriteLine(error.ErrorMessage);
                }
            }

            Console.WriteLine("LoginValid Fail");

			// Nếu ModelState không hợp lệ, hiển thị lại form đăng nhập
			return View(checkAcc);
		}
	}
}
