using Meetup.DAL.Entities;

namespace Meetup.DAL.Interfaces
{
    public interface IUserRepository : IRepository<UserEntity>
    {
        Task<UserEntity> GetUser(string email, string password, CancellationToken ct);

        Task<UserEntity> GetUserByEmail(string email, CancellationToken ct);
    }
}
