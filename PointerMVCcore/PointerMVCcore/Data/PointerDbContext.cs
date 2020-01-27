using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PointerMVCcore.Data
{
    public class PointerDbContext:IdentityDbContext<AppUser,IdentityRole<int>,int>
    {
         public PointerDbContext(DbContextOptions options): base(options) { }

        public DbSet<Menu> Menus { get; set; }
        public DbSet<HomeAbout> HomeAbouts { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Social> Socials { get; set; }
        public DbSet<Approach> Approaches { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Testimonial> Testimonials { get; set; }
        public DbSet<Consulting> Consultings { get; set; }
        public DbSet<ConsultingImage> ConsultingImages { get; set; }


    }
}
