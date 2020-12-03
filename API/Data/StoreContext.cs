using System.Reflection;
using API.Models;
using API.Models.OrderAggregate;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class StoreContext : DbContext
    {
        public StoreContext(DbContextOptions<StoreContext> options) : base(options)
        {
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductType> ProductTypes { get; set; }
        public DbSet<ProductBrand> ProductBrands { get; set; }
        public DbSet<ProductSizeRel> ProductSizesRel { get; set; }
        public DbSet<Size> Sizes {get; set;}
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<DeliveryMethod> DeliveryMethods { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductSizeRel>()
                .HasOne(pt => pt.Product)
                .WithMany(p => p.ProductSizes)
                .HasForeignKey(pt => pt.ProductId);

            modelBuilder.Entity<ProductSizeRel>()
                .HasOne(pt => pt.Size)
                .WithMany(t => t.ProductSizes)
                .HasForeignKey(pt => pt.SizeId);
        } /// ovo je moglo u svoj poseban config file, nego ajde mrzi me
    }
}