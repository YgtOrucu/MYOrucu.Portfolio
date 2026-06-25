using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MuhsinYigitOrucu.EntityLayer.Entities;

namespace MuhsinYigitOrucu.DataAccessLayer.Configurations.ProjectConfiguration
{
    public class ProjectDetailsConfig : IEntityTypeConfiguration<ProjectDetail>
    {
        public void Configure(EntityTypeBuilder<ProjectDetail> builder)
        {

            builder.Property(x => x.Title).HasMaxLength(150);
            builder.Property(x => x.ShortDescription).HasMaxLength(250);
            builder.Property(x => x.FullDescription).HasMaxLength(4000);
            builder.Property(x => x.CoverImageUrl).HasMaxLength(500);
            builder.Property(x => x.Category).HasMaxLength(100);
            builder.Property(x => x.Status).HasMaxLength(50);
            builder.Property(x => x.Year).HasMaxLength(20);
            builder.Property(x => x.Duration).HasMaxLength(50);
            builder.Property(x => x.Role).HasMaxLength(100);
            builder.Property(x => x.TeamSize).HasMaxLength(50);
            builder.Property(x => x.GithubLink).HasMaxLength(500);
            builder.Property(x => x.LiveDemoUrl).HasMaxLength(500);
        }
    }
}
