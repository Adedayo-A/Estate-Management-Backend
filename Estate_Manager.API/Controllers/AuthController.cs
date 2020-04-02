using AutoMapper;
using Estate_Manager.API.Data.Entities;
using Estate_Manager.API.Data.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Estate_Manager.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<User> manager;
        private readonly IMapper mapper;
        private readonly IConfiguration configuration;

        public AuthController(UserManager<User> manager, IMapper mapper, IConfiguration configuration)
        {
            this.manager = manager;
            this.mapper = mapper;
            this.configuration = configuration;
        }
       
        //[Authorize(Policy = "Admin")]
        [HttpPost("login")]
        public async Task<IActionResult> Login(UserLoginVM user)
        {
            
            var userFromRepo = await manager.FindByNameAsync(user.Username);

            if (userFromRepo is null) return BadRequest("Username/Password is incorrect");

            var verifyPassword = await manager.CheckPasswordAsync(userFromRepo, user.Password);

            if (!verifyPassword) return BadRequest("Username/Password is incorrect");


            return Ok(new
            {
                token = await GenerateJwtToken(userFromRepo)
            });
            
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(UserCreateVM user)
        {
            var userToCreate = mapper.Map<User>(user);
            var userForRepo = await manager.CreateAsync(userToCreate, user.Password);
            if(!userForRepo.Succeeded)
            {
                return StatusCode(500);
            }

            var userFromRepo = await manager.FindByNameAsync(userToCreate.UserName);

            var addRole = await manager.AddToRoleAsync(userFromRepo, user.Role);
            if(!addRole.Succeeded)
            {
                return StatusCode(500);
            }

            return Ok("Created Successful");

        }

        private async Task<string> GenerateJwtToken(User user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.UserName)
            };

            var roles = await manager.GetRolesAsync(user);

            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            var secret = configuration.GetSection("AppSettings:Secret").Value;
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secret));

            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var issuer = configuration.GetSection("AppSettings:Issuer").Value;
            var audience = configuration.GetSection("Appsettings:Audience").Value;

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddHours(2),
                SigningCredentials = credentials,
                Issuer = issuer,
                Audience = audience
            };

            var tokenHandler = new JwtSecurityTokenHandler();

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}
