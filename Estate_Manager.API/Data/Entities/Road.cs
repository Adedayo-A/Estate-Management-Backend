using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Estate_Manager.API.Data.Entities
{
    public class Road
    {
        public int RoadId { get; set; }
        public string Name { get; set; }
        public int EstateId { get; set; }
        public Estate Estate { get; set; }
        public ICollection<Home> Homes { get; set; }
    }
}
