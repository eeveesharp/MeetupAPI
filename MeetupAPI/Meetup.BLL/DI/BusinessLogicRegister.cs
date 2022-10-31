using Meetup.BLL.Interfaces;
using Meetup.BLL.Services;
using Meetup.DAL.DI;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Meetup.BLL.DI
{
    public static class BusinessLogicRegister
    {
        public static void AddBusinessLogic(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IUserService, UserService>();

            services.AddScoped<IEventService, EventService>();

            services.AddScoped<ITokenService, TokenService>();

            services.AddDataAccess(configuration);
        }
    }
}
