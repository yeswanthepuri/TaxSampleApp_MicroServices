using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Taxonline.API.WorkItems.DB;
using Taxonline.API.WorkItems.Models.Interfaces;

namespace Taxonline.API.WorkItems.Models
{
    public class WorkItemProvider : IWorkItemProvider
    {
        private readonly WorkItemDbContext dataBase;
        private readonly ILogger<WorkItemProvider> logger;
        private readonly IMapper mapper;

        public WorkItemProvider(WorkItemDbContext dataBase,
            ILogger<WorkItemProvider> logger,
            IMapper mapper)
        {
            this.dataBase = dataBase;
            this.logger = logger;
            this.mapper = mapper;

            Seed();
        }

        private void Seed()
        {
            if (!dataBase.WorkItems.Any())
            {
                dataBase.WorkItems.Add(new WorkItem() { ID = 1, CreatedDate = DateTime.UtcNow, UpdatedDate = DateTime.UtcNow, Amount = 45.3m, Jurisdiction = "Sample Juri Notice 1", Status = "UnWorking", TaxTypeID = "Business Licence", TypeofWorkItemID = "Notice" });
                dataBase.WorkItems.Add(new WorkItem() { ID = 2, CreatedDate = DateTime.UtcNow, UpdatedDate = DateTime.UtcNow, Amount = 145.3m, Jurisdiction = "Sample Juri Notice 2", Status = "Working", TaxTypeID = "Business Licence", TypeofWorkItemID = "Notice" });
                dataBase.WorkItems.Add(new WorkItem() { ID = 3, CreatedDate = DateTime.UtcNow, UpdatedDate = DateTime.UtcNow, Amount = 5.3m, Jurisdiction = "Sample Juri Notice 3", Status = "Resolved", TaxTypeID = "Notice Type", TypeofWorkItemID = "Notice" });
                dataBase.WorkItems.Add(new WorkItem() { ID = 4, CreatedDate = DateTime.UtcNow, UpdatedDate = DateTime.UtcNow, Amount = 15.3m, Jurisdiction = "Sample Juri Reg 1", Status = "Open", TaxTypeID = "New Registration", TypeofWorkItemID = "Registration" });
                dataBase.WorkItems.Add(new WorkItem() { ID = 5, CreatedDate = DateTime.UtcNow, UpdatedDate = DateTime.UtcNow, Amount = 4.3m, Jurisdiction = "Sample Juri Reg 2", Status = "Open", TaxTypeID = "Old Registration", TypeofWorkItemID = "Registration" });
                dataBase.WorkItems.Add(new WorkItem() { ID = 6, CreatedDate = DateTime.UtcNow, UpdatedDate = DateTime.UtcNow, Amount = 43.3m, Jurisdiction = "Sample Juri Reg 3", Status = "Ready", TaxTypeID = "New Registration", TypeofWorkItemID = "Registration" });
                dataBase.WorkItems.Add(new WorkItem() { ID = 7, CreatedDate = DateTime.UtcNow, UpdatedDate = DateTime.UtcNow, Amount = 24.3m, Jurisdiction = "Sample Juri ent 1", Status = "Open", TaxTypeID = "Close Entity", TypeofWorkItemID = "Entity" });
                dataBase.WorkItems.Add(new WorkItem() { ID = 8, CreatedDate = DateTime.UtcNow, UpdatedDate = DateTime.UtcNow, Amount = 445.3m, Jurisdiction = "Sample Juri service 1", Status = "Completed", TaxTypeID = "Service Request Type", TypeofWorkItemID = "Service Request" });
                dataBase.WorkItems.Add(new WorkItem() { ID = 9, CreatedDate = DateTime.UtcNow, UpdatedDate = DateTime.UtcNow, Amount = 413.3m, Jurisdiction = "Sample Juri service 2", Status = "Ready", TaxTypeID = "Service Request Type", TypeofWorkItemID = "Service Request" });
                dataBase.WorkItems.Add(new WorkItem() { ID = 10, CreatedDate = DateTime.UtcNow, UpdatedDate = DateTime.UtcNow, Amount = 454.3m, Jurisdiction = "Sample Juri service 3", Status = "Open", TaxTypeID = "Service Request Type", TypeofWorkItemID = "Service Request" });
                dataBase.WorkItems.Add(new WorkItem() { ID = 11, CreatedDate = DateTime.UtcNow, UpdatedDate = DateTime.UtcNow, Amount = 545.3m, Jurisdiction = "Sample Juri Other 1", Status = "UnWorking", TaxTypeID = "Other Corspondance Type", TypeofWorkItemID = "Other Corspondance" });
                dataBase.WorkItems.Add(new WorkItem() { ID = 12, CreatedDate = DateTime.UtcNow, UpdatedDate = DateTime.UtcNow, Amount = 945.3m, Jurisdiction = "Sample Juri Other 2", Status = "Working", TaxTypeID = "Other Corspondance type", TypeofWorkItemID = "Other Corspondance" });

                dataBase.SaveChanges();
            }
            }

        public async Task<(bool IsSuccess, IEnumerable<WorkItemModel> workItems, string ErrorMessage)> GetWorkItemsAsync()
        {
            try
            {
                var workItems = await dataBase.WorkItems.ToListAsync();
                if (workItems != null && workItems.Any())
                {
                    var result = mapper.Map<IEnumerable<WorkItem>, IEnumerable<WorkItemModel>>(workItems);
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
        public async Task<(bool IsSuccess, WorkItemModel workItem, string ErrorMessage)> GetWorkItemAsync(int id)
        {
            try
            {
                var workItem = await dataBase.WorkItems.FirstOrDefaultAsync(x=>x.ID==id);
                if (workItem != null)
                {
                    var result = mapper.Map<WorkItem, WorkItemModel>(workItem);
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
