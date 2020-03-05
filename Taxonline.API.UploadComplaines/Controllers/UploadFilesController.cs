using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Taxonline.API.UploadComplaines.Interface;

namespace Taxonline.API.UploadComplaines.Controllers
{
    [ApiController]
    [Route("api/UploadFile")]
    public class UploadFilesController : Controller
    {
        private readonly IComplinesProvider complinesProvider;

        public UploadFilesController(IComplinesProvider complinesProvider)
        {
            this.complinesProvider = complinesProvider;
        }
        [HttpGet("{UserId}")]
        public async Task<IActionResult> ActionResult(int UserId)
        {
           var complainesFile = await complinesProvider.GetComplainesFilesAsync(UserId);
            if(complainesFile.IsSuccess)
            {
                return Ok(complainesFile.complainesFiles);
            }
            return NotFound();
        }
    }
}
