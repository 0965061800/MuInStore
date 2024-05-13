namespace MuInStoreAPI.Models
{
    public class UserLocation
    {
        public string AppUserId { get; set; }
        public int LocationId { get; set; }
        public AppUser AppUser { get; set; }
        public Location Location { get; set; }
    }
}
