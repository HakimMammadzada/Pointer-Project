using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PointerMVCcore.Models
{
    public class ApproachModel
    {
        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string Title { get; set; }
        [Required]
        [StringLength(300, MinimumLength = 20)]
        public string Description { get; set; }
        [Required]
        public byte Number { get; set; }
    }
}
