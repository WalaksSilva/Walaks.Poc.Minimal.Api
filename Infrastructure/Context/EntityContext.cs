using Microsoft.EntityFrameworkCore;
using Walaks.Poc.Minimal.Api.Domain.Entities;

namespace Walaks.Poc.Minimal.Api.Infrastructure.Context
{
    public class EntityContext : DbContext
    {
        public DbSet<UserEntity> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=teste.sqlite");
            base.OnConfiguring(optionsBuilder);
        }
    }
}
