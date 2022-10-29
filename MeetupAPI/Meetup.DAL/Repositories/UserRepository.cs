using Meetup.DAL.EF;
using Meetup.DAL.Entities;
using Meetup.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Meetup.DAL.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationContext _applicationContext;

        private readonly DbSet<UserEntity> _dbSet;

        public UserRepository(ApplicationContext applicationContext,
            DbSet<UserEntity> dbSet)
        {
            _applicationContext = applicationContext;
            _dbSet = dbSet;
        }

        public async Task<UserEntity> Create(UserEntity item, CancellationToken ct)
        {
            await _dbSet.AddAsync(item, ct);

            await _applicationContext.SaveChangesAsync();

            return item;
        }

        public async Task DeleteById(int id, CancellationToken ct)
        {
            var item = _applicationContext.Users.Find(id);

            if (item != null)
            {
                _dbSet.Remove(item);

                await _applicationContext.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<UserEntity>> GetAll(CancellationToken ct)
        {
            return await _dbSet.AsNoTracking().ToListAsync(ct);
        }

        public async Task<UserEntity> GetById(int id, CancellationToken ct)
        {
            return await _applicationContext.Users.FirstAsync(x => x.Id == id, ct);
        }

        public async Task<UserEntity> Update(UserEntity item, CancellationToken ct)
        {
            _applicationContext.Users.Update(item);

            await _applicationContext.SaveChangesAsync();

            return item;
        }
    }
}
