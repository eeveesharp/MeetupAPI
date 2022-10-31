using FluentValidation;
using MeetupAPI.ViewModels;

namespace MeetupAPI.Validator
{
    public class UserValidator : AbstractValidator<UserViewModel>
    {
        public UserValidator()
        {
            RuleFor(u => u.FirstName).Length(2, 20).Must(u => u.All(Char.IsLetter)).NotNull();

            RuleFor(u => u.LastName).Length(2, 50).Must(u => u.All(Char.IsLetter)).NotNull();

            RuleFor(u => u.Email).Length(6, 50).NotNull();
        }
    }
}
