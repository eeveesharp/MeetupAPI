using AutoMapper;
using Meetup.BLL.Interfaces;
using Meetup.BLL.Models;
using MeetupAPI.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Utils;

namespace MeetupAPI.Controllers
{
    [Route("api/Account")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        public IConfiguration _configuration;

        private readonly IUserService _userService;

        private readonly ITokenService _tokenService;

        private readonly IMapper _mapper;

        public AccountController(
            IConfiguration config,
            IUserService userService,
            ITokenService tokenService,
            IMapper mapper)
        {
            _configuration = config;
            _userService = userService;
            _tokenService = tokenService;
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
                    var token = await _tokenService.GetToken(user);

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
