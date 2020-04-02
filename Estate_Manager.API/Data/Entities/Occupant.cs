using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Estate_Manager.API.Data.Entities
{
    public class Occupant
    {
        public int OccupantId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public DateTime DOB { get; set; }
        public ICollection<Member> Members { get; set; }
        public ICollection<Staff> Staff { get; set; }
        public Home Home { get; set; }
        public int HomeId { get; set; }
        public int EstateId { get; set; }
        public Estate Estate { get; set; }
    }
}
