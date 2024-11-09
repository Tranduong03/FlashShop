using FlashShop.Models;
using Microsoft.EntityFrameworkCore;

namespace FlashShop.Repository
{
    public class SeedData
    {
        public static void SeedingData(DataContext _context)
        {
            _context.Database.Migrate();

            // Thêm thể loại và nhà xuất bản nếu chưa tồn tại
            if (!_context.Categories.Any(c => c.CategoryName == "Truyện tranh"))
            {
                var theloai = new CategoryModel { CategoryName = "Truyện tranh" };
                _context.Categories.Add(theloai);
                _context.SaveChanges();
            }

            if (!_context.Publishers.Any(p => p.PublisherName == "Kim Đồng"))
            {
                var nxb = new PublisherModel { PublisherName = "Kim Đồng" };
                _context.Publishers.Add(nxb);
                _context.SaveChanges();
            }

            // Lấy lại thể loại và nhà xuất bản vừa thêm để sử dụng ID
            var category = _context.Categories.FirstOrDefault(c => c.CategoryName == "Truyện tranh");
            var publisher = _context.Publishers.FirstOrDefault(p => p.PublisherName == "Kim Đồng");

            // Thêm sách mới nếu chưa có
            if (!_context.Books.Any(b => b.Title == "Conan tập 1"))
            {
                _context.Books.Add(new BookModel
                {
                    Title = "Conan tập 1",
                    Price = 100,
                    Quantity = 1,
                    ImgLink = "book1.jpg",
                    Description = "conan tap 1",
                    Author = "Fujio F. Fujiko",
                    Publication = 1999,
                    Point = 8,
                    CategoryId = category.CategoryId,
                    PublisherId = publisher.PublisherId
                });
                _context.SaveChanges();
            }

            // Seed user admin nếu chưa có
            if (!_context.Users.Any(u => u.userName == "admin"))
            {
                Users adminUser = new Users
                {
                    userName = "admin",
                    email = "phiduong.it.hcm@gmail.com",
                    account = "admin",
                    password = "admin", // Nên mã hóa mật khẩu trước khi lưu vào cơ sở dữ liệu
                    typeUser = true // Quyền admin
                };
                _context.Users.Add(adminUser);
                _context.SaveChanges();
            }
        }
    }
}
