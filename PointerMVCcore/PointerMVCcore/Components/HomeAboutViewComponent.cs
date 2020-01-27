using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PointerMVCcore.Data;
using PointerMVCcore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PointerMVCcore.Components
{
    public class HomeAboutViewComponent:ViewComponent
    {
        private readonly PointerDbContext context;
        private readonly IMapper mapper;
        public HomeAboutViewComponent(PointerDbContext _context, IMapper _mapper)
        {
            context = _context;
            mapper=_mapper;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var infos = await context.HomeAbouts.ToListAsync();
            return View(mapper.Map<List<HomeAboutModel>>(infos));
        }

    }
}
