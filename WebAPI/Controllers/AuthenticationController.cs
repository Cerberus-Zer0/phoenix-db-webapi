using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using WebAPI.Data;
using WebAPI.Dtos;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthentication _repo;
        private readonly IConfiguration _config;
        private readonly IMapper _mapper;

        public AuthenticationController(IAuthentication repo, IConfiguration config, IMapper mapper)
        {
            _mapper = mapper;
            _config = config;
            _repo = repo;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(AuthenticationRegisterDto registerDto)
        {
            registerDto.Email = registerDto.Email.ToLower();
            if (await _repo.UserExists(registerDto.Email))
                return BadRequest("Email already exists");

            var userToCreate = _mapper.Map<User>(registerDto);
            var createdUser = await _repo.Register(userToCreate, registerDto.Password);
            return StatusCode(201, new { email = createdUser.Email, firstname = createdUser.Firstname, lastname = createdUser.Lastname });
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(AuthenticationLoginDto loginDto)
        {
            var userFromRepo = await _repo.Login(loginDto.Email.ToLower(), loginDto.Password);
            if (userFromRepo == null)
                return Unauthorized();

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, userFromRepo.Id.ToString()),
                new Claim(ClaimTypes.Name, userFromRepo.Email)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8
                .GetBytes(_config.GetSection("AppSettings:Token").Value));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = creds
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return Ok(new { token = tokenHandler.WriteToken(token), email = userFromRepo.Email, firstname = userFromRepo.Firstname, lastname = userFromRepo.Lastname });
        }
    }
}
