using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Estate_Manager.API.Data.ViewModels
{
    public class EstateListVM
    {
        public int EstateId { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
    }
}
