using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Estate_Manager.API.Data.Entities
{
    public class UserEstate
    {
        public User User { get; set; }
        public string UserId { get; set; }
        public int EstateId { get; set; }
        public Estate Estate { get; set; }
    }
}
