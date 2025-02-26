using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NzWalks.Models.Domain;
using NzWalks.Models.DTOs;
using NzWalks.Repositories;

namespace NzWalks.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WalkController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IWalkRepository walkRepository;
        public WalkController(IWalkRepository walkRepository ,IMapper mapper)
        {   
            this.walkRepository = walkRepository;
            this.mapper = mapper;
            
        }
        

        [HttpPost]

        public async Task<IActionResult> Create([FromBody] AddWalkDto addWalkDto)
        {
            //Map DTO to Domain Model
            var walkDomain = mapper.Map<Walks>(addWalkDto);

            //create repo pattern
            var walkDomian = await walkRepository.CreateAsync(walkDomain);
        
            //map domain models to dto
            var walkDto = mapper.Map<WalkDto>(walkDomian);
            //return 

            return Ok(walkDto);
        }


        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] string? filterOn, [FromQuery] string? filterQuery,
        [FromQuery] string? sortBy, [FromQuery] bool isAscending )
        {
            var walkDomain = await walkRepository.GetAllAsync(filterOn,filterQuery, sortBy, isAscending);

            var walkDto = mapper.Map<List<WalkDto>>(walkDomain);

            return Ok(walkDto);
        }

        [HttpGet]
        [Route("{id}")]

        public async Task<IActionResult> GetWalkById(Guid id)
        {
            var walkDomain = await walkRepository.GetWalkByIdAsync(id);

            if(walkDomain == null)
            {
                return NotFound();
            }

            return Ok (mapper.Map<WalkDto>(walkDomain));


        }


        //Update function
        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateWalkDto updateWalk )
        {
            var walkDomain = mapper.Map<Walks> (updateWalk);

            var walkDomian = await walkRepository.UpdateWalkAsync(id, walkDomain);

            if (walkDomain == null)
            {
                return NotFound();
            }

            return Ok(mapper.Map<UpdateWalkDto>(walkDomian));
        }

        [HttpDelete]
        [Route("{id:Guid}")]

        public async Task<IActionResult> Delete([FromRoute]Guid id)
        {
            var walkDomain = await walkRepository.DeleteWalkAsync(id);

            if (walkDomain == null)
            {
                return NotFound();
            }

            var walkDto = mapper.Map<WalkDto>(walkDomain);

            return Ok(walkDto);

        }

    }
}