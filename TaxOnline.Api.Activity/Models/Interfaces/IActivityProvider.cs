using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Taxonline.API.Activity.DB;

namespace Taxonline.API.Activity.Models.Interfaces
{
   public interface IActivityProvider
    {
        Task<(bool IsSuccess, IEnumerable<ActivitieModel> activitieModel, String ErrorMessage)> GetActivitiesAsync();
        Task<(bool IsSuccess, ActivitieModel activitieModel, String ErrorMessage)> GetActivitieAsync(int id);
    }
}
