using FlashShop.Models;
using FlashShop.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System.Drawing;
using System.IO;

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

        [HttpGet]
        [Route("ExportUsersToExcel")]
        public async Task<IActionResult> ExportUsersToExcel()
        {
            var usersWithRoles = await (from u in _dataContext.Users
                                        join ur in _dataContext.UserRoles on u.Id equals ur.UserId
                                        join r in _dataContext.Roles on ur.RoleId equals r.Id
                                        select new
                                        {
                                            u.Id,
                                            u.UserName,
                                            u.Email,
                                            u.PasswordHash,
                                            RoleName = r.Name
                                        }).ToListAsync();

            using (var package = new ExcelPackage())
            {
                var worksheet = package.Workbook.Worksheets.Add("Users");

                // Tiêu đề cột
                worksheet.Cells[1, 1].Value = "ID";
                worksheet.Cells[1, 2].Value = "Tên người dùng";
                worksheet.Cells[1, 3].Value = "Email";
                worksheet.Cells[1, 4].Value = "Mật khẩu băm";
                worksheet.Cells[1, 5].Value = "Quyền truy cập";

                // Thêm dữ liệu vào Excel
                int row = 2;
                foreach (var user in usersWithRoles)
                {
                    worksheet.Cells[row, 1].Value = user.Id;
                    worksheet.Cells[row, 2].Value = user.UserName;
                    worksheet.Cells[row, 3].Value = user.Email;
                    worksheet.Cells[row, 4].Value = user.PasswordHash;
                    worksheet.Cells[row, 5].Value = user.RoleName;
                    row++;
                }

                // Định dạng bảng
                using (var range = worksheet.Cells[1, 1, 1, 5])
                {
                    range.Style.Font.Bold = true;
                    range.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    range.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    range.Style.Fill.BackgroundColor.SetColor(Color.LightGray);
                }

                worksheet.Cells.AutoFitColumns();

                // Lưu dữ liệu vào MemoryStream
                var stream = new MemoryStream();
                package.SaveAs(stream);
                stream.Position = 0;

                // Đặt tên file Excel
                var fileName = "Danh_sach_nguoi_dung_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".xlsx";
                return File(stream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", fileName);
            }
        }
    }
}
