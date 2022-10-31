using Meetup.BLL.Models;

namespace Meetup.BLL.Interfaces
{
    public interface ITokenService
    {
        Task<string> GetToken(User user);
    }
}
