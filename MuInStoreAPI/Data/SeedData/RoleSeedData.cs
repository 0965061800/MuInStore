using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace MusInStore.Data.SeedData
{
    public static class RoleSeedData
    {
        public static void SeedRole(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IdentityRole>().HasData(
                new IdentityRole
                {
                    Name = "Admin",
                    NormalizedName = "Admin",
                },
                new IdentityRole
                {
                    Name = "User",
                    NormalizedName = "USER"
                }
            );
        }
    }
}
