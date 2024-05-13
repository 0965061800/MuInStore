using Microsoft.EntityFrameworkCore;
using MuInStoreAPI.Models;

namespace MuInStore.Data.SeedData
{
    public static class CommentSeedData
    {
        public static void SeedCommentData(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Comment>().HasData(
                new Comment
                {
                    CommentId = 1
                }
             );
        }
    }
}
