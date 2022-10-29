using Meetup.DAL.EF;
using Meetup.DAL.Entities;
using Meetup.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Meetup.DAL.Repositories
{
    public class EventRepository : IEventRepository
    {
        private readonly ApplicationContext _applicationContext;

        private readonly DbSet<EventEntity> _dbSet;

        public EventRepository(ApplicationContext applicationContext,
            DbSet<EventEntity> dbSet)
        {
            _applicationContext = applicationContext;
            _dbSet = dbSet;
        }

        public async Task<EventEntity> Create(EventEntity item, CancellationToken ct)
        {
            await _dbSet.AddAsync(item, ct);

            await _applicationContext.SaveChangesAsync();

            return item;
        }

        public async Task DeleteById(int id, CancellationToken ct)
        {
            var item = _applicationContext.Events.Find(id);

            if (item != null)
            {
                _dbSet.Remove(item);

                await _applicationContext.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<EventEntity>> GetAll(CancellationToken ct)
        {
            return await _dbSet.AsNoTracking().ToListAsync(ct);
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
