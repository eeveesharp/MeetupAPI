using AutoMapper;
using Meetup.BLL.Models;
using MeetupAPI.ViewModels;

namespace MeetupAPI.Mappers
{
    public class MappingProfileAPI : Profile
    {
        public MappingProfileAPI()
        {
            CreateMap<UserViewModel, User>().ReverseMap();

            CreateMap<EventViewModel, Event>().ReverseMap();

            CreateMap<UserInfoViewModel, User>().ReverseMap();
        }
    }
}
