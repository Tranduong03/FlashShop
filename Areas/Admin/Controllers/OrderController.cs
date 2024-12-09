using FlashShop.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FlashShop.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class OrderController : Controller
	{
        private readonly DataContext _dataContext;

        public OrderController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public async Task<IActionResult> Index()
		{
			return View(await _dataContext.Orders.OrderByDescending(p => p.Id).ToListAsync());
		}

        public async Task<IActionResult> ViewOrder(string ordercode)
        {
            var DetailsOrder = await _dataContext.OrdersDetails.Include(od => od.Book).Where(od => od.OrderCode==ordercode).ToListAsync();
            return View(DetailsOrder);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var order = await _dataContext.Orders.FindAsync(id);
            if (order == null)
            {
                TempData["errorAdmin"] = "Không tìm thấy đơn để xóa!";
                return NotFound();
            }

            _dataContext.Orders.Remove(order);
            await _dataContext.SaveChangesAsync();

            TempData["successAdmin"] = "Đơn hàng đã được xóa thành công!";
            return RedirectToAction("Index");
        }
    }
}
