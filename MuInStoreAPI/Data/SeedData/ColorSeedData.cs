using Microsoft.EntityFrameworkCore;
using MuInStoreAPI.Models;


namespace MuInStore.Data.SeedData
{
    public static class ColorSeedData
    {
        public static void SeedColor(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Color>().HasData(
                new Color
                {
                    ColorId = 1,
                    ColorName = "Black"
                },
                new Color
                {
                    ColorId = 2,
                    ColorName = "White"
                },
                new Color
                {
                    ColorId = 3,
                    ColorName = "Brown"
                },
                new Color
                {
                    ColorId = 4,
                    ColorName = "Grey"
                },
                new Color
                {
                    ColorId = 5,
                    ColorName = "Blue"
                }
            );
        }
    }
}
