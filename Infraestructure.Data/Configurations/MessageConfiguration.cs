using Domain.Entity.V1;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infraestructure.Data.Configurations
{
    public class MessageConfiguration : IEntityTypeConfiguration<Message>
    {
        public void Configure(EntityTypeBuilder<Message> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                .HasColumnName("MessageId");

            builder.Property(e => e.MessageCode)
                    .HasColumnType("char(3)")
                    .HasMaxLength(3)
                    .IsUnicode(false);

            builder.Property(e => e.MessageEsp)
                    .HasColumnType("nvarchar(150)")
                    .HasMaxLength(150)
                    .IsUnicode(false);

            builder.Property(e => e.MessageEng)
                    .HasColumnType("nvarchar(150)")
                    .HasMaxLength(150)
                    .IsUnicode(false);
        }
    }
}
