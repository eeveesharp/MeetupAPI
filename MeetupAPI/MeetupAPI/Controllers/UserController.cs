using AutoMapper;
using Meetup.BLL.Interfaces;
using Meetup.BLL.Models;
using MeetupAPI.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace MeetupAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserServices _userServices;

        private readonly IMapper _mapper;

        public UserController(IUserServices eventServices, IMapper mapper)
        {
            _userServices = eventServices;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<UserViewModel>> GetAll(CancellationToken ct)
        {
            return _mapper.Map<IEnumerable<UserViewModel>>(await _userServices.GetAll(ct));
        }

        [HttpGet("{id}")]
        public async Task<UserViewModel> GetById(int id, CancellationToken ct)
        {
            return _mapper.Map<UserViewModel>(await _userServices.GetById(id, ct));
        }

        [HttpPut]
        public async Task<IResult> Update(UserViewModel eventViewModel, CancellationToken ct)
        {
            return (IResult)Ok(await _userServices.Update(_mapper.Map<User>(eventViewModel), ct));
        }

        [HttpPost]
        public async Task<IResult> Create(UserViewModel eventViewModel, CancellationToken ct)
        {
            return (IResult)Ok(await _userServices.Create(_mapper.Map<User>(eventViewModel), ct));
        }
    }
}
