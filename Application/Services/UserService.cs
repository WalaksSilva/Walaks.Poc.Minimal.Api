using Walaks.Poc.Minimal.Api.Application.Services.Interfaces;
using Walaks.Poc.Minimal.Api.Application.ViewModels;
using Walaks.Poc.Minimal.Api.Domain.Entities;
using Walaks.Poc.Minimal.Api.Infrastructure.Repository.Interfaces;

namespace Walaks.Poc.Minimal.Api.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<UserEntity> AddAsync(UserRequestViewModel req)
        {
            var userModel = new UserEntity(req.Nome);
            await _userRepository.AddAsync(userModel);
            return userModel;
        }

        public async Task<IEnumerable<UserEntity>> GetListAsync() => await _userRepository.GetListAsync();

        public async Task<UserEntity?> GetbyIdAsync(Guid id) => await _userRepository.GetbyIdAsyn(id);

        public async Task<UserEntity> UpdateAsync(UserEntity user)
        { 
            await _userRepository.UpdateAsync(user);
            return user;
        }
    }
}
