using FlashShop.Models;
using Microsoft.EntityFrameworkCore;
//using System.Data.Entity;

namespace FlashShop.Repository
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        public DataContext()
        {

        }

        public DbSet<Users> Users { get; set; }
        public DbSet<CategoryModel> Categories { get; set; }
        public DbSet<BookModel> Books { get; set; }
        public DbSet<PublisherModel> Publishers { get; set; }
    }
}
