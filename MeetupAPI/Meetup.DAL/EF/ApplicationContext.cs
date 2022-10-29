using Meetup.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace Meetup.DAL.EF
{
    public class ApplicationContext : DbContext
    {
        public DbSet<EventEntity> Events { get; set; }

        public DbSet<UserEntity> Users { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> contextOptions)
            : base(contextOptions)
        {
            
        }
    }
}
