using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NzWalks.Models.DTOs
{
    public class AddNewRegionDto
    {
        [Required]
        [MaxLength(3, ErrorMessage = "The code can have max 3 letter")]
        [MinLength(1, ErrorMessage = "The code should have min 3 letter ")]
         public required string Code{ get; set; }

        [Required]
        [MaxLength(100, ErrorMessage = "Name crossed limit")]
        public required string Name{ get; set; }

        public string? RegionImgUrl{ get; set; }
    }
}