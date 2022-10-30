using AutoMapper;
using Meetup.BLL.Interfaces;
using Meetup.BLL.Models;
using Meetup.DAL.Entities;
using Meetup.DAL.Interfaces;

namespace Meetup.BLL.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        private readonly IMapper _mapper;

        public UserService(IUserRepository eventRepository,
            IMapper mapper)
        {
            _userRepository = eventRepository;
            _mapper = mapper;
        }

        public async Task<User> Create(User item, CancellationToken ct)
        {
            return _mapper.Map<UserEntity, User>(await _userRepository.Create(_mapper.Map<User, UserEntity>(item), ct));
        }

        public async Task DeleteById(int id, CancellationToken ct)
        {
            await _userRepository.DeleteById(id, ct);
        }

        public async Task<IEnumerable<User>> GetAll(CancellationToken ct)
        {
            return _mapper.Map<IEnumerable<User>>(await _userRepository.GetAll(ct));
        }

        public async Task<User> GetById(int id, CancellationToken ct)
        {
            return _mapper.Map<UserEntity, User>(await _userRepository.GetById(id, ct));
        }

        public async Task<User> GetUser(string email, string password, CancellationToken ct)
        {
            return _mapper.Map<UserEntity, User>(await _userRepository.GetUser(email,password, ct));
        }

        public async Task<User> Update(User item, CancellationToken ct)
        {
            return _mapper.Map<UserEntity, User>(await _userRepository.Update(_mapper.Map<User, UserEntity>(item), ct));
        }
    }
}
