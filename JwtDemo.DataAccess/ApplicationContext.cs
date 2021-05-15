using JwtDemo.DataAccess.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace JwtDemo.DataAccess
{
    public class ApplicationContext : IdentityDbContext<User>
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {

        }
        public DbSet<Product> Products { get; set; }
        public DbSet<UserInfo> UserInfos { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<User>()
                .HasOne(u => u.UserInfo)
                .WithOne(t => t.User)
                .HasForeignKey<UserInfo>(a => a.Id);

            base.OnModelCreating(builder);
        }
    }
}
