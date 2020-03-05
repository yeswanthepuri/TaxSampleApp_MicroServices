using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Taxonline.API.Activity.Models.Interfaces;

namespace Taxonline.API.Activity.Controllers
{
    [ApiController]
    [Route("api/Activity")]
    public class ActivityController : Controller
    {
        private readonly IActivityProvider workItemProvider;

        public ActivityController(IActivityProvider workItemProvider)
        {
            this.workItemProvider = workItemProvider;
        }


        [HttpGet]
        public async Task<IActionResult> GetProductsAsync()
        {
            var result = await workItemProvider.GetActivitiesAsync();

            if(result.IsSuccess)
            {
                return Ok(result.activitieModel);
            }
            return NotFound();
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductAsync(int id)
        {
            var result = await workItemProvider.GetActivitieAsync(id);

            if (result.IsSuccess)
            {
                return Ok(result.activitieModel);
            }
            return NotFound();
        }
    }
}