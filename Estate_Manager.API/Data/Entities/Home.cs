namespace Estate_Manager.API.Data.Entities
{
    public class Home
    {
        public int HomeId { get; set; }
        public int RoadId { get; set; }
        public Road Road { get; set; }
        public int EstateId { get; set; }
        public Estate Estate { get; set; }
    }
} 