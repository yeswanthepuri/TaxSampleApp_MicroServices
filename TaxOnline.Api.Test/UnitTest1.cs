using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using Taxonline.API.WorkItems.DB;
using Taxonline.API.WorkItems.Models;
using Taxonline.API.WorkItems.Profile;
using Xunit;

namespace TaxOnline.Api.Test
{
    public class WorkItemSerViceTest
    {
        [Fact]
        public async Task GetWorkItemsReturnAllWorkItem()
        {
            var option = new DbContextOptionsBuilder<WorkItemDbContext>().UseInMemoryDatabase(nameof(GetWorkItemsReturnAllWorkItem)).Options;
            var DbContext = new WorkItemDbContext(option);
            CreateNewWorkItems(DbContext);
            var WorkitemProfile = new WorkItemProfile();
            var config = new MapperConfiguration(cnf => cnf.AddProfile(WorkitemProfile));
            var mapper = new Mapper(config);
            WorkItemProvider workItemProvider = new WorkItemProvider(DbContext, null, mapper);

           var workItem =await workItemProvider.GetWorkItemsAsync();

            Assert.True(workItem.IsSuccess);
            Assert.True(workItem.workItems.Any());
            Assert.Equal(12, workItem.workItems.Count());

        }
        [Fact]
        public async Task GetWorkItemsReturnWorkItemForValidInputId()
        {
            var option = new DbContextOptionsBuilder<WorkItemDbContext>().UseInMemoryDatabase(nameof(GetWorkItemsReturnAllWorkItem)).Options;
            var DbContext = new WorkItemDbContext(option);
            //CreateNewWorkItems(DbContext);
            var WorkitemProfile = new WorkItemProfile();
            var config = new MapperConfiguration(cnf => cnf.AddProfile(WorkitemProfile));
            var mapper = new Mapper(config);
            WorkItemProvider workItemProvider = new WorkItemProvider(DbContext, null, mapper);

            var workItem = await workItemProvider.GetWorkItemAsync(1);

            Assert.True(workItem.IsSuccess);
            Assert.Equal(45.3m, workItem.workItem.Amount);
            Assert.Equal("Sample Juri Notice 1", workItem.workItem.Jurisdiction);
            Assert.Null(workItem.ErrorMessage);

        }
        [Fact]
        public async Task GetWorkItemsReturnWorkItemForInValidInputId()
        {
            var option = new DbContextOptionsBuilder<WorkItemDbContext>().UseInMemoryDatabase(nameof(GetWorkItemsReturnAllWorkItem)).Options;
            var DbContext = new WorkItemDbContext(option);
            //CreateNewWorkItems(DbContext);
            var WorkitemProfile = new WorkItemProfile();
            var config = new MapperConfiguration(cnf => cnf.AddProfile(WorkitemProfile));
            var mapper = new Mapper(config);
            WorkItemProvider workItemProvider = new WorkItemProvider(DbContext, null, mapper);

            var workItem = await workItemProvider.GetWorkItemAsync(20);

            Assert.True(!workItem.IsSuccess);
            Assert.Null(workItem.workItem);
            Assert.NotNull(workItem.ErrorMessage);

        }

        private void CreateNewWorkItems(WorkItemDbContext dbContext)
        {
            dbContext.WorkItems.Add(new WorkItem() { ID = 1, CreatedDate = DateTime.UtcNow, UpdatedDate = DateTime.UtcNow, Amount = 45.3m, Jurisdiction = "Sample Juri Notice 1", Status = "UnWorking", TaxTypeID = "Business Licence", TypeofWorkItemID = "Notice" });
            dbContext.WorkItems.Add(new WorkItem() { ID = 2, CreatedDate = DateTime.UtcNow, UpdatedDate = DateTime.UtcNow, Amount = 145.3m, Jurisdiction = "Sample Juri Notice 2", Status = "Working", TaxTypeID = "Business Licence", TypeofWorkItemID = "Notice" });
            dbContext.WorkItems.Add(new WorkItem() { ID = 3, CreatedDate = DateTime.UtcNow, UpdatedDate = DateTime.UtcNow, Amount = 5.3m, Jurisdiction = "Sample Juri Notice 3", Status = "Resolved", TaxTypeID = "Notice Type", TypeofWorkItemID = "Notice" });
            dbContext.WorkItems.Add(new WorkItem() { ID = 4, CreatedDate = DateTime.UtcNow, UpdatedDate = DateTime.UtcNow, Amount = 15.3m, Jurisdiction = "Sample Juri Reg 1", Status = "Open", TaxTypeID = "New Registration", TypeofWorkItemID = "Registration" });
            dbContext.WorkItems.Add(new WorkItem() { ID = 5, CreatedDate = DateTime.UtcNow, UpdatedDate = DateTime.UtcNow, Amount = 4.3m, Jurisdiction = "Sample Juri Reg 2", Status = "Open", TaxTypeID = "Old Registration", TypeofWorkItemID = "Registration" });
            dbContext.WorkItems.Add(new WorkItem() { ID = 6, CreatedDate = DateTime.UtcNow, UpdatedDate = DateTime.UtcNow, Amount = 43.3m, Jurisdiction = "Sample Juri Reg 3", Status = "Ready", TaxTypeID = "New Registration", TypeofWorkItemID = "Registration" });
            dbContext.WorkItems.Add(new WorkItem() { ID = 7, CreatedDate = DateTime.UtcNow, UpdatedDate = DateTime.UtcNow, Amount = 24.3m, Jurisdiction = "Sample Juri ent 1", Status = "Open", TaxTypeID = "Close Entity", TypeofWorkItemID = "Entity" });
            dbContext.WorkItems.Add(new WorkItem() { ID = 8, CreatedDate = DateTime.UtcNow, UpdatedDate = DateTime.UtcNow, Amount = 445.3m, Jurisdiction = "Sample Juri service 1", Status = "Completed", TaxTypeID = "Service Request Type", TypeofWorkItemID = "Service Request" });
            dbContext.WorkItems.Add(new WorkItem() { ID = 9, CreatedDate = DateTime.UtcNow, UpdatedDate = DateTime.UtcNow, Amount = 413.3m, Jurisdiction = "Sample Juri service 2", Status = "Ready", TaxTypeID = "Service Request Type", TypeofWorkItemID = "Service Request" });
            dbContext.WorkItems.Add(new WorkItem() { ID = 10, CreatedDate = DateTime.UtcNow, UpdatedDate = DateTime.UtcNow, Amount = 454.3m, Jurisdiction = "Sample Juri service 3", Status = "Open", TaxTypeID = "Service Request Type", TypeofWorkItemID = "Service Request" });
            dbContext.WorkItems.Add(new WorkItem() { ID = 11, CreatedDate = DateTime.UtcNow, UpdatedDate = DateTime.UtcNow, Amount = 545.3m, Jurisdiction = "Sample Juri Other 1", Status = "UnWorking", TaxTypeID = "Other Corspondance Type", TypeofWorkItemID = "Other Corspondance" });
            dbContext.WorkItems.Add(new WorkItem() { ID = 12, CreatedDate = DateTime.UtcNow, UpdatedDate = DateTime.UtcNow, Amount = 945.3m, Jurisdiction = "Sample Juri Other 2", Status = "Working", TaxTypeID = "Other Corspondance type", TypeofWorkItemID = "Other Corspondance" });
            dbContext.SaveChanges();
        }

    }
}
