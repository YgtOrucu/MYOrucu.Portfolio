using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MuhsinYigitOrucu.EntityLayer.Entities;

namespace MuhsinYigitOrucu.DataAccessLayer.Configurations.ProjectConfiguration
{
    public class ProjectConfig : IEntityTypeConfiguration<Project>
    {
        public void Configure(EntityTypeBuilder<Project> builder)
        {
            builder.Property(x => x.Title).HasColumnType("varchar").HasMaxLength(40);
            builder.Property(x => x.MiniDescription).HasColumnType("varchar").HasMaxLength(400);
            builder.Property(x => x.ImageUrl).HasColumnType("varchar").HasMaxLength(500);
            builder.Property(x => x.GithubLink).HasColumnType("varchar").HasMaxLength(50);
        }
    }
}
