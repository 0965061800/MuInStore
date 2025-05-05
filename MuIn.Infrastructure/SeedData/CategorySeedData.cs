using Microsoft.EntityFrameworkCore;
using MuIn.Domain.Aggregates;

namespace MuIn.Infrastructure.SeedData
{
    public static class CategorySeedData
    {
        public static void SeedCatData(this ModelBuilder mb)
        {
            mb.Entity<Category>().HasData(
               new Category
               {
                   CatId = 1,
                   CatName = "Computer Accessories",
                   Alias = "computer-accessories",
                   Description = "Everything you need for your computer setup.",
                   CatImage = "images/categories/computer-accessories.jpg",
                   ImageName = "computer-accessories.jpg"
               },
                new Category
                {
                    CatId = 2,
                    CatName = "Keyboards",
                    Alias = "keyboards",
                    Description = "A variety of keyboards for every need.",
                    CatImage = "images/categories/keyboards.jpg",
                    ImageName = "keyboards.jpg",
                    ParentCatId = 1 // Subcategory of Computer Accessories
                },
                new Category
                {
                    CatId = 3,
                    CatName = "Mice & Pointing Devices",
                    Alias = "mice-and-pointing-devices",
                    Description = "Mice, trackpads, and other pointing devices.",
                    CatImage = "images/categories/mice.jpg",
                    ImageName = "mice.jpg",
                    ParentCatId = 1 // Subcategory of Computer Accessories
                },
                new Category
                {
                    CatId = 4,
                    CatName = "Smartphones",
                    Alias = "smartphones",
                    Description = "Latest smartphones from top brands.",
                    CatImage = "images/categories/smartphones.jpg",
                    ImageName = "smartphones.jpg"
                },
                new Category
                {
                    CatId = 5,
                    CatName = "Laptops",
                    Alias = "laptops",
                    Description = "Laptops for work, gaming, and casual use.",
                    CatImage = "images/categories/laptops.jpg",
                    ImageName = "laptops.jpg"
                },
                new Category
                {
                    CatId = 6,
                    CatName = "Headphones",
                    Alias = "headphones",
                    Description = "Wired and wireless headphones for all needs.",
                    CatImage = "images/categories/headphones.jpg",
                    ImageName = "headphones.jpg"
                },
                new Category
                {
                    CatId = 7,
                    CatName = "Tablets",
                    Alias = "tablets",
                    Description = "Tablets for personal and professional use.",
                    CatImage = "images/categories/tablets.jpg",
                    ImageName = "tablets.jpg"
                }
           );
        }
    }
}
