using FlashShop.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
//using System.Data.Entity;

namespace FlashShop.Repository
{
    public class DataContext : IdentityDbContext <AppUserModel>
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        public DataContext()
        {

        }

        public DbSet<CategoryModel> Categories { get; set; }
        public DbSet<BookModel> Books { get; set; }
        public DbSet<RatingModel> Ratings { get; set; }
        public DbSet<PublisherModel> Publishers { get; set; }
        public DbSet<OrderModel> Orders { get; set; }
        public DbSet<OrderDetails> OrdersDetails { get; set; } 

    }
}
