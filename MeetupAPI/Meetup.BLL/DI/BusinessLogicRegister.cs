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
            services.AddScoped<IUserServices, UserServices>();

            services.AddScoped<IEventServices, EventServices>();

            services.AddDataAccess(configuration);
        }
    }
}
