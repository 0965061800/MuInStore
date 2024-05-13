using Microsoft.EntityFrameworkCore;
using MuInStoreAPI.Models;

namespace MusInStore.Data.SeedData
{
    public static class ProductSkuSeedData
    {
        public static void SeedProductSkuData(this ModelBuilder modelbuilder)
        {
            modelbuilder.Entity<ProductSku>().HasData(
                new ProductSku
                {
                    ProductSkuId = 1,
                    Sku = "C1PE-C1",
                    UnitPrice = 12000000,
                    UnitInStock = 3,
                    ColorId = 1,
                    ProductId = 1
                },
                new ProductSku
                {
                    ProductSkuId = 2,
                    Sku = "C1PE-C2",
                    UnitPrice = 12500000,
                    UnitInStock = 5,
                    ColorId = 2,
                    ProductId = 1
                },
                new ProductSku
                {
                    ProductSkuId = 3,
                    Sku = "C1PE-C3",
                    UnitPrice = 12800000,
                    UnitInStock = 3,
                    ColorId = 3,
                    ProductId = 1
                },
                new ProductSku
                {
                    ProductSkuId = 4,
                    Sku = "CT3001",
                    UnitPrice = 18000000,
                    UnitInStock = 3,
                    ColorId = 1,
                    ProductId = 2
                },
                new ProductSku
                {
                    ProductSkuId = 5,
                    Sku = "CT3002",
                    UnitPrice = 18200000,
                    UnitInStock = 4,
                    ColorId = 2,
                    ProductId = 2
                },
                new ProductSku
                {
                    ProductSkuId = 6,
                    Sku = "CDP-S160BK1",
                    UnitPrice = 8200000,
                    UnitInStock = 4,
                    ColorId = 1,
                    ProductId = 3
                },
                new ProductSku
                {
                    ProductSkuId = 7,
                    Sku = "RP-501R-CB1",
                    UnitPrice = 82000000,
                    UnitInStock = 1,
                    ColorId = 1,
                    ProductId = 4
                }
            );
        }
    }
}
