using Meetup.BLL.Models;

namespace Meetup.BLL.Interfaces
{
    public interface IUserService : IService<User>
    {
        Task<User> GetUserByEmail(string email, CancellationToken ct);
    }
}
