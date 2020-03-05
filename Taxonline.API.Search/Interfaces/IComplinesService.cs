using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Taxonline.API.Search.Models;

namespace Taxonline.API.Search.Interfaces
{
    public interface IComplinesService
    {
        public Task<(bool IsSuccess, IEnumerable<ComplainesModel> ComplainFiles, string errorMessage)> GetComplainesAsync(int UserId);
    }
}
