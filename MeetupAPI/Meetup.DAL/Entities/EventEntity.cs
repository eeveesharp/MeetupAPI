using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Meetup.DAL.Entities
{
    public class EventEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Plan { get; set; }

        public int OrganizerId { get; set; }
        [ForeignKey("OrganizerId")]
        public OrganizerEntity Organizer { get; set; }

        public int SpeakerId { get; set; }
        [ForeignKey("SpeakerId")]
        public SpeakerEntity Speaker { get; set; }

        public DateTimeOffset DateTimeEvent { get; set; }

        public string PlaceEvent { get; set; }
    }
}
