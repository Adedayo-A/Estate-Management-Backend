using AutoMapper;
using Estate_Manager.API.Data.Entities;
using Estate_Manager.API.Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Estate_Manager.API.Data
{
    public class Profiles : Profile
    {
        public Profiles()
        {
            CreateMap<UserCreateVM, User>()
                .ForMember(d => d.UserName, o =>
                {
                    o.MapFrom(p => p.Email);
                }
               );
            CreateMap<EstateCreateVM, Estate>();
            CreateMap<Estate, EstateListVM>();
            CreateMap<RoadCreateVM, Road>();
            CreateMap<Road, RoadListVM>()
                .ForMember(d => d.NoOfHomes, o =>
            {
                o.MapFrom(p => p.Homes.Count());
            }
           );


            CreateMap<User, UserListVM>();
            CreateMap<Home, HomeListVM>();
            CreateMap<HomeOwner, HomeOwnerListVM>();
            CreateMap<HomeCreateVM, Home>();
        }
    }
}
