using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TaxOnline.API.Users.Interfaces;

namespace TaxOnline.API.Users.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UserController : Controller
    {
        private readonly IUserProvider userProvider;

        public UserController(IUserProvider userProvider)
        {
            this.userProvider = userProvider;
        }
        [HttpGet]
        public async Task<IActionResult> GetUsersAsync()
        {
            var result =await userProvider.GetUsersAsync();
            if(result.IsSuccess)
            {
                return Ok(result.Users);
            }
            return NotFound();
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserAsync(int id)
        {
            var result = await userProvider.GetUserAsync(id);
            if (result.IsSuccess)
            {
                return Ok(result.User);
            }
            return NotFound();
        }
    }
}