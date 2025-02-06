using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using NzWalks.Data;
using NzWalks.Models.Domain;
using NzWalks.Models.DTOs;
using NzWalks.Repositories;

namespace NzWalks.Controllers
{
    [Route("regions")]
    [ApiController]
    public class RegionController : ControllerBase
    {
        private readonly NzWalkDbContext _dbContext;
        private readonly IRegionRepository _regionRepository;

        public RegionController(NzWalkDbContext dbContext, IRegionRepository regionRepository)
        {
            this._dbContext =  dbContext;
            this._regionRepository = regionRepository;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {   
            //Get data from database
            var regions = await _regionRepository.GetAllAsync();

            //Map models and DTOs
            var regionDto = new List <RegionDto>();
            foreach (var region in regions)
            {
                regionDto.Add(new RegionDto()
                {   ID = region.ID,
                    Code = region.Code,
                    Name = region.Name,
                    RegionImgUrl=region.RegionImgUrl,
                });
            }
            
            //Return DTOs
            return Ok(regionDto);
        }


        //Function to get single regions
        [HttpGet]
        [Route("{code}")]
        public async Task<IActionResult> GetRegionById(string code)
        {
            // get domain model data  from database
            //var  region = await _dbContext.RegionsSet.FirstOrDefaultAsync(x => x.Code == code);

            var region =await _regionRepository.GetRegiobByIdAsync(code);

            if(region == null)
            {
                return NotFound();
            }

            //map domain model to dto

            var regionDto = new RegionDto{
                ID = region.ID,
                Code = region.Code,
                Name = region.Name,
                RegionImgUrl= region.RegionImgUrl,
            };


            return Ok(regionDto);
        }

        [HttpPost]
        public async Task<IActionResult> AddNewRegion(AddNewRegionDto addNewRegionDto)
        {
            //map dto to domain model
            var regions = new Region
            {
                    Code = addNewRegionDto.Code,
                    Name = addNewRegionDto.Name,
                    RegionImgUrl = addNewRegionDto.RegionImgUrl,
            };

            //save the data in db

            // await _dbContext.RegionsSet.AddAsync(regions);
            // await _dbContext.SaveChangesAsync();

            regions = await _regionRepository.CreateAsync(regions);

            //map domain model to dto
             var regionDto = new RegionDto()
             {
                ID = regions.ID,
                Code=regions.Code,
                Name=regions.Name,
                RegionImgUrl=regions.RegionImgUrl,
             };

            //return 201 response
            return CreatedAtAction(nameof(GetRegionById),new{code=regions.Code}, regionDto);
        }


       [HttpPut]
       [Route("{id}")]
       public async Task<IActionResult> PutRegion([FromRoute]Guid id,[FromBody] PutRegionDto putRegionDto)
       {
            var regionDomain= new Region();

            //map dto to domain models
            regionDomain.Code = putRegionDto.Code;
            regionDomain.Name = putRegionDto.Name;
            regionDomain.RegionImgUrl = putRegionDto.RegionImgUrl;
            //verify the id and get data and store in domain model
             regionDomain = await _regionRepository.UpdateAsync(id,regionDomain);

            if (regionDomain == null)
            {
                return NotFound();
            }

            //map dto to domain models
            // regionDomain.Code = putRegionDto.Code;
            // regionDomain.Name = putRegionDto.Name;
            // regionDomain.RegionImgUrl = putRegionDto.RegionImgUrl;

            //update domain model
            //await _dbContext.SaveChangesAsync();

            //map domain model to dto
            var regionDto = new RegionDto()
             {  
                ID = regionDomain.ID,
                Code=regionDomain.Code, 
                Name=regionDomain.Name, 
                RegionImgUrl=regionDomain.RegionImgUrl
            };

            //return ok
            return Ok(regionDto);
       }


       [HttpDelete]
       [Route("{id}")]
       public async Task<IActionResult> deleteRegionById(Guid id)
       {
            //fetch the id
            var regionDomain = await _regionRepository.DeleteAsync(id);


            //validate id
            if(regionDomain == null)
            {
                return BadRequest(" bad request");
            }

            var regionDto = new RegionDto{
                ID=regionDomain.ID,
                Name=regionDomain.Name,
                Code=regionDomain.Code,
                RegionImgUrl=regionDomain.RegionImgUrl,
            };


            //return ok
            return Ok (regionDto);
       }
    }
}