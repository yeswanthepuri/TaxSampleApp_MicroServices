using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Taxonline.API.Search.Interfaces
{
    public interface ISearchService
    {
        public Task<(bool IsSuccess, dynamic SearchResult)> SearchSync(int userId);
    }
}
