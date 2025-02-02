using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NzWalks.Models.Domain;

namespace NzWalks.Controller
{
    [Route("api/regions")]
    [ApiController]
    public class RegionController : ControllerBase
    {
        private readonly ILogger<RegionController> _logger;

        public RegionController(ILogger<RegionController> logger)
        {
            _logger = logger;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var regions = new List<Region>{
                new Region { ID = Guid.NewGuid(),
                Name = "AuckLand", 
                Code="Akl",
                RegionImgUrl="https://images.pexels.com/photos/158826/structure-light-led-movement-158826.jpeg?auto=compress&cs=tinysrgb&w=600"
    
            },

               new Region { ID = Guid.NewGuid(),
                Name = "Wellington", 
                Code="WGT",
                RegionImgUrl="https://images.pexels.com/photos/158826/structure-light-led-movement-158826.jpeg?auto=compress&cs=tinysrgb&w=600"
    
            }   
            };
            return Ok(regions);
        }
    }
}