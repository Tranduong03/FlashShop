using FlashShop.Models;
using Microsoft.EntityFrameworkCore;

namespace FlashShop.Repository
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        public DbSet<Users> Users { get; set; }
    }
}
