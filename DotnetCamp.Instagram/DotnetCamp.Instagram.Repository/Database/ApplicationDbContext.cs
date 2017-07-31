using DotnetCamp.Instagram.Identity;
using DotnetCamp.Instagram.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                .HasKey(p => p.Id);


            base.OnModelCreating(builder);
        }

        public DbSet<Picture> Picture { get; set; }
    }
}
