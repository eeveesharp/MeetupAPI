using AutoMapper;
using Meetup.BLL.Models;
using MeetupAPI.ViewModels;

namespace MeetupAPI.Mappers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<UserViewModel, User>().ReverseMap();

            CreateMap<EventViewModel, Event>().ReverseMap();
        }
    }
}
