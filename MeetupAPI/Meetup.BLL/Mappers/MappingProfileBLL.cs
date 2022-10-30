using AutoMapper;
using Meetup.BLL.Models;
using Meetup.DAL.Entities;

namespace Meetup.BLL.Mappers
{
    public class MappingProfileBLL : Profile
    {
        public MappingProfileBLL()
        {
            CreateMap<User, UserEntity>().ReverseMap();

            CreateMap<Event, EventEntity>().ReverseMap();
        }
    }
}
