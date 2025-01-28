using Microsoft.EntityFrameworkCore;
using Walaks.Poc.Minimal.Api.Domain.Entities;

namespace Walaks.Poc.Minimal.Api.Infrastructure.Repository.Interfaces
{
    public interface IUserRepository
    {
        Task<UserEntity> AddAsync(UserEntity user);
        Task<IEnumerable<UserEntity>> GetListAsync();
        Task<UserEntity?> GetbyIdAsyn(Guid id);
        Task<UserEntity> UpdateAsync(UserEntity user);
    }
}
