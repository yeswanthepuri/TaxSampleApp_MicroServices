using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Taxonline.API.WorkItems.Models.Interfaces;

namespace Taxonline.API.WorkItems.Controllers
{
    [ApiController]
    [Route("api/WorkItem")]
    public class WorkItemController : Controller
    {
        private readonly IWorkItemProvider workItemProvider;

        public WorkItemController(IWorkItemProvider workItemProvider)
        {
            this.workItemProvider = workItemProvider;
        }


        [HttpGet]
        public async Task<IActionResult> GetProductsAsync()
        {
            var result = await workItemProvider.GetWorkItemsAsync();

            if(result.IsSuccess)
            {
                return Ok(result.workItems);
            }
            return NotFound();
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductAsync(int id)
        {
            var result = await workItemProvider.GetWorkItemAsync(id);

            if (result.IsSuccess)
            {
                return Ok(result.workItem);
            }
            return NotFound();
        }
    }
}