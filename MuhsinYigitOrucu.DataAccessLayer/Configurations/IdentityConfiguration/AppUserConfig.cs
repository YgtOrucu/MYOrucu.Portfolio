using MuhsinYigitOrucu.EntityLayer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MuhsinYigitOrucu.DataAccessLayer.Configurations.IdentityConfiguration
{
    public class AppUserConfig : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            builder.Property(x => x.NameSurname).HasColumnType("varchar").HasMaxLength(50);           
            builder.Property(x => x.UserName).HasColumnType("varchar").HasMaxLength(30);
            builder.Property(x => x.NormalizedUserName).HasColumnType("varchar").HasMaxLength(30);
            builder.Property(x => x.Email).HasColumnType("varchar").HasMaxLength(30);
            builder.Property(x => x.NormalizedEmail).HasColumnType("varchar").HasMaxLength(30);
            builder.Property(x => x.PhoneNumber).HasColumnType("varchar").HasMaxLength(15);
        }
    }
}
