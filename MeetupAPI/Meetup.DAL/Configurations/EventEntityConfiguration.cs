using Meetup.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Meetup.DAL.Configurations
{
    internal class EventEntityConfiguration : IEntityTypeConfiguration<EventEntity>
    {
        public void Configure(EntityTypeBuilder<EventEntity> builder)
        {
            builder.HasKey(e => e.Id);

            builder.HasAlternateKey(e => e.OrganizerId);

            builder.HasAlternateKey(e => e.SpeakerId);

            builder.HasOne(e => e.Organizer)
                .WithOne()
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
