using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PointerMVCcore.Models
{
    public class ConsultingImageModel
    {
        [Required]
        [StringLength(250)]
        public string Image { get; set; }
    }
}
