using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dress_u_backend.Dtos.Account;
using dress_u_backend.Interfaces;
using dress_u_backend.Mappers;
using dress_u_backend.models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace dress_u_backend.Controllers
{
    [ApiController]
    [Route("/account")]
    public class AccountController(UserManager<AppUser> userManager, ITokenService tokenService) : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager = userManager;
        private readonly ITokenService _tokenService = tokenService;
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto registerDto)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var user = new AppUser
                {
                    UserName = registerDto.Username,
                    Email = registerDto.Email
                };

                var result = await _userManager.CreateAsync(user, registerDto.Password);
                if (!result.Succeeded)
                {
                    return BadRequest(result.Errors);
                }
                var roleResult = await _userManager.AddToRoleAsync(user, "User");
                if (!roleResult.Succeeded)
                {
                    return StatusCode(500, roleResult.Errors);
                }

                return Ok(user.ToUserDto(_tokenService.CreateToken(user)));
            }
            catch (Exception e)
            {
                return StatusCode(500, e);
            }
        }



    }
}