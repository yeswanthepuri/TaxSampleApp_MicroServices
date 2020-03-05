using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Taxonline.API.Search.Interfaces;
using Taxonline.API.Search.Models;

namespace Taxonline.API.Search.Controllers
{
    [ApiController]
    [Route("api/search")]
    public class SearchController : ControllerBase
    {
        private readonly ISearchService searchService;

        public SearchController(ISearchService searchService)
        {
            this.searchService = searchService;
        }
        [HttpPost]
        public async Task<IActionResult> SearchAsync(SearchTerm searchTerm)
        {
            var result = await searchService.SearchSync(searchTerm.UserId);

            if(result.IsSuccess)
            {
                return Ok(result.SearchResult);
            }
            return NotFound();
        }
    }
}