using Meetup.DAL.EF;
using Meetup.DAL.Entities;
using Meetup.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Meetup.DAL.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationContext _applicationContext;

        public UserRepository(ApplicationContext applicationContext)
        {
            _applicationContext = applicationContext;
        }

        public async Task<UserEntity> Create(UserEntity item, CancellationToken ct)
        {
            await _applicationContext.Users.AddAsync(item, ct);

            await _applicationContext.SaveChangesAsync();

            return item;
        }

        public async Task DeleteById(int id, CancellationToken ct)
        {
            var item = _applicationContext.Users.FirstOrDefault(x => x.Id == id);

            if (item != null)
            {
                _applicationContext.Users.Remove(item);

                await _applicationContext.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<UserEntity>> GetAll(CancellationToken ct)
        {
            return await _applicationContext.Users.AsNoTracking().ToListAsync(ct);
        }

        public async Task<UserEntity> GetById(int id, CancellationToken ct)
        {
            return await _applicationContext.Users.FirstOrDefaultAsync(x => x.Id == id, ct);
        }

        public async Task<UserEntity> GetUser(string email, string password, CancellationToken ct)
        {
            return await _applicationContext.Users.FirstOrDefaultAsync(x => x.Email == email && x.Password == password, ct);
        }

        public async Task<UserEntity> Update(UserEntity item, CancellationToken ct)
        {
            _applicationContext.Users.Update(item);

            await _applicationContext.SaveChangesAsync();

            return item;
        }
    }
}
