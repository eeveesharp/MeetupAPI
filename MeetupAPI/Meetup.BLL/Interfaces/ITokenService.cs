using Meetup.BLL.Models;

namespace Meetup.BLL.Interfaces
{
    public interface ITokenService
    {
        string GetToken(User user);
    }
}
