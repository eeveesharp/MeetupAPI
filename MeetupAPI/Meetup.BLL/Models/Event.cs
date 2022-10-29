namespace Meetup.BLL.Models
{
    public class Event
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Plan { get; set; }

        public int Organizer { get; set; }

        public int Speaker { get; set; }

        public DateTime DateTimeEvent { get; set; }

        public string PlaceEvent { get; set; }
    }
}
