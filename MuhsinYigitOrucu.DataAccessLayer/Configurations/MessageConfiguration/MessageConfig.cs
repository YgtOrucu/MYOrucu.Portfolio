using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MuhsinYigitOrucu.EntityLayer.Entities;

namespace MuhsinYigitOrucu.DataAccessLayer.Configurations.MessageConfiguration
{
    public class MessageConfig : IEntityTypeConfiguration<Message>
    {
        public void Configure(EntityTypeBuilder<Message> builder)
        {
            builder.Property(x => x.Subject).HasColumnType("varchar").HasMaxLength(50);
            builder.Property(x => x.Description).HasColumnType("varchar").HasMaxLength(800);
            builder.Property(x => x.NameSurname).HasColumnType("varchar").HasMaxLength(60);
            builder.Property(x => x.Email).HasColumnType("varchar").HasMaxLength(25);
            builder.Property(x => x.IsRead).HasColumnType("varchar").HasMaxLength(10);
        }
    }
}
