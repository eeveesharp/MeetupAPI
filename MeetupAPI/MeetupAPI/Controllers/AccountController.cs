using AutoMapper;
using Meetup.BLL.Interfaces;
using Meetup.BLL.Models;
using MeetupAPI.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Utils;

namespace JWTAuth.WebApi.Controllers
{
    [Route("api/Account")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        public IConfiguration _configuration;

        private readonly IUserService _userService;

        private readonly IMapper _mapper;

        public AccountController(IConfiguration config,
            IUserService userService,
            IMapper mapper)
        {
            _configuration = config;
            _userService = userService;
            _mapper = mapper;
        }

        [AllowAnonymous]
        [HttpPost(nameof(Login))]
        [ProducesResponseType(typeof(UserInfoViewModel), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Login(UserInfoViewModel userData, CancellationToken ct)
        {
            if (userData != null && userData.UserEmail != null && userData.Password != null)
            {
                userData.Password = PasswordHasher.HashPassword(userData.Password);

                var user = await _userService.GetUser(userData.UserEmail, userData.Password, ct);

                if (user != null)
                {
                    var claims = new[] {
                        new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                        new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                        new Claim(JwtRegisteredClaimNames.Email, user.Email)
                    };

                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
                    var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                    var jwtToken = new JwtSecurityToken(
                        _configuration["Jwt:Issuer"],
                        _configuration["Jwt:Audience"],
                        claims,
                        expires: DateTime.UtcNow.AddMinutes(10),
                        signingCredentials: signIn);

                    var token = new JwtSecurityTokenHandler().WriteToken(jwtToken);

                    Response.Cookies.Append("jwt", $"Bearer {token}");

                    return Ok(token);
                }
                else
                {
                    return BadRequest("Invalid credentials");
                }
            }
            else
            {
                return BadRequest();
            }
        }

        [AllowAnonymous]
        [HttpPost(nameof(Register))]
        [ProducesResponseType(typeof(UserViewModel), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Register(UserViewModel userData, CancellationToken ct)
        {
            userData.Password = PasswordHasher.HashPassword(userData.Password);

            return Ok(await _userService.Create(_mapper.Map<User>(userData), ct));
        }
    }
}
