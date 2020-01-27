using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PointerMVCcore.Models
{
    public class MenuModel
    {
        [Required]
        [StringLength(30, MinimumLength = 3)]
        public string Name { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string Href { get; set; }
    }
}
