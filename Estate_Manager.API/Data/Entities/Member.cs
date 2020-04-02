namespace Estate_Manager.API.Data.Entities
{
    public class Member
    {
        public int MemberId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Relationship { get; set; }
        public int OccupantId { get; set; }
        public Occupant Occupant { get; set; }
    }
}