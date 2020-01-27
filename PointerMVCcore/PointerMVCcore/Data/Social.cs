using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PointerMVCcore.Data
{
    public class Social
    {
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [Required]
        [StringLength(100)]
        public string CssName { get; set; }
        [Required]
        [StringLength(100)]
        public string Href { get; set; }
        public int TeamId { get; set; }
        public Team Team { get; set; }
      
    }
}
