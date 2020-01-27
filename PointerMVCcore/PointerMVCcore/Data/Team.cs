using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PointerMVCcore.Data
{
    public class Team
    {
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [Required]
        [StringLength(50)]
        public string Surname { get; set; }
        [Required]
        [StringLength(150)]
        public string Image { get; set; }
        [Required]
        [StringLength(150)]
        public string Position { get; set; }
        public ICollection<Social> Socials { get; set; }
        public Team()
        {
            Socials = new HashSet<Social>();
        }
    }
}
