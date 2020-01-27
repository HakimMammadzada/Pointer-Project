using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PointerMVCcore.Data
{
    public class HomeAbout
    {
        public int Id { get; set; }
        [Required]
        [StringLength(100,MinimumLength =5)]
        public string Title { get; set; }
        [Required]
        [StringLength(300, MinimumLength = 5)]
        public string Describtion { get; set; }
        [Required]
        [StringLength(300, MinimumLength = 5)]
        public string Image { get; set; }
    }
}
