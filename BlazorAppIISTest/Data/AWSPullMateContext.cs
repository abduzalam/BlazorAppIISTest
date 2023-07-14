using BlazorAppIISTest.Model;
using Microsoft.EntityFrameworkCore;

namespace BlazorAppIISTest.Data
{
    public class AWSPullMateContext : DbContext
    {
        public AWSPullMateContext(DbContextOptions<AWSPullMateContext> options)
        : base(options)
        {
        }

        public DbSet<User> User { get; set; } = default!;
        // public DbSet<UserRoles> UserRoles { get; set; } = default!;


    }
}
