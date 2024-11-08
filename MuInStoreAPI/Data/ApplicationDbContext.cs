﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MuInStoreAPI.Models;

namespace MuInStoreAPI.Data
{
    public class ApplicationDbContext : IdentityDbContext<AppUser>
    {
        public ApplicationDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions) { }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Feature> Features { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<ProductSku> ProductSkus { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<PayStatus> PayStatuses { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<CommentImage> CommentImages { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<UserLocation>(x => x.HasKey(p => new { p.AppUserId, p.LocationId }));

            modelBuilder.Entity<UserLocation>().HasOne(u => u.AppUser).WithMany(u => u.UserLocations).HasForeignKey(p => p.AppUserId);
            modelBuilder.Entity<UserLocation>().HasOne(u => u.Location).WithMany(u => u.userLocations).HasForeignKey(p => p.LocationId);

            modelBuilder.Entity<Order>().HasOne(u => u.AppUser).WithMany(u => u.Orders).HasForeignKey(p => p.AppUserId);
            modelBuilder.Entity<Category>().HasOne(c => c.Parent).WithMany(c => c.Subcategories).HasForeignKey(c => c.ParentCatId).OnDelete(DeleteBehavior.NoAction);

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
        }
    }
}
