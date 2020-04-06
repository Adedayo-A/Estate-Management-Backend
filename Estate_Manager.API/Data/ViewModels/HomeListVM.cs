using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Estate_Manager.API.Data.ViewModels
{
    public class HomeListVM
    {
        public int HomeId { get; set; }
        public HomeOwnerListVM HomeOwner { get; set; }
    }
}
