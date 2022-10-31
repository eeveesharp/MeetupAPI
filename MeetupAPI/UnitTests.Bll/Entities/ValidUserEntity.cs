using Meetup.DAL.Entities;

namespace UnitTests.Bll.Entities
{
    public class ValidUserEntity
    {
        public static UserEntity userEntity = new()
        {
            Id = 1,

            FirstName = "Ivan",

            LastName = "Ivanov",

            Email = "qwerty@gmail.com",

            Password = "12345678"
        };
    }
}
