using AutoMapper;
using Meetup.BLL.Models;
using Meetup.DAL.Entities;

namespace Meetup.BLL.Mappers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserEntity>().ReverseMap();

            CreateMap<Event, EventEntity>().ReverseMap();
        }
    }
}
