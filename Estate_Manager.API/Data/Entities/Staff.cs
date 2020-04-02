namespace Estate_Manager.API.Data.Entities
{
    public class Staff
    {
        public int StaffId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Type { get; set; }
        public int OccupantId { get; set; }
        public Occupant Occupant { get; set; }
        public int EstateId { get; set; }
        public Estate Estate { get; set; }
    }
}