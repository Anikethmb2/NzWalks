using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NzWalks.Models.DTOs;

namespace NzWalks.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<IdentityUser> userManager;
        public AuthController(UserManager<IdentityUser> userManager)
        {
            this.userManager = userManager;
        }

         //POST
        [HttpPost]
        [Route("Register")]
        public async  Task<IActionResult> Register([FromBody] RegisterRequestDto registerRequestDto )
        {
                var IdentityUser = new IdentityUser
                {
                    UserName = registerRequestDto.Username,
                    Email = registerRequestDto.Username,
                };
                var identityResult = await userManager.CreateAsync(IdentityUser,registerRequestDto.Password);

                if(identityResult.Succeeded)
                {
                    if(registerRequestDto.Role !=null && registerRequestDto.Role.Any())
                    {
                       identityResult= await userManager.AddToRolesAsync(IdentityUser, registerRequestDto.Role);
                    
                    if(identityResult.Succeeded)
                    {
                            return Ok("user was successfully register!Please Login");
                    }
                    }
                }
                return BadRequest("something went wrong");
        }
    }
}