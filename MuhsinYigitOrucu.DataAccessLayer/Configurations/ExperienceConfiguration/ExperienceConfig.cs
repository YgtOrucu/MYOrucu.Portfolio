using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MuhsinYigitOrucu.EntityLayer.Entities;

namespace MuhsinYigitOrucu.DataAccessLayer.Configurations.ExperienceConfiguration
{
    public class ExperienceConfig : IEntityTypeConfiguration<Experience>
    {
        public void Configure(EntityTypeBuilder<Experience> builder)
        {
            builder.Property(x => x.Company).HasColumnType("varchar").HasMaxLength(40);
            builder.Property(x => x.Title).HasColumnType("varchar").HasMaxLength(40);
            builder.Property(x => x.WorkMethod).HasColumnType("varchar").HasMaxLength(40);
            builder.Property(x => x.Date).HasColumnType("varchar").HasMaxLength(60);
        }
    }
}
