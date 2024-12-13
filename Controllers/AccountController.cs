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
				ViewBag.Status = 3;
                _dataContext.Update(order);
                await _dataContext.SaveChangesAsync();

            }
            catch (Exception)
            {
                return BadRequest("Có lỗi xảy ra khi hủy đơn hàng");
            }
            return RedirectToAction("History", "Account");
        }

        public async Task<IActionResult> History()
        {
			if ((bool)!User.Identity?.IsAuthenticated)
			{
				return RedirectToAction("Login", "Account");
			}
			var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var userEmail = User.FindFirstValue(ClaimTypes.Email);

            var Oders = await _dataContext.Orders
                .Where(od => od.UserName == userEmail).OrderByDescending(od => od.Id).ToListAsync();
            ViewBag.UserEmail = userEmail;
            return View(Oders);
        }




    }
}