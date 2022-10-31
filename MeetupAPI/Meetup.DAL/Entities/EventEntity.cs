namespace Meetup.DAL.Entities
{
    public class EventEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Plan { get; set; }

        public OrganizerEntity Organizer { get; set; }

        public SpeakerEntity Speaker { get; set; }

        public DateTimeOffset DateTimeEvent { get; set; }

        public string PlaceEvent { get; set; }
    }
}
