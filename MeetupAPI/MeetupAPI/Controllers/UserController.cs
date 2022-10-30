﻿using AutoMapper;
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
        public async Task<IActionResult> Update(UserViewModel eventViewModel, CancellationToken ct)
        {
            return Ok(await _userServices.Update(_mapper.Map<User>(eventViewModel), ct));
        }

        [HttpPost]
        [ProducesResponseType(typeof(UserViewModel), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Create(UserViewModel eventViewModel, CancellationToken ct)
        {
            return Ok(await _userServices.Create(_mapper.Map<User>(eventViewModel), ct));
        }
    }
}
