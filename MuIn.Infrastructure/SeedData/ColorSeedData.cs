using Microsoft.EntityFrameworkCore;
using MuIn.Domain.Aggregates;

namespace MuIn.Infrastructure.SeedData
{
    public static class ColorSeedData
    {
        public static void SeedColorData(this ModelBuilder mb)
        {
            mb.Entity<Color>().HasData(
                 new Color
                 {
                     ColorId = 1,
                     ColorName = "Red"
                 },
                new Color
                {
                    ColorId = 2,
                    ColorName = "Black"
                }
            );
        }
    }
}
