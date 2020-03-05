using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Taxonline.API.WorkItems.DB;

namespace Taxonline.API.WorkItems.Models.Interfaces
{
   public interface IWorkItemProvider
    {
        Task<(bool IsSuccess, IEnumerable<WorkItemModel> workItems, String ErrorMessage)> GetWorkItemsAsync();
        Task<(bool IsSuccess, WorkItemModel workItem, String ErrorMessage)> GetWorkItemAsync(int id);
    }
}
