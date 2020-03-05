using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Taxonline.API.Search.Models;

namespace Taxonline.API.Search.Interfaces
{
    public interface IWorkItesmService
    {
        public Task<(bool IsSuccess, IEnumerable<WorkItemModel> workitem, string errorMessage)> GetWorkItemsAsync();
        public Task<(bool IsSuccess, WorkItemModel workitem, string errorMessage)> GetWorkItemAsync(int ID);
    }
}
