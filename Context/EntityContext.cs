using Microsoft.EntityFrameworkCore;
using Walaks.Poc.Minimal.Api.Models;

namespace Walaks.Poc.Minimal.Api.Context
{
    public class EntityContext : DbContext
    {
        public DbSet<UserModel> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=teste.sqlite");
            base.OnConfiguring(optionsBuilder);
        }
    }
}
