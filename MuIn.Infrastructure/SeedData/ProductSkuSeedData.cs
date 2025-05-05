using Microsoft.EntityFrameworkCore;
using MuIn.Domain.Aggregates.ProductAggregate;

namespace MuIn.Infrastructure.SeedData
{
    public static class ProductSkuSeedData
    {
        public static void SeedProductSkuData(this ModelBuilder mb)
        {
            mb.Entity<ProductSku>().HasData(
               new ProductSku
               {
                   ProductSkuId = 1,
                   Sku = "WM123-RED",
                   UnitPrice = 25.99m,
                   UnitInStock = 100,
                   ProductId = 1, // Referring to ProductId 1
                   skuImage = "images/sku/mouse-red.jpg",
                   ImageName = "mouse-red.jpg",
                   ColorId = 1,   // Assuming color exists with ID 1 (e.g., Red)
               },
                new ProductSku
                {
                    ProductSkuId = 2,
                    Sku = "BK456-BLK",
                    UnitPrice = 45.99m,
                    UnitInStock = 50,
                    ProductId = 2, // Referring to ProductId 2
                    skuImage = "images/sku/keyboard-black.jpg",
                    ImageName = "keyboard-black.jpg",
                    ColorId = 2,   // Assuming color exists with ID 2 (e.g., Black)
                }
            );
        }
    }
}
