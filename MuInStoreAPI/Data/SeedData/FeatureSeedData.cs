using Microsoft.EntityFrameworkCore;
using MuInStoreAPI.Models;

namespace MuInStore.Data.SeedData
{
    public static class FeatureSeedData
    {
        public static void SeedFeature(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Feature>().HasData(
                new Feature
                {
                    FeatureId = 1,
                    FeatureName = "Dành cho người mới học",
                    Alias = "newbigginer"
                },
                new Feature
                {
                    FeatureId = 2,
                    FeatureName = "Dành cho người bạn nhỏ",
                    Alias = "kids"
                },
                new Feature
                {
                    FeatureId = 3,
                    FeatureName = "Danh cho trình độ cao",
                    Alias = "advanced"
                }
            );
        }
    }
}
