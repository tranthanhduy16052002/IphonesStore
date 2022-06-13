using Microsoft.EntityFrameworkCore;
namespace IphonesStore.Models
{
    public class IphonesStoreDbContext : DbContext
    {
        public IphonesStoreDbContext(DbContextOptions<IphonesStoreDbContext> options)
        : base(options) { }
        public DbSet<Iphone> Iphones { get; set; }
        public DbSet<Order> Orders { get; set; }
    }
}