using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MuhsinYigitOrucu.EntityLayer.Entities;

namespace MuhsinYigitOrucu.DataAccessLayer.Configurations.SkillsConfiguration
{
    public class SkillsConfig : IEntityTypeConfiguration<Skills>
    {
        public void Configure(EntityTypeBuilder<Skills> builder)
        {
            builder.Property(x => x.CategoryName).HasColumnType("varchar").HasMaxLength(50);
        }
    }
}
