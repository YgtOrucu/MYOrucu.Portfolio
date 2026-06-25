using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MuhsinYigitOrucu.EntityLayer.Entities;

namespace MuhsinYigitOrucu.DataAccessLayer.Context
{
    public class MYOrucuPortfolioContext : IdentityDbContext<AppUser, IdentityRole, string>
    {
        public MYOrucuPortfolioContext(DbContextOptions<MYOrucuPortfolioContext> options) : base(options) { }

        public DbSet<About> Abouts { get; set; }
        public DbSet<Experience> Experience { get; set; }
        public DbSet<Skills> Skills { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<ProjectDetail> ProjectDetail { get; set; }
        public DbSet<Message> Messages { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(typeof(MYOrucuPortfolioContext).Assembly);
        }
    }
}
