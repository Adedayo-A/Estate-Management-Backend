namespace Estate_Manager.API.Data.Entities
{
    public class Home
    {
        public int HomeId { get; set; }
        public int HomeNumber { get; set; }
        public int RoadId { get; set; }
        public Road Road { get; set; }
        public int? HomeOwnerId { get; set; }
        public HomeOwner HomeOwner { get; set; }
    }
} 