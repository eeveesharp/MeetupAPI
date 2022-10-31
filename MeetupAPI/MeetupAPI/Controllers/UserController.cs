using AutoMapper;
using Meetup.BLL.Interfaces;
using Meetup.BLL.Models;
using MeetupAPI.Atributes;
using MeetupAPI.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Utils;

namespace MeetupAPI.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userServices;

        private readonly IMapper _mapper;

        public UserController(
            IUserService eventServices,
            IMapper mapper)
        {
            _userServices = eventServices;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(typeof(UserViewModel), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAll(CancellationToken ct)
        {
            return Ok(_mapper.Map<IEnumerable<UserViewModel>>(await _userServices.GetAll(ct)));
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(UserViewModel), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetById(int id, CancellationToken ct)
        {
            return Ok(_mapper.Map<UserViewModel>(await _userServices.GetById(id, ct)));
        }

        [HttpPut]
        [ProducesResponseType(typeof(UserViewModel), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Update(UserViewModel userViewModel, CancellationToken ct)
        {
            return Ok(await _userServices.Update(_mapper.Map<User>(userViewModel), ct));
        }

        [HttpPost]
        [ProducesResponseType(typeof(UserViewModel), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Create(UserViewModel userViewModel, CancellationToken ct)
        {
            userViewModel.Password = PasswordHasher.HashPassword(userViewModel.Password);

            return Ok(await _userServices.Create(_mapper.Map<User>(userViewModel), ct));
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(UserViewModel), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteById(int id, CancellationToken ct)
        {
            var isDeleted = await _userServices.DeleteById(id, ct);

            if (isDeleted)
            {
                return Ok();
            }

            return NotFound();
        }
    }
}
