using Microsoft.EntityFrameworkCore;
using MuInStoreAPI.Models;

namespace MuInStore.Data.SeedData
{
    public static class BrandSeedData
    {
        public static void SeedBrand(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Brand>().HasData(
                new Brand
                {
                    BrandId = 1,
                    BrandName = "Casio",
                    BrandImage = "",
                    Alias = "casio",
                },
                new Brand
                {
                    BrandId = 2,
                    BrandName = "Yamaha",
                    BrandImage = "",
                    Alias = "yamaha",
                },
                new Brand
                {
                    BrandId = 3,
                    BrandName = "Roland",
                    BrandImage = "",
                    Alias = "roland",
                }
            );
        }

    }
}
