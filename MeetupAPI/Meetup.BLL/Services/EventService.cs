using AutoMapper;
using Meetup.BLL.Interfaces;
using Meetup.BLL.Models;
using Meetup.DAL.Entities;
using Meetup.DAL.Interfaces;

namespace Meetup.BLL.Services
{
    public class EventService : IEventService
    {
        private readonly IEventRepository _eventRepository;

        private readonly IMapper _mapper;

        public EventService(
            IEventRepository eventRepository,
            IMapper mapper)
        {
            _eventRepository = eventRepository;
            _mapper = mapper;
        }

        public async Task<Event> Create(Event item, CancellationToken ct)
        {
            return _mapper.Map<Event>(await _eventRepository.Create(_mapper.Map<EventEntity>(item), ct));
        }

        public async Task<bool> DeleteById(int id, CancellationToken ct)
        {
            return await _eventRepository.DeleteById(id, ct);
        }

        public async Task<IEnumerable<Event>> GetAll(CancellationToken ct)
        {
            return _mapper.Map<IEnumerable<Event>>(await _eventRepository.GetAll(ct));
        }

        public async Task<Event> GetById(int id, CancellationToken ct)
        {
            return _mapper.Map<Event>(await _eventRepository.GetById(id, ct));
        }

        public async Task<Event> Update(Event item, CancellationToken ct)
        {
            return _mapper.Map<Event>(await _eventRepository.Update(_mapper.Map<EventEntity>(item), ct));
        }
    }
}
