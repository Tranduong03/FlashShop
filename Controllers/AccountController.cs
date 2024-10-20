using FlashShop.Models;
using FlashShop.OtherProcessing;
using FlashShop.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static System.Net.WebRequestMethods;

namespace FlashShop.Controllers
{
	public class AccountController : Controller
	{
		private readonly DataContext _context;
		private readonly IConfiguration _configuration;

		// Constructor duy nhất để khởi tạo DataContext
		public AccountController(DataContext context, IConfiguration configuration)
		{
			_context = context;
			_configuration = configuration;
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

		[HttpGet]
		public IActionResult Forgot()
		{
			return View();
		}

		[HttpGet]
		public IActionResult InputOTP()
		{
			return View();
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Register(Users customer)
		{
			if (ModelState.IsValid)
			{
				// Kiểm tra nếu tài khoản đã tồn tại
				var existingAccount = await _context.Users
					.FirstOrDefaultAsync(c => c.account == customer.account);

				if (existingAccount != null)
				{
					ModelState.AddModelError("Account", "Account already exists.");
					return View(customer); // Hiển thị lại form với thông báo lỗi
				}

				// Lưu thông tin người dùng mới vào CSDL
				_context.Users.Add(customer);
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
				var user = await _context.Users	
					.FirstOrDefaultAsync(c => c.account == checkAcc.account && c.password == checkAcc.password);

				if (user != null)
				{
					// Đăng nhập thành công, chuyển hướng đến trang chính
					TempData["SuccessMessage"] = $"Đăng nhập thành công với tài khoản {user.account}.";
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

		[HttpPost]
		[ValidateAntiForgeryToken]
        public async Task<IActionResult> Forgot(string email)
		{
			if (string.IsNullOrEmpty(email))
			{
				ModelState.AddModelError("", "Email can't be null!");
				return View();
			}

			var emailvalid = await _context.Users.FirstOrDefaultAsync(c => c.email == email);

			if (emailvalid != null)
            {
				string SaveOTP = GenerateOTP();
                TempData["OTP"] = SaveOTP;
				TempData["Email"] = email;// Store OTP in TempData (or session/database)
				var emailService = new EmailService(_configuration);  // Inject email service
				await emailService.SendEmailAsync(emailvalid.email, "Your OTP Code", $"Your OTP is: {SaveOTP}");
				TempData["SuccessMessage"] = $"Đã gửi OTP về Email {emailvalid.email}";

				return RedirectToAction("InputOTP");
			}
			else
			{
				ModelState.AddModelError("", "Email is not exist.");
				return View();
			}
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
        public async Task<IActionResult> InputOTP(string OTP)
		{
            var GetOtp = TempData["OTP"]?.ToString();
            var email = TempData["Email"]?.ToString();

            if (GetOtp == OTP)
            {
                TempData["SuccessMessage"] = $"OTP verified successfully for {email}.";
                // Redirect to a password reset view or perform other actions
                return RedirectToAction("ResetPassword");
            }
            else
            {
                ModelState.AddModelError("", "Invalid OTP.");
                return View("InputOTP"); // Stay on the OTP input view
            }
        }

        [HttpGet]
        public IActionResult ResetPassword()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ResetPassword(string newPassword, string confirmPassword)
        {
            if (newPassword != confirmPassword)
            {
                ModelState.AddModelError("", "Passwords do not match.");
                return View();
            }

            var email = TempData["Email"]?.ToString();
            if (string.IsNullOrEmpty(email))
            {
                return RedirectToAction("Login"); // Nếu không có email trong TempData, chuyển hướng tới login
            }

            // Tìm tài khoản dựa trên email đã lưu
            var customer = await _context.Users.FirstOrDefaultAsync(c => c.email == email);
            if (customer != null)
            {
                // Cập nhật mật khẩu mới cho người dùng
                customer.password = newPassword; 
                await _context.SaveChangesAsync();

                TempData["SuccessMessage"] = "Your password has been reset successfully!";
                return RedirectToAction("Login"); // Chuyển hướng về trang đăng nhập
            }
            else
            {
                ModelState.AddModelError("", "Error occurred while resetting the password.");
                return View();
            }
        }

        private string GenerateOTP()
		{
            Random random = new Random();
            return random.Next(100000, 999999).ToString();
        }
	}
}
