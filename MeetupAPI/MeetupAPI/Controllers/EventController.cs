using AutoMapper;
using Meetup.BLL.Interfaces;
using Meetup.BLL.Models;
using MeetupAPI.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace MeetupAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EventController : ControllerBase
    {
        private readonly IEventService _eventServices;

        private readonly IMapper _mapper;

        public EventController(IEventService eventServices, IMapper mapper)
        {
            _eventServices = eventServices;
            _mapper = mapper;
        }
        
        [HttpGet]
        [ProducesResponseType(typeof(EventViewModel), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAll(CancellationToken ct)
        {
            return Ok(_mapper.Map<IEnumerable<EventViewModel>>(await _eventServices.GetAll(ct)));
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(EventViewModel), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetById(int id, CancellationToken ct)
        {
            return Ok(_mapper.Map<EventViewModel>(await _eventServices.GetById(id, ct)));
        }

        [HttpPut]
        [ProducesResponseType(typeof(EventViewModel), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Update(EventViewModel eventViewModel, CancellationToken ct)
        {
            return Ok(await _eventServices.Update(_mapper.Map<Event>(eventViewModel), ct));
        }

        [HttpPost]
        [ProducesResponseType(typeof(EventViewModel), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Create(EventViewModel eventViewModel, CancellationToken ct)
        {
            return Ok(await _eventServices.Create(_mapper.Map<Event>(eventViewModel), ct));
        }
    }
}
