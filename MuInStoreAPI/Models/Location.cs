namespace MuInStoreAPI.Models
{
    public class Location
    {
        public int LocationId { get; set; }
        public string LocationName { get; set; } = string.Empty;
        public string Alias { get; set; } = string.Empty;
        public string Lat { get; set; }
        public string Lng { get; set; }
        public int Level { get; set; }
        public int? ParentLocationId { get; set; }
        public List<UserLocation> userLocations { get; set; } = new List<UserLocation>();
    }
}
