using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PointerMVCcore.Models.ViewModels
{
    public class TeamSocialModel
    {
        public IEnumerable<TeamModel> teamModel { get; set; }
        public IEnumerable<SocialModel> socialmodel { get; set; }
        public IEnumerable<ApproachModel> approachModels { get; set; }
        public IEnumerable<TestimonialModel> testimonials { get; set; }
        public IEnumerable<ConsultingModel> consultingModels { get; set; }
        public IEnumerable<ConsultingImageModel> consultingImageModels { get; set; }


    }
}
