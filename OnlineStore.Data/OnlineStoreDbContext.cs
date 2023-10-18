using Microsoft.EntityFrameworkCore;
using OnlineStore.Data.Entities;

#nullable disable
namespace OnlineStore.Data
{
    public class OnlineStoreDbContext : DbContext
    {
        public OnlineStoreDbContext() { }

        public OnlineStoreDbContext(DbContextOptions<OnlineStoreDbContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=localhost\SQLEXPRESS;Database=OnlineStore;Trusted_Connection=True;");
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
    }
}
