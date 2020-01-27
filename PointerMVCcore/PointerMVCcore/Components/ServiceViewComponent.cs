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
    public class ServiceViewComponent:ViewComponent
    {
        private readonly PointerDbContext context;
        private readonly IMapper mapper;
        public ServiceViewComponent(PointerDbContext _context, IMapper _mapper)
        {
            context = _context;
            mapper = _mapper;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var services = await context.Services.ToListAsync();
            return View(mapper.Map<List<ServiceModel>>(services));
        }

    }
}
