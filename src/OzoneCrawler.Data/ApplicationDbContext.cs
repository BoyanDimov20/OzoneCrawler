using Microsoft.EntityFrameworkCore;
using OzoneCrawler.Data.Models;

namespace OzoneCrawler.Data
{
    public class ApplicationDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;Database=OzoneCrawler;Trusted_Connection=True;");
        }
        public DbSet<Product> Products { get; set; }

    }
}
