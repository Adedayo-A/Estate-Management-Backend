using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Estate_Manager.API.Data.ViewModels
{
    public class HomeOwnerCreateVM
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        public DateTime DOB { get; set; }
        [Required]
        public int HomeId { get; set; }
        public int EstateId { get; set; }
    }
}
