using FlashShop.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System.Drawing;
using System.IO;
using DinkToPdf;
using DinkToPdf.Contracts;



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

        public async Task<IActionResult> ExportOrdersToExcel(string orderCode)
        {
            // Lọc dữ liệu chỉ lấy chi tiết đơn hàng với mã đơn hàng cụ thể
            var orderDetails = await _dataContext.OrdersDetails
                .Include(od => od.Book)
                .Where(od => od.OrderCode == orderCode)
                .ToListAsync();

            if (!orderDetails.Any())
            {
                return NotFound("Không tìm thấy chi tiết cho mã đơn hàng này.");
            }

            using (var package = new ExcelPackage())
            {
                // Tạo sheet hóa đơn
                var worksheet = package.Workbook.Worksheets.Add("Hóa đơn");

                // Tiêu đề cột
                worksheet.Cells[1, 1].Value = "ID Chi tiết";
                worksheet.Cells[1, 2].Value = "Người đặt";
                worksheet.Cells[1, 3].Value = "Tên sách";
                worksheet.Cells[1, 4].Value = "Giá";
                worksheet.Cells[1, 5].Value = "Số lượng";
                worksheet.Cells[1, 6].Value = "Thành tiền";

                // Ghi dữ liệu vào sheet
                int row = 2;
                foreach (var detail in orderDetails)
                {
                    worksheet.Cells[row, 1].Value = detail.Id;
                    worksheet.Cells[row, 2].Value = detail.UserName;
                    worksheet.Cells[row, 3].Value = detail.Book?.Title ?? "Không rõ";
                    worksheet.Cells[row, 4].Value = detail.Price;
                    worksheet.Cells[row, 5].Value = detail.Quantity;
                    worksheet.Cells[row, 6].Value = detail.Price * detail.Quantity;

                    row++;
                }

                // Tổng tiền
                worksheet.Cells[row, 5].Value = "Tổng cộng:";
                worksheet.Cells[row, 5].Style.Font.Bold = true;
                worksheet.Cells[row, 6].Formula = $"SUM(F2:F{row - 1})";
                worksheet.Cells[row, 6].Style.Font.Bold = true;

                // Định dạng bảng
                FormatWorksheet(worksheet, 6);

                // Lưu file vào MemoryStream
                var stream = new MemoryStream();
                package.SaveAs(stream);
                stream.Position = 0;

                // Tên file
                var fileName = "HoaDon_" + orderCode + "_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".xlsx";
                return File(stream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", fileName);
            }
        }


        // Hàm hỗ trợ định dạng bảng
        private void FormatWorksheet(ExcelWorksheet worksheet, int colCount)
        {
            using (var range = worksheet.Cells[1, 1, 1, colCount])
            {
                range.Style.Font.Bold = true;
                range.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                range.Style.Fill.PatternType = ExcelFillStyle.Solid;
                range.Style.Fill.BackgroundColor.SetColor(Color.LightGray);
            }

            worksheet.Cells.AutoFitColumns();
        }
    }
}
