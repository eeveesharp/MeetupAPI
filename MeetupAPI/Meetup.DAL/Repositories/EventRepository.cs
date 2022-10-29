using Meetup.DAL.EF;
using Meetup.DAL.Entities;
using Meetup.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Meetup.DAL.Repositories
{
    public class EventRepository : IEventRepository
    {
        private readonly ApplicationContext _applicationContext;

        public EventRepository(ApplicationContext applicationContext)
        {
            _applicationContext = applicationContext;
        }

        public async Task<EventEntity> Create(EventEntity item, CancellationToken ct)
        {
            await _applicationContext.Events.AddAsync(item, ct);

            await _applicationContext.SaveChangesAsync();

            return item;
        }

        public async Task DeleteById(int id, CancellationToken ct)
        {
            var item = _applicationContext.Events.Find(id);

            if (item != null)
            {
                _applicationContext.Events.Remove(item);

                await _applicationContext.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<EventEntity>> GetAll(CancellationToken ct)
        {
            return await _applicationContext.Events.AsNoTracking().ToListAsync(ct);
        }

        public async Task<EventEntity> GetById(int id, CancellationToken ct)
        {
            return await _applicationContext.Events.FirstAsync(x => x.Id == id, ct);
        }

        public async Task<EventEntity> Update(EventEntity item, CancellationToken ct)
        {
            _applicationContext.Events.Update(item);

            await _applicationContext.SaveChangesAsync();

            return item;
        }
    }
}
