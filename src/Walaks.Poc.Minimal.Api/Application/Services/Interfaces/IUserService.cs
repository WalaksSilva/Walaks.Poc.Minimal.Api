using Walaks.Poc.Minimal.Api.Application.ViewModels;
using Walaks.Poc.Minimal.Api.Domain.Entities;

namespace Walaks.Poc.Minimal.Api.Application.Services.Interfaces
{
    public interface IUserService
    {
        Task<UserEntity> AddAsync(UserRequestViewModel req);
        Task<IEnumerable<UserEntity>> GetListAsync();
        Task<UserEntity?> GetbyIdAsync(Guid id);
        Task<UserEntity> UpdateAsync(UserEntity user);
    }
}
