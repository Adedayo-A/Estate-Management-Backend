using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Estate_Manager.API.Data.Entities
{
    public class HomeOwner
    {
        public int HomeOwnerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public DateTime DOB { get; set; }
        public Home Home { get; set; }
        public int HomeId { get; set; }
        public int EstateId { get; set; }
        public Estate Estate { get; set; }
    }
}
