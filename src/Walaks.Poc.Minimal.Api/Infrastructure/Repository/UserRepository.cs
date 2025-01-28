using Microsoft.EntityFrameworkCore;
using Walaks.Poc.Minimal.Api.Domain.Entities;
using Walaks.Poc.Minimal.Api.Infrastructure.Context;
using Walaks.Poc.Minimal.Api.Infrastructure.Repository.Interfaces;

namespace Walaks.Poc.Minimal.Api.Infrastructure.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly EntityContext _context;
        public UserRepository(EntityContext context) {
            _context = context;
        }

        public async Task<UserEntity> AddAsync(UserEntity user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();

            return user;
        }

        public async Task<IEnumerable<UserEntity>> GetListAsync() => await _context.Users.ToListAsync();

        public async Task<UserEntity?> GetbyIdAsyn(Guid id) => await _context.Users.AsQueryable().FirstOrDefaultAsync(x => x.Id == id);

        public async Task<UserEntity> UpdateAsync(UserEntity user)
        {
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
            return user;
        }
    }
}
