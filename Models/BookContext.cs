using FlashShop.Models;
using Microsoft.EntityFrameworkCore;

public class BookContext : DbContext
{
    public DbSet<Book> Books { get; set; }
    public DbSet<Category> Categories { get; set; }

    private readonly string _connectionString;

    public BookContext(string connectionString)
    {
        _connectionString = connectionString;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }
    }
}
