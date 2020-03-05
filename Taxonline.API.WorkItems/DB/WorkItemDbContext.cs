using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Taxonline.API.WorkItems.DB
{
    public class WorkItemDbContext : DbContext
    {
        public DbSet<WorkItem> WorkItems { get; set; }
        public DbSet<TaxType> TaxTypes { get; set; }
        public DbSet<TypeOfWorkItem> TypeOfWorkItems { get; set; }

        public WorkItemDbContext(DbContextOptions options) :
            base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Seed();
        }


    }
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
           // modelBuilder.Entity<TypeOfWorkItem>().HasData(
           //    new TypeOfWorkItem
           //    {
           //        ID = 1,
           //        Description = "Notice",
           //    },
           //    new TypeOfWorkItem
           //    {
           //        ID = 2,
           //        Description = "Registration",
           //    },
           //    new TypeOfWorkItem
           //    {
           //        ID = 3,
           //        Description = "Entity",
           //    },
           //    new TypeOfWorkItem
           //    {
           //        ID = 4,
           //        Description = "Service Request",
           //    },
           //       new TypeOfWorkItem
           //       {
           //           ID = 5,
           //           Description = "Other Corspondance",
           //       }
           //);
           // modelBuilder.Entity<TaxType>().HasData(
           //         new TaxType { ID = 1, Description = "Business Licence", WorkItemType = 1 },
           //         new TaxType { ID = 2, Description = "Property Tax", WorkItemType = 1 },
           //         new TaxType { ID = 3, Description = "Other Type", WorkItemType = 1 },
           //         new TaxType { ID = 4, Description = "New Registration", WorkItemType = 2 },
           //         new TaxType { ID = 5, Description = "Closed Registration", WorkItemType = 2 },
           //         new TaxType { ID = 6, Description = "New Entity", WorkItemType = 3 },
           //         new TaxType { ID = 7, Description = "Close Entity", WorkItemType = 3 },
           //         new TaxType { ID = 8, Description = "Sample1", WorkItemType = 4 },
           //         new TaxType { ID = 9, Description = "Sample2", WorkItemType = 5 },
           //         new TaxType { ID = 10, Description = "Sample3", WorkItemType = 5 }
           //          );
            modelBuilder.Entity<WorkItem>().HasData(
                    new WorkItem() { ID = 1, CreatedDate = DateTime.UtcNow, UpdatedDate = DateTime.UtcNow, Amount = 45.3m, Jurisdiction = "Sample Juri Notice 1", Status = "UnWorking", TaxTypeID = "Business Licence", TypeofWorkItemID = "Notice" },
                    new WorkItem() { ID = 2, CreatedDate = DateTime.UtcNow, UpdatedDate = DateTime.UtcNow, Amount = 145.3m, Jurisdiction = "Sample Juri Notice 2", Status = "Working", TaxTypeID = "Business Licence", TypeofWorkItemID = "Notice" },
                    new WorkItem() { ID = 3, CreatedDate = DateTime.UtcNow, UpdatedDate = DateTime.UtcNow, Amount = 5.3m, Jurisdiction = "Sample Juri Notice 3", Status = "Resolved", TaxTypeID = "Notice Type", TypeofWorkItemID = "Notice" },
                    new WorkItem() { ID = 4, CreatedDate = DateTime.UtcNow, UpdatedDate = DateTime.UtcNow, Amount = 15.3m, Jurisdiction = "Sample Juri Reg 1", Status = "Open", TaxTypeID = "New Registration", TypeofWorkItemID = "Registration" },
                    new WorkItem() { ID = 5, CreatedDate = DateTime.UtcNow, UpdatedDate = DateTime.UtcNow, Amount = 4.3m, Jurisdiction = "Sample Juri Reg 2", Status = "Open", TaxTypeID = "Old Registration", TypeofWorkItemID = "Registration" },
                    new WorkItem() { ID = 6, CreatedDate = DateTime.UtcNow, UpdatedDate = DateTime.UtcNow, Amount = 43.3m, Jurisdiction = "Sample Juri Reg 3", Status = "Ready", TaxTypeID = "New Registration", TypeofWorkItemID = "Registration" },
                    new WorkItem() { ID = 7, CreatedDate = DateTime.UtcNow, UpdatedDate = DateTime.UtcNow, Amount = 24.3m, Jurisdiction = "Sample Juri ent 1", Status = "Open", TaxTypeID = "Close Entity", TypeofWorkItemID = "Entity" },
                    new WorkItem() { ID = 8, CreatedDate = DateTime.UtcNow, UpdatedDate = DateTime.UtcNow, Amount = 445.3m, Jurisdiction = "Sample Juri service 1", Status = "Completed", TaxTypeID = "Service Request Type", TypeofWorkItemID = "Service Request" },
                    new WorkItem() { ID = 9, CreatedDate = DateTime.UtcNow, UpdatedDate = DateTime.UtcNow, Amount = 413.3m, Jurisdiction = "Sample Juri service 2", Status = "Ready", TaxTypeID = "Service Request Type", TypeofWorkItemID = "Service Request" },
                    new WorkItem() { ID = 10, CreatedDate = DateTime.UtcNow, UpdatedDate = DateTime.UtcNow, Amount = 454.3m, Jurisdiction = "Sample Juri service 3", Status = "Open", TaxTypeID = "Service Request Type", TypeofWorkItemID = "Service Request" },
                    new WorkItem() { ID = 11, CreatedDate = DateTime.UtcNow, UpdatedDate = DateTime.UtcNow, Amount = 545.3m, Jurisdiction = "Sample Juri Other 1", Status = "UnWorking", TaxTypeID = "Other Corspondance Type", TypeofWorkItemID = "Other Corspondance" },
                    new WorkItem() { ID = 12, CreatedDate = DateTime.UtcNow, UpdatedDate = DateTime.UtcNow, Amount = 945.3m, Jurisdiction = "Sample Juri Other 2", Status = "Working", TaxTypeID = "Other Corspondance type", TypeofWorkItemID = "Other Corspondance" }
                     );
        }
    }

}
