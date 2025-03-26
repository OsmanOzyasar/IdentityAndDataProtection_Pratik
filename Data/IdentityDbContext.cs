using IdentityAndDataProtection_Pratik.Entities;
using Microsoft.EntityFrameworkCore;

namespace IdentityAndDataProtection_Pratik.Data
{
    public class IdentityDbContext : DbContext
    {
        public IdentityDbContext(DbContextOptions<IdentityDbContext> options) : base(options)
        {
        }

        public DbSet<UserEntity> Users { get; set; }
    }
}
