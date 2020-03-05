using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Taxonline.API.Search.Models;

namespace Taxonline.API.Search.Interfaces
{
    public interface IActivityService
    {
        public Task<(bool IsSuccess, IEnumerable<ActivityModel> ActivityModel, string errorMessage)> GetActivitysAsync();
    }
}
