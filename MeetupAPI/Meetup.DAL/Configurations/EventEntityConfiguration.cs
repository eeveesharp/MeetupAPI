using Meetup.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Meetup.DAL.Configurations
{
    internal class EventEntityConfiguration : IEntityTypeConfiguration<EventEntity>
    {
        public void Configure(EntityTypeBuilder<EventEntity> builder)
        {
            builder.Property(x => x.Name).HasMaxLength(256);

            builder.Property(x => x.PlaceEvent).HasMaxLength(256);

            builder.Property(x => x.Description).HasMaxLength(256);

            builder.Property(x => x.Plan).HasMaxLength(256);

            builder.HasOne(e => e.Speaker)
                .WithMany()
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(e => e.Organizer)
                .WithMany()
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
