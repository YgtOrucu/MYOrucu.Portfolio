using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MuhsinYigitOrucu.EntityLayer.Entities;

namespace MuhsinYigitOrucu.DataAccessLayer.Configurations.AboutConfiguration
{
    public class AboutConfig : IEntityTypeConfiguration<About>
    {
        public void Configure(EntityTypeBuilder<About> builder)
        {
            builder.Property(x => x.FullName).HasColumnType("varchar").HasMaxLength(80);
            builder.Property(x => x.BrandInitials).HasColumnType("varchar").HasMaxLength(20);
            builder.Property(x => x.ShortBio).HasColumnType("varchar").HasMaxLength(300);
            builder.Property(x => x.AvatarUrl).HasColumnType("varchar").HasMaxLength(500);
            builder.Property(x => x.Location).HasColumnType("varchar").HasMaxLength(100);
            builder.Property(x => x.EmailAddress).HasColumnType("varchar").HasMaxLength(100);
            builder.Property(x => x.PhoneNumber).HasColumnType("varchar").HasMaxLength(20);
            builder.Property(x => x.GithubUrl).HasColumnType("varchar").HasMaxLength(200);
            builder.Property(x => x.LinkedinUrl).HasColumnType("varchar").HasMaxLength(200);
        }
    }
}
