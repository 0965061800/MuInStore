using Microsoft.EntityFrameworkCore;
using MuIn.Domain.Aggregates;

namespace MuIn.Infrastructure.SeedData
{
    public static class BrandSeedData
    {
        public static void SeedBrandata(this ModelBuilder mb)
        {
            mb.Entity<Brand>().HasData(
                new Brand
                {
                    BrandId = 1,
                    BrandName = "Logitech",
                    BrandImage = "images/brands/logitech.jpg",
                    Alias = "logitech"
                },
                new Brand
                {
                    BrandId = 2,
                    BrandName = "Razer",
                    BrandImage = "images/brands/razer.jpg",
                    Alias = "razer"
                },
                new Brand
                {
                    BrandId = 3,
                    BrandName = "Apple",
                    BrandImage = "images/brands/apple.jpg",
                    Alias = "apple"
                },
                new Brand
                {
                    BrandId = 4,
                    BrandName = "Samsung",
                    BrandImage = "images/brands/samsung.jpg",
                    Alias = "samsung"
                },
                new Brand
                {
                    BrandId = 5,
                    BrandName = "Sony",
                    BrandImage = "images/brands/sony.jpg",
                    Alias = "sony"
                }
            );
        }
    }
}
