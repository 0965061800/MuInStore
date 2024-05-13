using Microsoft.EntityFrameworkCore;
using MuInStoreAPI.Models;
namespace MusInStore.Data.SeedData
{
    public static class ImageProductSeedData
    {
        public static void SeedProductImageData(this ModelBuilder modelbuilder)
        {
            modelbuilder.Entity<ProductImage>().HasData(
                new ProductImage
                {
                    ProductImageId = 1,
                    ImageUrl = "Product1.jpg",
                    ProductSkuId = 1,
                },
                new ProductImage
                {
                    ProductImageId = 2,
                    ImageUrl = "Product1.jpg",
                    ProductSkuId = 2,
                },
                new ProductImage
                {
                    ProductImageId = 3,
                    ImageUrl = "Product1.jpg",
                    ProductSkuId = 3,
                },
                new ProductImage
                {
                    ProductImageId = 4,
                    ImageUrl = "Product1.jpg",
                    ProductSkuId = 4,
                }

            );
        }
    }
}
