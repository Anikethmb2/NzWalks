using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NzWalks.Models.Domain;

namespace NzWalks.Models.DTOs
{
    public class WalkDto
    {
        public string Name{ get; set; }

        public string Description{ get; set; }

        public double LengthInKm{ get; set; }

        public string? WalkImgUrl{ get; set; }

        public Guid DifficultyId{ get; set; }

        public Guid RegionId{ get; set; }

    }
}