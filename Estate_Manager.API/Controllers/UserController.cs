using AutoMapper;
using Estate_Manager.API.Data.Services;
using Estate_Manager.API.Data.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Estate_Manager.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IEstateRepository repository;
        private readonly IMapper mapper;

        public UserController(IEstateRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            var usersFromRepo = await repository.GetAllUsers();
            var usersToReturn = mapper.Map<IEnumerable<UserListVM>>(usersFromRepo);
            return Ok(usersToReturn);
        }

    }
}
