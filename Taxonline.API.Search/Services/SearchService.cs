using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Taxonline.API.Search.Interfaces;

namespace Taxonline.API.Search.Services
{
    public class SearchService : ISearchService
    {
        private readonly IActivityService activityService;
        private readonly IWorkItesmService workItesmService;

        public SearchService(IActivityService activityService,
            IWorkItesmService workItesmService)
        {
            this.activityService = activityService;
            this.workItesmService = workItesmService;
        }
        public async Task<(bool IsSuccess, dynamic SearchResult)> SearchSync(int userId)
        {
            var result = await workItesmService.GetWorkItemsAsync();
            var activity = await activityService.GetActivitysAsync();
            foreach (var item in result.workitem)
            {
                item.activityModels = activity.IsSuccess ? activity.ActivityModel.Where(x => x.WorkItem == item.ID).ToList() : new List<Models.ActivityModel>() { };
            }
            if (result.IsSuccess)
            {
                return (true, result.workitem);
            }
            return (false, null);
        }
    }
}
