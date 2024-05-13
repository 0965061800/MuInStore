using Microsoft.EntityFrameworkCore;
using MuInStoreAPI.Models;

namespace MusInStore.Data.SeedData
{
    public static class LocationSeedData
    {
        public static void SeedLocalData(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Location>().HasData(
                new Location
                {
                    LocationId = 1,
                    LocationName = "Tp Hồ Chí Minh",
                    Alias = "HCM",
                    Lat = "10.7936663",
                    Lng = "106.6777955",
                    ParentLocationId = null,

                },
                new Location
                {
                    LocationId = 839,
                    LocationName = "Bình Dương",
                    Alias = "binh-duong",
                    Lat = "11.3254024",
                    Lng = "106.477016999999",
                    ParentLocationId = null,
                },
                new Location
                {
                    LocationId = 1093,
                    LocationName = "Huyện Bình Chánh",
                    Alias = "binh-chanh",
                    Lat = "10.7430983",
                    Lng = "106.54662209999992",
                    ParentLocationId = 1,
                },
                new Location
                {
                    LocationId = 1136,
                    LocationName = "Huyện Củ Chi",
                    Alias = "cu-chi",
                    Lat = "11.0066683",
                    Lng = "106.51319669999998",
                    ParentLocationId = 1,
                },
                new Location
                {
                    LocationId = 1103,
                    LocationName = "Thành Phố Thủ Dầu Một",
                    Alias = "tp-thu-dau-mot",
                    Lat = "10.9929842",
                    Lng = "106.65570730000002",
                    ParentLocationId = 2,
                },
                new Location
                {
                    LocationId = 1100,
                    LocationName = "Thị Xã Bến Cát",
                    Alias = "thi-xa-ben-cat",
                    Lat = "11.101302",
                    Lng = "106.58197889999997",
                    ParentLocationId = 2,
                },
                new Location
                {
                    LocationId = 1141,
                    LocationName = "Xã Bình Hưng",
                    Alias = "xa-binh-hung",
                    Lat = "10.7200104",
                    Lng = "106.6703963",
                    ParentLocationId = 1093,
                },
                new Location
                {
                    LocationId = 1142,
                    LocationName = "Xã Bình Lợi",
                    Alias = "xa-binh-loi",
                    Lat = "10.7756348",
                    Lng = "106.5096239",
                    ParentLocationId = 1093,
                }
            );
        }
    }
}
