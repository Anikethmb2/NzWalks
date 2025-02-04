using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NzWalks.Models.DTOs
{
    public class AddNewRegionDto
    {
         public string Code{ get; set; }

        public string Name{ get; set; }

        public string? RegionImgUrl{ get; set; }
    }
}