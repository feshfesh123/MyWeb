using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdentityModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using TFTB.Identity.Models;
using TFTB.Identity.ViewModels;
using TFTB.Data.Repository;

namespace TFTB.Identity.Controllers
{
    
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<User> userManager;
        public AccountController(UserManager<User> userManager)
        {
            this.userManager = userManager;
        }

        [HttpPost]
        [Route("api/[controller]")]
        public async Task<IActionResult> Register([FromBody] RegisterViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var user = new User() { Email = model.Email, UserName = model.Email, Fullname = model.Fullname, Money = 0 };

            var result = await userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                await HttpContext.RequestServices.GetRequiredService<IUserRepository>()
                    .Create(new TFTB.Data.Entities.User { Id = user.Id, Money = 0, Name = user.Fullname });

                return Ok(new RegisterResponseViewModel(user));
            }

            else
                return BadRequest(result.Errors);
        }
    }
}