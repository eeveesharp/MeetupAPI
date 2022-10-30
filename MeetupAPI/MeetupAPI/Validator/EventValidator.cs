using FluentValidation;
using MeetupAPI.ViewModels;

namespace MeetupAPI.Validator
{
    public class EventValidator : AbstractValidator<EventViewModel>
    {
        public EventValidator()
        {
            RuleFor(e => e.Id).GreaterThan(0);

            RuleFor(e => e.Name).Length(3, 50);

            RuleFor(e => e.Description).Length(3, 50);

            RuleFor(e => e.Plan).Length(10, 100);

            RuleFor(e => e.DateTimeEvent).GreaterThan(DateTimeOffset.Now);

            RuleFor(e => e.OrganizerId).GreaterThan(0);

            RuleFor(e => e.SpeakerId).GreaterThan(0);
        }
    }
}
