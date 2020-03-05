using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Taxonline.API.Activity.DB;
using Taxonline.API.Activity.Models;

namespace Taxonline.API.WorkItems.Profile
{
    public class ActivityProfile: AutoMapper.Profile
        {
        public ActivityProfile()
        {
            CreateMap<Activitie, ActivitieModel>();
        }
    }
}
