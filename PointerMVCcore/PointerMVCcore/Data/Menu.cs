using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PointerMVCcore.Data
{
    public class Menu
    {
        public int Id { get; set; }
        [Required]
        [StringLength(30,MinimumLength =3)]
        public string Name { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string Href { get; set; }
    }
}
