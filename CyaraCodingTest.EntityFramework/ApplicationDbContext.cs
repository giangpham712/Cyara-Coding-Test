using CyaraCodingTest.Core.Domain;
using CyaraCodingTest.Core.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CyaraCodingTest.EntityFramework
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<ApiToken>()
                .HasKey(x => x.Token);

            base.OnModelCreating(builder);
        }
    }
}
