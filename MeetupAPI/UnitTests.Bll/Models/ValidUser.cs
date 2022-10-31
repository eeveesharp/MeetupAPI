using Meetup.BLL.Models;

namespace UnitTests.Bll.Models
{
    public class ValidUser
    {
        public static User user = new()
        {
            Id = 1,

            FirstName = "Ivan",

            LastName = "Ivanov",

            Email = "qwerty@gmail.com",

            Password = "12345678"
        };
    }
}
