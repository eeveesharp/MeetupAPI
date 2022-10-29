using Meetup.DAL.EF;
using Meetup.DAL.Interfaces;
using Meetup.DAL.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Meetup.DAL.DI
{
    public static class DataAccessRegister
    {
        public static void AddDataAccess(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IUserRepository, UserRepository>();

            services.AddScoped<IEventRepository, EventRepository>();

            services.AddDbContext<ApplicationContext>(context =>
            {
                context.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            });
        }
    }
}
