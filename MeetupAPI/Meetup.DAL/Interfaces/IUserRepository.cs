using Meetup.DAL.Entities;

namespace Meetup.DAL.Interfaces
{
    public interface IUserRepository : IRepository<UserEntity>
    {
        Task<UserEntity> GetUserByEmail(string email, CancellationToken ct);
    }
}
