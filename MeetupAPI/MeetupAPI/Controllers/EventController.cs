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
        private readonly IEventServices _eventServices;

        private readonly IMapper _mapper;

        public EventController(IEventServices eventServices, IMapper mapper)
        {
            _eventServices = eventServices;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<EventViewModel>> GetAll(CancellationToken ct)
        {
            return _mapper.Map<IEnumerable<EventViewModel>>(await _eventServices.GetAll(ct));
        }

        [HttpGet("{id}")]
        public async Task<EventViewModel> GetById(int id, CancellationToken ct)
        {
            return _mapper.Map<EventViewModel>(await _eventServices.GetById(id, ct));
        }

        [HttpPut]
        public async Task<IResult> Update(EventViewModel eventViewModel, CancellationToken ct)
        {
            return (IResult)Ok(await _eventServices.Update(_mapper.Map<Event>(eventViewModel), ct));
        }

        [HttpPost]
        public async Task<IResult> Create(EventViewModel eventViewModel, CancellationToken ct)
        {
            return (IResult)Ok(await _eventServices.Create(_mapper.Map<Event>(eventViewModel), ct));
        }
    }
}
