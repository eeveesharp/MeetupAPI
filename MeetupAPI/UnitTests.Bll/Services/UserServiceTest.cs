using AutoMapper;
using Meetup.BLL.Models;
using Meetup.BLL.Services;
using Meetup.DAL.Entities;
using Meetup.DAL.Interfaces;
using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTests.Bll.Entities;
using UnitTests.Bll.Models;
using Xunit;

namespace UnitTests.Bll.Services
{
    public class UserServiceTest
    {
        private readonly Mock<IUserRepository> _userRepository = new();

        private readonly Mock<IMapper> _mapper = new();

        [Fact]
        public async Task Create_WhenUserHasValidData_ReturnsUserEntity()
        {
            _mapper.Setup(map => map.Map<User>(ValidUserEntity.userEntity)).Returns(ValidUser.user);
            _mapper.Setup(map => map.Map<UserEntity>(ValidUser.user)).Returns(ValidUserEntity.userEntity);
            _userRepository.Setup(s => s.Create(ValidUserEntity.userEntity, default)).ReturnsAsync(ValidUserEntity.userEntity);

            var userService = new UserService(_userRepository.Object, _mapper.Object);

            var result = await userService.Create(ValidUser.user, default);

            ValidUser.user.ShouldBeEquivalentTo(result);
        }

        [Fact]
        public async Task Update_WhenUserHasValidData_ReturnsUserEntity()
        {
            _mapper.Setup(map => map.Map<User>(ValidUserEntity.userEntity)).Returns(ValidUser.user);
            _mapper.Setup(map => map.Map<UserEntity>(ValidUser.user)).Returns(ValidUserEntity.userEntity);
            _userRepository.Setup(s => s.Update(ValidUserEntity.userEntity, default)).ReturnsAsync(ValidUserEntity.userEntity);

            var userService = new UserService(_userRepository.Object, _mapper.Object);

            var result = await userService.Update(ValidUser.user, default);

            ValidUser.user.ShouldBeEquivalentTo(result);
        }
    }
}
