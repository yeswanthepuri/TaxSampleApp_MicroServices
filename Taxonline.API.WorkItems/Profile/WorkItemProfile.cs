using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Taxonline.API.WorkItems.DB;
using Taxonline.API.WorkItems.Models;

namespace Taxonline.API.WorkItems.Profile
{
    public class WorkItemProfile: AutoMapper.Profile
        {
        public WorkItemProfile()
        {
            CreateMap<WorkItem, WorkItemModel>();
        }
    }
}
