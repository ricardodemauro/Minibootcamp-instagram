using DotnetCamp.Instagram.Domain.Entities;
using DotnetCamp.Instagram.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DotnetCamp.Instagram.Repository.Database
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Picture>()
                .Property(p => p.Description)
                .HasMaxLength(200)
                .IsRequired(false);

            builder.Entity<Picture>()
                .Property(p => p.PicIdentity)
                .HasColumnName("FilePath")
                .HasMaxLength(50)
                .IsRequired(true);

            builder.Entity<Picture>()
                .HasKey(p => p.Id);


            base.OnModelCreating(builder);
        }

        public DbSet<Picture> Picture { get; set; }
    }
}
