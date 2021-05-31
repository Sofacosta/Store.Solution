using Microsoft.EntityFrameworkCore;

namespace Store.Models
{
  public class StoreContext : DbContext
  {
    public virtual DbSet<Product> Products { get; set; }
    public DbSet<Invoice> Invoices { get; set; }

    public StoreContext(DbContextOptions options) : base(options) { }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      optionsBuilder.UseLazyLoadingProxies();
    }
  }
}