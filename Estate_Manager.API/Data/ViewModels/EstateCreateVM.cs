using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Estate_Manager.API.Data.ViewModels
{
    public class EstateCreateVM
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Location { get; set; }
        public string ImageUrl { get; set; }

    }
}
