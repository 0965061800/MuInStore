using Microsoft.EntityFrameworkCore;
using MuInStoreAPI.Models;

namespace MusInStore.Data.SeedData
{
    public static class PayStatusSeedData
    {
        public static void SeedPayStatusData(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PayStatus>().HasData(
                new PayStatus
                {
                    PayStatusId = 1,
                    Status = "Pending",
                    Description = "Đang chờ thanh toán"
                },
                new PayStatus
                {
                    PayStatusId = 2,
                    Status = "Declined",
                    Description = "Bị từ chối"
                },
                new PayStatus
                {
                    PayStatusId = 3,
                    Status = "Cancelled",
                    Description = "Hủy bỏ",
                },
                new PayStatus
                {
                    PayStatusId = 4,
                    Status = "Refunded",
                    Description = "Hoàn trả"
                },
                new PayStatus
                {
                    PayStatusId = 5,
                    Status = "Expired",
                    Description = "Hết hạn"
                },
                new PayStatus
                {
                    PayStatusId = 6,
                    Status = "Settled",
                    Description = "Đã thanh toán"
                }
                );
        }
    }
}
