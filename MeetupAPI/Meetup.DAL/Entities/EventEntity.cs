namespace Meetup.DAL.Entities
{
    public class EventEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Plan { get; set; }

        public int Organizer { get; set; }

        public UserEntity User_Organizer { get; set; }

        public int Speaker { get; set; }

        public UserEntity User_Speaker { get; set; }

        public DateTime DateTimeEvent { get; set; }

        public string PlaceEvent { get; set; }
    }
}
