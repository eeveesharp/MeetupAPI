using Meetup.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Meetup.DAL.EF
{
    public class ApplicationContext : DbContext
    {
        public DbSet<EventEntity> Events { get; set; }

        public DbSet<UserEntity> Users { get; set; }

        public DbSet<OrganizerEntity> Organizers { get; set; }

        public DbSet<SpeakerEntity> Speakers { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> contextOptions)
            : base(contextOptions)
        {
            Database.Migrate();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(builder);
        }
    }
}
