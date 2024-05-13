using Microsoft.EntityFrameworkCore;
using MuInStoreAPI.Models;

namespace MuInStore.Data.SeedData
{
    public static class CategorySeedData
    {
        public static void SeedCategory(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category
                {
                    CatId = 1,
                    CatName = "Piano",
                    Alias = "piano"
                },
                new Category
                {
                    CatId = 2,
                    CatName = "Guitar",
                    Alias = "guitar"
                },
                new Category
                {
                    CatId = 3,
                    CatName = "Violin",
                    Alias = "Violin"
                },
                new Category
                {
                    CatId = 4,
                    CatName = "Piano điện",
                    Alias = "e-piano",
                    ParentCatId = 1,
                }
            );
        }
    }
}
