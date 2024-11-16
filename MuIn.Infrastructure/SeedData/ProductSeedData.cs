using Microsoft.EntityFrameworkCore;
using MuIn.Domain.Aggregates.ProductAggregate;

namespace MuIn.Infrastructure.SeedData
{
    public static class ProductSeedData
    {
        public static void SeedProductData(this ModelBuilder mb)
        {
            mb.Entity<Product>().HasData(
               new Product
               {
                   ProductId = 1,
                   ProductName = "Logitech Wireless Mouse",
                   ProductCode = "WM123",
                   ProductPrice = 25.99m,
                   BestSeller = true,
                   Sale = 0.15m,
                   Alias = "logitech-wireless-mouse",
                   Active = true,
                   CreatAt = DateTime.Now,
                   ProductImage = "images/products/mouse.jpg",
                   ImageName = "mouse.jpg",
                   CategoryId = 1,  // Computer Accessories
                   BrandId = 1,     // Logitech
               },
    new Product
    {
        ProductId = 2,
        ProductName = "Razer Mechanical Gaming Keyboard",
        ProductCode = "RK123",
        ProductPrice = 99.99m,
        BestSeller = true,
        Sale = 0.10m,
        Alias = "razer-gaming-keyboard",
        Active = true,
        CreatAt = DateTime.Now,
        ProductImage = "images/products/keyboard.jpg",
        ImageName = "keyboard.jpg",
        CategoryId = 2,  // Keyboards
        BrandId = 2,     // Razer
    },
    new Product
    {
        ProductId = 3,
        ProductName = "Apple Magic Mouse",
        ProductCode = "AMM100",
        ProductPrice = 79.99m,
        BestSeller = false,
        Sale = 0.05m,
        Alias = "apple-magic-mouse",
        Active = true,
        CreatAt = DateTime.Now,
        ProductImage = "images/products/apple-magic-mouse.jpg",
        ImageName = "apple-magic-mouse.jpg",
        CategoryId = 3,  // Mice & Pointing Devices
        BrandId = 3,     // Apple
    },
    new Product
    {
        ProductId = 4,
        ProductName = "Samsung Galaxy S21",
        ProductCode = "SGS21",
        ProductPrice = 799.99m,
        BestSeller = true,
        Sale = 0.10m,
        Alias = "samsung-galaxy-s21",
        Active = true,
        CreatAt = DateTime.Now,
        ProductImage = "images/products/galaxy-s21.jpg",
        ImageName = "galaxy-s21.jpg",
        CategoryId = 4,  // Smartphones
        BrandId = 4,     // Samsung
    },
    new Product
    {
        ProductId = 5,
        ProductName = "Apple MacBook Air M1",
        ProductCode = "MBA-M1",
        ProductPrice = 999.99m,
        BestSeller = true,
        Sale = 0.15m,
        Alias = "apple-macbook-air-m1",
        Active = true,
        CreatAt = DateTime.Now,
        ProductImage = "images/products/macbook-air.jpg",
        ImageName = "macbook-air.jpg",
        CategoryId = 5,  // Laptops
        BrandId = 3,     // Apple
    },
    new Product
    {
        ProductId = 6,
        ProductName = "Sony WH-1000XM4 Wireless Headphones",
        ProductCode = "WH1000XM4",
        ProductPrice = 349.99m,
        BestSeller = true,
        Sale = 0.10m,
        Alias = "sony-wh1000xm4-headphones",
        Active = true,
        CreatAt = DateTime.Now,
        ProductImage = "images/products/sony-headphones.jpg",
        ImageName = "sony-headphones.jpg",
        CategoryId = 6,  // Headphones
        BrandId = 5,     // Sony
    },
    new Product
    {
        ProductId = 7,
        ProductName = "Apple iPad Air 2022",
        ProductCode = "IPA2022",
        ProductPrice = 599.99m,
        BestSeller = false,
        Sale = 0.05m,
        Alias = "apple-ipad-air-2022",
        Active = true,
        CreatAt = DateTime.Now,
        ProductImage = "images/products/ipad-air-2022.jpg",
        ImageName = "ipad-air-2022.jpg",
        CategoryId = 7,  // Tablets
        BrandId = 3,     // Apple
    }
            );
        }
    }
}
