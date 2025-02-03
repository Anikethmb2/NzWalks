using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NzWalks.Data;
using NzWalks.Models.Domain;

namespace NzWalks.Controllers
{
    [Route("regions")]
    [ApiController]
    public class RegionController : ControllerBase
    {
        private readonly NzWalkDbContext _dbContext;

        public RegionController(NzWalkDbContext dbContext)
        {
            this._dbContext =  dbContext;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var regions = _dbContext.RegionsSet.ToList();
            return Ok(regions);
        }
    }
}