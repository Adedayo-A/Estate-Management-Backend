using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Estate_Manager.API.Data.ViewModels
{
    public class RoadCreateVM
    {
        [Required]
        public string Name { get; set; }
    }
}
