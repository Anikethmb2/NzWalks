using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NzWalks.Models.Domain
{
    public class Region
    {
        public Guid ID{ get; set; }

        public string Code{ get; set; }

        public string Name{ get; set; }

        public string? RegionImgUrl{ get; set; }
    }
}