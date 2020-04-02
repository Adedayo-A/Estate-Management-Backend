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
    public class EstatesController : ControllerBase
    {
        private readonly IEstateRepository repository;
        private readonly IMapper mapper;

        public EstatesController(IEstateRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetEstates()
        {
            var estatesFromRepo = await repository.GetEstates();
            var estatesToReturn = mapper.Map<IEnumerable<EstateListVM>>(estatesFromRepo);
            return Ok(estatesToReturn);
        }

        [HttpGet("{estateId}", Name = "GetEstate")]
        public async Task<IActionResult> GetEstate(int estateId)
        {
            var estateFromRepo = await repository.GetEstate(estateId);
            if(estateFromRepo == null)
            {
                return NotFound("Estate Not Found");
            }
            var estateToReturn = mapper.Map<EstateListVM>(estateFromRepo);
            return Ok(estateToReturn);
        }

        [Authorize(Policy = "Admin")]
        [HttpPost]
        public async Task<IActionResult> PostEstate( EstateCreateVM estateCreate)
        {
            var estateToCreate = mapper.Map<Estate>(estateCreate);
            repository.Add(estateToCreate);
            var save = await repository.SaveChanges();
            if(!save)
            {
                throw new Exception();
            }
            var estateToReturn = mapper.Map<EstateListVM>(estateToCreate);
            return CreatedAtRoute("GetEstate", new { estateId = estateToCreate.EstateId }, estateToReturn);
        }

        //------------------------------------------------------------------------//

        [HttpGet("{estateId}/roads")]
        public async Task<IActionResult> GetEstateRoads(int estateId)
        {
            var estateFromRepo = await repository.GetEstate(estateId);
            if (estateFromRepo == null)
            {
                return NotFound("Estate Not Found");
            }
            var roadsFromRepo = await repository.GetEstateRoads(estateId);
            var roadsToReturn = mapper.Map<IEnumerable<RoadListVM>>(roadsFromRepo);
            return Ok(roadsToReturn);
        }

        [HttpGet("{estateId}/roads/{roadId}", Name = "GetRoad")]
        public async Task<IActionResult> GetEstateRoad(int estateId, int roadId)
        {
            var estateFromRepo = await repository.GetEstate(estateId);
            if (estateFromRepo == null)
            {
                return NotFound("Estate Not Found");
            }

            var roadFromRepo = await repository.GetEstateRoad(roadId);
            if (roadFromRepo == null)
            {
                return NotFound("Road Not Found");
            }

            var roadToReturn = mapper.Map<RoadListVM>(roadFromRepo);
            return Ok(roadToReturn);
        }

        [Authorize(Policy = "Admin")]
        [HttpPost("{estateId}/roads")]
        public async Task<IActionResult> PostEstateRoad(int estateId, RoadCreateVM roadCreate)
        {
            var estateFromRepo = await repository.GetEstate(estateId);
            if (estateFromRepo == null)
            {
                return NotFound("Estate Not Found");
            }
            var roadToCreate = mapper.Map<Road>(roadCreate);
            roadToCreate.EstateId = estateId;
            repository.Add(roadToCreate);
            var save = await repository.SaveChanges();
            if (!save)
            {
                throw new Exception();
            }
            var roadToReturn = mapper.Map<RoadListVM>(roadToCreate);
            return CreatedAtRoute("GetRoad", new { estateId = estateId, roadId = roadToCreate.RoadId }, roadToReturn);
        }




    }
}
