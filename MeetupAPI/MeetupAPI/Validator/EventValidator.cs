using FluentValidation;
using MeetupAPI.ViewModels;

namespace MeetupAPI.Validator
{
    public class EventValidator : AbstractValidator<EventViewModel>
    {
        public EventValidator()
        {
            RuleFor(e => e.Name).Length(3, 50).NotNull();

            RuleFor(e => e.Description).Length(3, 50).NotNull();

            RuleFor(e => e.Plan).Length(10, 100).NotNull();

            RuleFor(e => e.DateTimeEvent).GreaterThan(DateTimeOffset.Now).NotNull();

            RuleFor(e => e.OrganizerId).GreaterThan(0).NotNull();

            RuleFor(e => e.SpeakerId).GreaterThan(0).NotNull();
        }
    }
}
