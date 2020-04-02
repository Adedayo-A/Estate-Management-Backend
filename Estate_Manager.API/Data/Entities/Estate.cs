using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Estate_Manager.API.Data.Entities
{
    public class Estate
    {
        [Required]
        public int EstateId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Location { get; set; }
        public ICollection<Road> Roads { get; set; }
        public ICollection<UserEstate> Users { get; set; }

    }
}
