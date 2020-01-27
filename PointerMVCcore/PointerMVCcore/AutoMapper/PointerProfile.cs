using AutoMapper;
using PointerMVCcore.Data;
using PointerMVCcore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PointerMVCcore.AutoMapper
{
    public class PointerProfile : Profile
    {
        public PointerProfile()
        {
            this.CreateMap<Menu, MenuModel>().ReverseMap();
            this.CreateMap<HomeAbout, HomeAboutModel>().ReverseMap();
            this.CreateMap<Team, TeamModel>().ReverseMap();
            this.CreateMap<Social, SocialModel>().ReverseMap();
            this.CreateMap<Approach, ApproachModel>().ReverseMap();
            this.CreateMap<Service, ServiceModel>().ReverseMap();
            this.CreateMap<Testimonial, TestimonialModel>().ReverseMap();
            this.CreateMap<ConsultingImage, ConsultingImageModel>().ReverseMap();
            this.CreateMap<ConsultingModel, Consulting>().ReverseMap();

            this.CreateMap<AppUser, RegistrModel>()
                 .ForMember(t => t.Username, f => f.MapFrom(t => t.UserName))
                 .ForMember(t => t.Email, f => f.MapFrom(t => t.Email))
                 .ReverseMap();
         }
    }
}
