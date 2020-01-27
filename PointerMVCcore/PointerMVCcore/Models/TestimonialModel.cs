using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PointerMVCcore.Models
{
    public class TestimonialModel
    {
        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string Name { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string Surname { get; set; }
        [Required]
        [StringLength(300, MinimumLength = 20)]
        public string Content { get; set; }
        [Required]
        [StringLength(200)]
        public string Image { get; set; }
    }
}
