using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using PointerMVCcore.Data;
using PointerMVCcore.Models;
using PointerMVCcore.Models.ViewModels;

namespace PointerMVCcore.Controllers
{
    
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly PointerDbContext context;
        private readonly IMapper mapper;
        public HomeController(ILogger<HomeController> logger, PointerDbContext _context, IMapper _mapper)
        {
            _logger = logger;
            context = _context;
            mapper = _mapper;
        }

        public async Task<IActionResult> Index()
        {
            var teams = mapper.Map<TeamModel[]>(await context.Teams.ToListAsync());
            var socials = mapper.Map<SocialModel[]>(await context.Socials.ToListAsync());
            var apporaches = mapper.Map<ApproachModel[]>(await context.Approaches.ToListAsync());
            var testimonial = mapper.Map<TestimonialModel[]>(await context.Testimonials.ToListAsync());
            var consulting = mapper.Map<ConsultingModel[]>(await context.Consultings.ToListAsync());
            var consultingImage = mapper.Map<ConsultingImageModel[]>(await context.ConsultingImages.ToListAsync());
            var viewmodels = new TeamSocialModel
            {
                teamModel = teams,
                socialmodel = socials,
                approachModels = apporaches,
                testimonials = testimonial,
                consultingModels = consulting,
                consultingImageModels = consultingImage

            };
            return View(viewmodels);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
