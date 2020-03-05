using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Taxonline.API.Activity.DB;
using Taxonline.API.Activity.Models.Interfaces;
using Taxonline.API.Activity.Models;
using System.Diagnostics;

namespace Taxonline.API.Activity.Models
{
    public class ActivityProvider : IActivityProvider
    {
        private readonly ActivityDbContext dataBase;
        private readonly ILogger<ActivityProvider> logger;
        private readonly IMapper mapper;

        public ActivityProvider(ActivityDbContext dataBase,
            ILogger<ActivityProvider> logger,
            IMapper mapper)
        {
            this.dataBase = dataBase;
            this.logger = logger;
            this.mapper = mapper;

            Seed();
        }

        private void Seed()
        {
            if (!dataBase.Activities.Any())
            {
                dataBase.Activities.Add(new Activitie() { Id=1,Memo="Sample Test Memo",TypeOfActivity = "Call",WorkItem = 1});
                dataBase.Activities.Add(new Activitie() { Id = 2, Memo = "Sample Test Memo 2", TypeOfActivity = "Call", WorkItem = 2 });
                dataBase.Activities.Add(new Activitie() { Id = 3, Memo = "Sample Test Memo 3", TypeOfActivity = "Call", WorkItem = 3 });
                dataBase.Activities.Add(new Activitie() { Id = 4, Memo = "Sample Test Memo 4", TypeOfActivity = "Call", WorkItem = 3 });
                dataBase.Activities.Add(new Activitie() { Id = 5, Memo = "Sample Test Memo 5", TypeOfActivity = "Call", WorkItem = 4 });
                dataBase.Activities.Add(new Activitie() { Id = 6, Memo = "Sample Test Memo 6", TypeOfActivity = "Call", WorkItem = 5 });

                dataBase.SaveChanges();
            }
            }

        public async Task<(bool IsSuccess, IEnumerable<ActivitieModel> activitieModel, string ErrorMessage)> GetActivitiesAsync()
        {
            try
            {
                var workItems = await dataBase.Activities.ToListAsync();
                if (workItems != null && workItems.Any())
                {
                    var result = mapper.Map<IEnumerable<Activitie>, IEnumerable<ActivitieModel>>(workItems);
                    return (true, result, null);
                }
                return (false, null, "Records Not Found");
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message, ex);
                return (false, null, ex.Message);
            }
        }
        public async Task<(bool IsSuccess, ActivitieModel activitieModel, string ErrorMessage)> GetActivitieAsync(int id)
        {
            try
            {
                var workItem = await dataBase.Activities.FirstOrDefaultAsync(x=>x.Id==id);
                if (workItem != null)
                {
                    var result = mapper.Map<Activitie, ActivitieModel>(workItem);
                    return (true, result, null);
                }
                return (false, null, "Records Not Found");
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message, ex);
                return (false, null, ex.Message);
            }
        }
    }
}
