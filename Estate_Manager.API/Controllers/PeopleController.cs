using AutoMapper;
using Estate_Manager.API.Data.Entities;
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
    public class PeopleController : ControllerBase
    {
        private readonly IEstateRepository repository;
        private readonly IMapper mapper;

        public PeopleController(IEstateRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        [HttpGet("{estateId}", Name = "GetHomeOwners")]
        public async Task<IActionResult> GetHomeOwners(int estateId)
        {
            var homeOwnersFromRepo = await repository.GetHomeOwners(estateId);
            var homeOwnersToReturn = mapper.Map<IEnumerable<HomeOwnerListVM>>(homeOwnersFromRepo);
            return Ok(homeOwnersToReturn);
        }

        [HttpGet("{estateId}, {homeOwnerId}", Name = "GetHomeOwner")]
        public async Task<IActionResult> GetHomeOwner(int estateId, int homeOwnerId)
        {
            var homeOwnerFromRepo = await repository.GetHomeOwner(estateId, homeOwnerId);
            if (homeOwnerFromRepo == null)
            {
                return NotFound("Home Owner Not Found");
            }
            var homeOwnerToReturn = mapper.Map<HomeOwnerListVM>(homeOwnerFromRepo);
            return Ok(homeOwnerToReturn);
        }

        [HttpGet("{estateId}", Name = "GetOccupants")]
        public async Task<IActionResult> GetOccupants(int estateId)
        {
            var occupantsFromRepo = await repository.GetOccupants(estateId);
            var occupantsToReturn = mapper.Map<IEnumerable<OccupantListVM>>(occupantsFromRepo);
            return Ok(occupantsToReturn);
        }

        [HttpGet("{estateId}, {occupantId}", Name = "GetOccupant")]
        public async Task<IActionResult> GetOccupant(int estateId, int occupantId)
        {
            var occupantFromRepo = await repository.GetOccupant(estateId, occupantId);
            if (occupantFromRepo == null)
            {
                return NotFound("Occupant Not Found");
            }
            var occupantToReturn = mapper.Map<OccupantListVM>(occupantFromRepo);
            return Ok(occupantToReturn);
        }

        [HttpGet("{estateId}", Name = "GetStaff")]
        public async Task<IActionResult> GetStaff(int estateId)
        {
            var staffFromRepo = await repository.GetStaff(estateId);
            var staffToReturn = mapper.Map<IEnumerable<StaffListVM>>(staffFromRepo);
            return Ok(staffToReturn);
        }

        [HttpGet("{estateId}, {staffId}", Name = "GetAStaff")]
        public async Task<IActionResult> GetAStaff(int estateId, int staffId)
        {
            var staffFromRepo = await repository.GetOccupant(estateId, staffId);
            if (staffFromRepo == null)
            {
                return NotFound("Staff Not Found");
            }
            var staffToReturn = mapper.Map<StaffListVM>(staffFromRepo);
            return Ok(staffToReturn);
        }


        [Authorize(Policy = "AdminOrSupervisor")]
        [HttpPost]
        public async Task<IActionResult> PostHomeOwner(HomeOwnerCreateVM ownerCreate)
        {
            var homeOwnerToCreate = mapper.Map<HomeOwner>(ownerCreate);
            repository.Add(homeOwnerToCreate);
            var save = await repository.SaveChanges();
            if (!save)
            {
                throw new Exception();
            }
            var homeOwnerToReturn = mapper.Map<HomeOwnerListVM>(homeOwnerToCreate);
            return CreatedAtRoute("GetHomeOwner", new { homeOwnerId = homeOwnerToCreate.HomeOwnerId }, homeOwnerToReturn);
        }

        [Authorize(Policy = "AdminOrSupervisor")]
        [HttpPost]
        public async Task<IActionResult> PostOccupant(OccupantCreateVM occupantCreate)
        {
            var occupantToCreate = mapper.Map<Occupant>(occupantCreate);
            repository.Add(occupantToCreate);
            var save = await repository.SaveChanges();
            if (!save)
            {
                throw new Exception();
            }
            var occupantToReturn = mapper.Map<OccupantListVM>(occupantToCreate);
            return CreatedAtRoute("GetOccupant", new { occupantId = occupantToCreate.OccupantId }, occupantToReturn);
        }

        [Authorize(Policy = "AdminOrSupervisor")]
        [HttpPost]
        public async Task<IActionResult> PostStaff(StaffCreateVM staffCreate)
        {
            var staffToCreate = mapper.Map<Staff>(staffCreate);
            repository.Add(staffToCreate);
            var save = await repository.SaveChanges();
            if (!save)
            {
                throw new Exception();
            }
            var staffToReturn = mapper.Map<OccupantListVM>(staffToCreate);
            return CreatedAtRoute("GetStaff", new { staffId = staffToCreate.OccupantId }, staffToReturn);
        }

    }
}
