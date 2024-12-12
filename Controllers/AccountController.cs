using FlashShop.Models;
using FlashShop.Models.ViewModels;
using FlashShop.OtherProcessing;
using FlashShop.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using System.Security.Claims;
using static System.Net.WebRequestMethods;


namespace FlashShop.Controllers
{
	public class AccountController : Controller
	{
		// TD write on 5/12
		private UserManager<AppUserModel> _userManager;
		private SignInManager<AppUserModel> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
	
        // TD write 9/12
        private readonly DataContext _dataContext;
        private readonly IConfiguration _configuration;

        // TD write on 5/12
        public AccountController(SignInManager<AppUserModel> signInManager, RoleManager<IdentityRole> roleManager, UserManager<AppUserModel> userManager, DataContext context, IConfiguration configuration)
        {
            _signInManager = signInManager;
            _roleManager = roleManager;
            _userManager = userManager;

            _dataContext = context;
            _configuration = configuration;

        }

		public IActionResult Login(string returnUrl)
		{
			return View(new LoginViewModel { ReturnUrl = returnUrl });
		}

		public IActionResult Forgot()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> SendMail(AppUserModel user)
		{
			var checkMail = await _userManager.Users.FirstOrDefaultAsync(u => u.Email == user.Email);
			if (checkMail == null)
			{
				TempData["error"] = $"Không tìm thấy email {user.Email}";
				return RedirectToAction("Forgot", "Account");
			}
			else
			{
				string token = Guid.NewGuid().ToString();
				checkMail.Token = token;
				_dataContext.Update(checkMail);
				await _dataContext.SaveChangesAsync();
				var receiver = checkMail.Email;
				var subject = "Change password for user " + checkMail.Email;
				var message = "Click on link to change password " +
					"'" + $"{Request.Scheme}://{Request.Host}/Account/NewPass?email="
					+ checkMail.Email + "&token=" + token + "'";
                var emailService = new EmailService(_configuration);
				await emailService.SendEmailAsync(receiver, subject, message);
            }
			TempData["success"] = $"Hãy kiểm tra email {user.Email} của bạn";
			return RedirectToAction("Forgot", "Account");
		}

		public async Task<IActionResult> NewPass(AppUserModel user, string token)
		{
			var checkuser = await _userManager.Users
                .Where(u => u.Email == user.Email)
				.Where(u => u.Token == user.Token).FirstOrDefaultAsync();

			if (checkuser != null) 
			{
                ViewBag.Email = checkuser.Email;
				ViewBag.Token = token;
            }
			else
			{
				TempData["error"] = "Email không tìm thấy hoặc token không chính xác";
				return RedirectToAction("Forgot", "Account");
			}

			return View();
		}

		[HttpPost]
		public async Task<IActionResult> UpdateNewPassword(AppUserModel user, string token)
		{
			var checkuser = await _userManager.Users
				.Where(u => u.Email == user.Email)
				.Where(u => u.Token == user.Token).FirstOrDefaultAsync();

			if (checkuser != null)
			{ 
				string newtoken = Guid.NewGuid().ToString();
				var passwordHasher = new PasswordHasher<AppUserModel>();
				var passwordHash = passwordHasher.HashPassword(checkuser, user.PasswordHash);

				checkuser.PasswordHash = passwordHash;
				checkuser.Token = newtoken; 

				await _userManager.UpdateAsync(checkuser);
				TempData["success"] = "Cập nhật mật khẩu thành công.";
				return RedirectToAction("Login", "Account");
			}
			else
			{
				TempData["error"] = "Email không tồn tại hoặc token không hợp lệ";
				return RedirectToAction("Forgot", "Account");
			}
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Login(LoginViewModel LVM)
		{
			if (ModelState.IsValid)
			{
				Microsoft.AspNetCore.Identity.SignInResult rs = await _signInManager.PasswordSignInAsync(LVM.userName, LVM.password, false, false);
				if (rs.Succeeded)
				{
					TempData["success"] = $"Đăng nhập tài khoản {LVM.userName} thành công.";
					return Redirect(LVM.ReturnUrl ?? "/");
				}
				ModelState.AddModelError("", "Thông tin đăng nhập không chính xác.");
			}
			//TempData["error"] = $"Thông tin đăng nhập không chính xác.";
			//ModelState.AddModelError("", "Thông tin đăng nhập không chính xác.");
			return View(LVM);
		}

		public IActionResult Register()
		{
			return View();
		}

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(UserModel u)
        {
            if (ModelState.IsValid)
            {
                AppUserModel newUser = new AppUserModel { UserName = u.userName, Email = u.email };
                IdentityResult rs = await _userManager.CreateAsync(newUser, u.password);
                if (rs.Succeeded)
                {
                    // Gán role mặc định "User" cho tài khoản
                    var addToRoleResult = await _userManager.AddToRoleAsync(newUser, "user");
                    if (addToRoleResult.Succeeded)
                    {
                        TempData["success"] = $"Đăng ký tài khoản thành công";
                        return RedirectToAction("Login", "Account");
                    }

                    // Nếu lỗi khi thêm role
                    foreach (IdentityError error in addToRoleResult.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }

                // Nếu lỗi khi tạo tài khoản
                foreach (IdentityError error in rs.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            return View();
        }

        public async Task<IActionResult> Logout(string returnUrl = "/")
		{
			await _signInManager.SignOutAsync();
			return Redirect(returnUrl);
		}
		public async Task<IActionResult> CancelOrder(string ordercode)
		{
			if ((bool)!User.Identity?.IsAuthenticated)
			{
				return RedirectToAction("Login", "Account");

			}
			try
			{
				var order = await _dataContext.Orders.Where(o => o.OrderCode == ordercode).FirstAsync();
				order.Status = 3;
				_dataContext.Update(order);
				await _dataContext.SaveChangesAsync();
					
			}
			catch (Exception ex)
			{
				return BadRequest("Có lỗi xảy ra khi hủy đơn hàng");
			}
			return RedirectToAction("History", "Account");
		}

		public async Task<IActionResult>  History()
		{
			//if((bool) !User.Identity?.IsAuthenticated)
			//{
			//	return RedirectToAction("Login", "Account");
			//}
			var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
			var userEmail = User.FindFirstValue(ClaimTypes.Email);

			var Oders = await _dataContext.Orders
				.Where(od => od.UserName == userEmail).OrderByDescending(od => od.Id).ToListAsync();
			ViewBag.UserEmail = userEmail;
			return View(Oders);
		}

		//      private readonly DataContext _context;
		//      private readonly IConfiguration _configuration;

		//      // Constructor duy nhất để khởi tạo DataContext
		//      public AccountController(DataContext context, IConfiguration configuration)
		//{
		//	_context = context;
		//	_configuration = configuration;
		//}

		//[HttpGet]
		//public IActionResult Login()
		//{
		//	Console.WriteLine("LoginPage");
		//	return View(new AccountCheck());
		//}

		//[HttpGet]
		//public IActionResult Register()
		//{
		//	return View();
		//}

		//[HttpGet]
		//public IActionResult Forgot()
		//{
		//	return View();
		//}

		//[HttpGet]
		//public IActionResult InputOTP()
		//{
		//	return View();
		//}

		//[HttpPost]
		//[ValidateAntiForgeryToken]
		//public async Task<IActionResult> Register(Users customer)
		//{
		//	if (ModelState.IsValid)
		//	{
		//		// Kiểm tra nếu tài khoản đã tồn tại
		//		var existingAccount = await _context.Users
		//			.FirstOrDefaultAsync(c => c.account == customer.account);

		//		if (existingAccount != null)
		//		{
		//			TempData["error"] = $"Tài khoản hoặc tên đăng nhập đã tồn tại";
		//			ModelState.AddModelError("Account", "Account already exists.");
		//			return View(customer); // Hiển thị lại form với thông báo lỗi
		//		}

		//		// Lưu thông tin người dùng mới vào CSDL
		//		_context.Users.Add(customer);
		//		await _context.SaveChangesAsync();
		//		TempData["success"] = $"Đăng ký tài khoản thành công";

		//		// Chuyển hướng tới trang khác sau khi đăng ký thành công
		//		return RedirectToAction("Login", "Account");
		//	}

		//	// Nếu ModelState không hợp lệ, hiển thị lại form đăng ký
		//	return View(customer);
		//}

		//[HttpPost]
		//[ValidateAntiForgeryToken]
		//public async Task<IActionResult> Login(AccountCheck checkAcc)
		//{
		//	if (ModelState.IsValid)
		//	{
		//		// Tìm tài khoản trong cơ sở dữ liệu
		//		var user = await _context.Users	
		//			.FirstOrDefaultAsync(c => c.account == checkAcc.account && c.password == checkAcc.password);

		//		if (user != null)
		//		{
		//			// Đăng nhập thành công, chuyển hướng đến trang chính
		//                  TempData["success"] = $"Đăng nhập thành công với tài khoản {user.account}.";
		//                  Console.WriteLine("Login Success");
		//                  return RedirectToAction("Index", "Home");
		//		}
		//		else
		//		{
		//                  Console.WriteLine("Login Fail");
		//                  ModelState.AddModelError("", "Invalid login attempt.");
		//		}
		//	}
		//          else
		//          {
		//              // In ra lỗi nếu ModelState không hợp lệ
		//              foreach (var error in ModelState.Values.SelectMany(v => v.Errors))
		//              {
		//                  Console.WriteLine(error.ErrorMessage);
		//              }
		//          }

		//          Console.WriteLine("LoginValid Fail");

		//	// Nếu ModelState không hợp lệ, hiển thị lại form đăng nhập
		//	return View(checkAcc);
		//}

		//[HttpPost]
		//[ValidateAntiForgeryToken]
		//      public async Task<IActionResult> Forgot(string email)
		//{
		//	if (string.IsNullOrEmpty(email))
		//	{
		//		ModelState.AddModelError("", "Email can't be null!");
		//		return View();
		//	}

		//	var emailvalid = await _context.Users.FirstOrDefaultAsync(c => c.email == email);

		//	if (emailvalid != null)
		//          {
		//		string SaveOTP = GenerateOTP();
		//              TempData["OTP"] = SaveOTP;
		//		TempData["Email"] = email;
		//		var emailService = new EmailService(_configuration); 
		//		await emailService.SendEmailAsync(emailvalid.email, "Your OTP Code", $"Your OTP is: {SaveOTP}");
		//		TempData["SuccessMessage"] = $"Đã gửi OTP về Email {emailvalid.email}";
		//              TempData["success"] = $"Đã gửi OTP về Email {emailvalid.email}";
		//              return RedirectToAction("InputOTP");
		//	}
		//	else
		//	{
		//		ModelState.AddModelError("", "Email is not exist.");
		//		return View();
		//	}
		//}

		//[HttpPost]
		//[ValidateAntiForgeryToken]
		//      public async Task<IActionResult> InputOTP(string OTP)
		//{
		//          var GetOtp = TempData["OTP"]?.ToString();
		//          var email = TempData["Email"]?.ToString();

		//          if (GetOtp == OTP)
		//          {
		//              TempData["SuccessMessage"] = $"OTP verified successfully for {email}.";
		//              TempData["success"] = $"OTP verified successfully for {email}.";
		//              // Redirect to a password reset view or perform other actions
		//              return RedirectToAction("ResetPassword");
		//          }
		//          else
		//          {
		//              ModelState.AddModelError("", "Invalid OTP.");
		//              return View("InputOTP"); // Stay on the OTP input view
		//          }
		//      }

		//      [HttpGet]
		//      public IActionResult ResetPassword()
		//      {
		//          return View();
		//      }

		//      [HttpPost]
		//      [ValidateAntiForgeryToken]
		//      public async Task<IActionResult> ResetPassword(string newPassword, string confirmPassword)
		//      {
		//          if (newPassword != confirmPassword)
		//          {
		//              ModelState.AddModelError("", "Passwords do not match.");
		//              return View();
		//          }

		//          var email = TempData["Email"]?.ToString();
		//          if (string.IsNullOrEmpty(email))
		//          {
		//              return RedirectToAction("Login"); // Nếu không có email trong TempData, chuyển hướng tới login
		//          }

		//          // Tìm tài khoản dựa trên email đã lưu
		//          var customer = await _context.Users.FirstOrDefaultAsync(c => c.email == email);
		//          if (customer != null)
		//          {
		//              // Cập nhật mật khẩu mới cho người dùng
		//              customer.password = newPassword; 
		//              await _context.SaveChangesAsync();

		//              TempData["SuccessMessage"] = "Your password has been reset successfully!";
		//              TempData["success"] = "Your password has been reset successfully!";
		//              return RedirectToAction("Login"); // Chuyển hướng về trang đăng nhập
		//          }
		//          else
		//          {
		//              ModelState.AddModelError("", "Error occurred while resetting the password.");
		//              return View();
		//          }
		//      }

		//      private string GenerateOTP()
		//{
		//          Random random = new Random();
		//          return random.Next(100000, 999999).ToString();
		//      }
	}
}