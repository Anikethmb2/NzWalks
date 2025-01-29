using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NzWalks.Models.Domain
{
    public class Walks
    {
        public Guid ID{ get; set; }
        public string Name{ get; set; }

        public string Description{ get; set; }

        public double LengthInKm{ get; set; }

        public string? WalkImgUrl{ get; set; }

        public Guid DifficultyId{ get; set; }

        public Guid RegionId{ get; set; }

        //Navigation property

        public Difficulty Difficulty{ get; set; }
        public Region Region{ get; set; }


    }
}