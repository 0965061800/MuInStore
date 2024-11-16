using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MuIn.Domain.Aggregates;
using MuIn.Domain.Aggregates.OrderAggregate;
using MuIn.Domain.Aggregates.ProductAggregate;
using MuIn.Domain.Aggregates.UserAggregate;
using MuIn.Infrastructure.SeedData;

namespace MuIn.Infrastructure
{
    public class MuInDbContext : IdentityDbContext<AppUser>
    {
        public MuInDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions) { }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<Order> Orders { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Brand>().HasMany(b => b.Products).WithOne(p => p.Brand).OnDelete(DeleteBehavior.SetNull);
            modelBuilder.Entity<Category>().HasMany(b => b.Products).WithOne(p => p.Category).OnDelete(DeleteBehavior.SetNull);
            List<IdentityRole> roles = new List<IdentityRole>
            {
                new IdentityRole
                {
                    Name = "Admin",
                    NormalizedName = "ADMIN",
                },
                new IdentityRole
                {
                    Name = "User",
                    NormalizedName = "USER"
                }
            };
            modelBuilder.Entity<IdentityRole>().HasData(roles);
            modelBuilder.SeedBrandata();
            modelBuilder.SeedCatData();
            modelBuilder.SeedColorData();
            modelBuilder.SeedProductData();
            modelBuilder.SeedProductSkuData();
        }
    }
}
