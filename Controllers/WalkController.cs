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
        public async Task<IActionResult> GetAll()
        {
            var walkDomain = await walkRepository.GetAllAsync();

            var walkDto = mapper.Map<List<WalkDto>>(walkDomain);

            return Ok(walkDto);
        }
    }
}