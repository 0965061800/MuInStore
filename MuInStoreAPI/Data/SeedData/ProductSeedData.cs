using Microsoft.EntityFrameworkCore;
using MuInStoreAPI.Models;
namespace MusInStore.Data.SeedData
{
    public static class ProductSeedData
    {
        public static void SeedProduct(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    ProductId = 1,
                    ProductName = "Grand Piano Yamaha C1 PE - C Series",
                    ProductPrice = 12000000,
                    ProductCode = "C1PE-C",
                    Active = true,
                    Alias = "yamahaC1Pe",
                    BestSeller = false,
                    BrandId = 2,
                    CategoryId = 1,
                    FeatureId = 3,
                    Description = "Thông số kỹ thuật YAMAHA C1PE. Model C1 PE Màu sắc/Lớp hoàn thiện Thùng đàn Màu sắc Polished Ebony Lớp phủ Polished Kích cỡ/Trọng lượng Kích thước Rộng 149cm (59\") Cao 101cm (40\") Dày 161cm (5'3\") Trọng lượng Trọng lượng...",
                    specifications = "Trọng lượng Kích thước Rộng 149cm (59\") Cao 101cm (40\") Dày 161cm (5'3\")",
                    VideoLink = ""
                },
                new Product
                {
                    ProductId = 2,
                    ProductName = "CASIO CT-S300",
                    ProductPrice = 18000000,
                    ProductCode = "CT300",
                    Active = true,
                    Alias = "CT300",
                    BestSeller = false,
                    BrandId = 1,
                    CategoryId = 4,
                    FeatureId = 1,
                    Description = "Thông số kỹ thuật YAMAHA C1PE. Model C1 PE Màu sắc/Lớp hoàn thiện Thùng đàn Màu sắc Polished Ebony Lớp phủ Polished Kích cỡ/Trọng lượng Kích thước Rộng 149cm (59\") Cao 101cm (40\") Dày 161cm (5'3\") Trọng lượng Trọng lượng...",
                    specifications = "Trọng lượng Kích thước Rộng 149cm (59\") Cao 101cm (40\") Dày 161cm (5'3\")",
                    Sale = (decimal)0.3,
                    VideoLink = ""
                },
                new Product
                {
                    ProductId = 3,
                    ProductName = "CASIO CDP-S160BK",
                    ProductPrice = 8200000,
                    ProductCode = "CDP-S160BK",
                    Active = true,
                    Alias = "CT300",
                    BestSeller = false,
                    BrandId = 1,
                    CategoryId = 4,
                    FeatureId = 2,
                    Description = "Thông số kỹ thuật YAMAHA C1PE. Model C1 PE Màu sắc/Lớp hoàn thiện Thùng đàn Màu sắc Polished Ebony Lớp phủ Polished Kích cỡ/Trọng lượng Kích thước Rộng 149cm (59\") Cao 101cm (40\") Dày 161cm (5'3\") Trọng lượng Trọng lượng...",
                    specifications = "Trọng lượng Kích thước Rộng 149cm (59\") Cao 101cm (40\") Dày 161cm (5'3\")",
                    Sale = (decimal)0.3,
                    VideoLink = ""
                },
                new Product
                {
                    ProductId = 4,
                    ProductName = "Roland RP-501R",
                    ProductPrice = 82000000,
                    ProductCode = "RP-501R-CB",
                    Active = true,
                    Alias = "digital-piano-rp501r",
                    BestSeller = true,
                    BrandId = 3,
                    CategoryId = 4,
                    FeatureId = 1,
                    Description = "- Sản phẩm bao gồm: Đàn + Ghế Roland RAM8065 | - Động cơ SuperNATURAL Piano cho âm thanh phong phú & chân thực | - Bàn phím PHA-4 Standard có tính năng cảm biến với độ phân giải cao | - Pedal Progressive Damper Action với phản ứng liên tục | - Hiệu ứng Headphones 3D Ambience. Kết nối với các ứng dụng thú vị | - Tính năng nhịp điệu phức tạp với điệu đệm thông minh; | - Đàn có dạng tủ đứng tiết kiệm không gian",
                    specifications = "Trọng lượng Kích thước Rộng 149cm (59\") Cao 101cm (40\") Dày 161cm (5'3\")",
                    Sale = (decimal)0.3,
                    VideoLink = ""
                }
           );
        }
    }
}
