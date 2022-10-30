using System;

namespace Meetup.BLL.Models
{
    public class Event
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Plan { get; set; }

        public int OrganizerId { get; set; }

        public int SpeakerId { get; set; }

        public DateTimeOffset DateTimeEvent { get; set; }

        public string PlaceEvent { get; set; }
    }
}
