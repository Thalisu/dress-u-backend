using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dress_u_backend.Dtos.Account;
using dress_u_backend.Interfaces;
using dress_u_backend.Mappers;
using dress_u_backend.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace dress_u_backend.Controllers
{
    [ApiController]
    [Route("/account")]
    public class AccountController(UserManager<AppUser> userManager, ITokenService tokenService, SignInManager<AppUser> signInManager) : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager = userManager;
        private readonly ITokenService _tokenService = tokenService;
        private readonly SignInManager<AppUser> _signInManager = signInManager;
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
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
        {
            var hasEmail = !string.IsNullOrEmpty(loginDto.Email);
            var hasUser = !string.IsNullOrEmpty(loginDto.Username);
            if (!hasEmail && !hasUser)
            {
                var msg = "Email or Username is required.";
                ModelState.AddModelError("Email", msg);
                ModelState.AddModelError("Username", msg);
            }
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var user = hasEmail
            ? await _userManager.Users.FirstOrDefaultAsync(u => u.Email == loginDto.Email)
            : await _userManager.Users.FirstOrDefaultAsync(u => u.UserName == loginDto.Username);

            if (user == null)
            {
                return Unauthorized("User not found.");
            }

            var result = await _signInManager.CheckPasswordSignInAsync(user, loginDto.Password, false);
            if (!result.Succeeded)
            {
                return Unauthorized();
            }

            return Ok(user.ToUserDto(_tokenService.CreateToken(user)));
        }
    }
}