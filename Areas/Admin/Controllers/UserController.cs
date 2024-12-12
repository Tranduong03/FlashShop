using FlashShop.Models;
using FlashShop.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace FlashShop.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/User")]
    [Authorize(Roles = "Admin")]
    public class UserController : Controller
    {
        private readonly UserManager<AppUserModel> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly DataContext _dataContext;

        public UserController(UserManager<AppUserModel> userManager, RoleManager<IdentityRole> roleManager, DataContext dataContext)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _dataContext = dataContext;
        }

        [HttpGet]
        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            var usersWithRoles = await (from u in _dataContext.Users
                                        join ur in _dataContext.UserRoles on u.Id equals ur.UserId
                                        join r in _dataContext.Roles on ur.RoleId equals r.Id
                                        select new { User = u, RoleName = r.Name }).ToListAsync();

            return View(usersWithRoles);
        }     

        private void AddIdentityErrors(IdentityResult identityResult)
        {
            foreach (var error in identityResult.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description); 
            }
        }

        [HttpGet]
        [Route("Edit")]
        public async Task<IActionResult> Edit(string Id)
        {
            if (string.IsNullOrEmpty(Id))
            {
                return NotFound();
            }

            var user = await _userManager.FindByIdAsync(Id);
            if (user == null)
            {
                return NotFound();
            }

            var roles = await _roleManager.Roles.ToListAsync();
            ViewBag.Roles = new SelectList(roles, "Id", "Name");
            return View(user);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Edit")]
        public async Task<IActionResult> Edit(string Id, AppUserModel user)
        {
            var existingUser = await _userManager.FindByIdAsync(Id);
            if (existingUser == null)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                // Lấy tất cả các roles hiện tại của user
                var currentRoles = await _userManager.GetRolesAsync(existingUser);

                // Tìm role mới dựa trên RoleId mà admin chọn
                var newRole = await _roleManager.FindByIdAsync(user.RoleId);
                if (newRole == null)
                {
                    TempData["errorAdmin"] = "Vai trò không tồn tại!";
                    return View(existingUser);
                }

                // Xóa user khỏi tất cả roles hiện tại
                var removeFromRolesResult = await _userManager.RemoveFromRolesAsync(existingUser, currentRoles);
                if (!removeFromRolesResult.Succeeded)
                {
                    AddIdentityErrors(removeFromRolesResult);
                    TempData["errorAdmin"] = "Không thể xóa quyền cũ của người dùng!";
                    return View(existingUser);
                }

                // Thêm user vào role mới
                var addToRoleResult = await _userManager.AddToRoleAsync(existingUser, newRole.Name);
                if (!addToRoleResult.Succeeded)
                {
                    AddIdentityErrors(addToRoleResult);
                    TempData["errorAdmin"] = "Không thể thêm quyền mới cho người dùng!";
                    return View(existingUser);
                }

                TempData["successAdmin"] = "Cập nhật quyền truy cập thành công";
                return RedirectToAction("Index", "User");
            }

            // Nếu có lỗi trong model, trả về trang chỉnh sửa cùng danh sách vai trò
            var roles = await _roleManager.Roles.ToListAsync();
            ViewBag.Roles = new SelectList(roles, "Id", "Name");

            TempData["errorAdmin"] = "Thay đổi quyền truy cập thất bại, thử lại!";
            return View(existingUser);
        }

    }
}
