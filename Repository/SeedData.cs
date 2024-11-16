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
            if (!_context.Categories.Any())
            {
                var categories = new List<CategoryModel>
                {
                    new CategoryModel { CategoryName = "Sách thiếu nhi" },
                    new CategoryModel { CategoryName = "Truyện tranh" },
                    new CategoryModel { CategoryName = "Sách tâm lý - tình cảm" },
                    new CategoryModel { CategoryName = "Sách văn hóa-xã hội" },
                    new CategoryModel { CategoryName = "Sách hướng dẫn" },
                    new CategoryModel { CategoryName = "Sách khoa học - viễn tưởng" },
                    new CategoryModel { CategoryName = "Sách lịch sử" },
                    new CategoryModel { CategoryName = "Sách giáo khoa" },
                    new CategoryModel { CategoryName = "Khác" }
                };

                _context.Categories.AddRange(categories);
                _context.SaveChanges();
            }

            if (!_context.Publishers.Any())
            {
                var nxb = new PublisherModel { PublisherName = "Khác" };
                _context.Publishers.Add(nxb);
                _context.SaveChanges();
            }

            // Lấy lại thể loại và nhà xuất bản vừa thêm để sử dụng ID
            var category = _context.Categories.FirstOrDefault(c => c.CategoryName == "Khác");
            if (category == null)
            {
                throw new InvalidOperationException("Category 'Khác' was not found.");
            }

            var publisher = _context.Publishers.FirstOrDefault(p => p.PublisherName == "Khác");
            if (publisher == null)
            {
                throw new InvalidOperationException("Publisher 'Khác' was not found.");
            }

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
