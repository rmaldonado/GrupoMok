using Domain.Entity.V1;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Infraestructure.Data.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                .HasColumnName("UserId");

            builder.Property(e => e.Email).IsUnicode(false);

            builder.Property(e => e.Password).IsUnicode(false);

            builder.Property(e => e.UserName)
                .HasColumnType("nvarchar(50)")
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.Property(e => e.FirstLastName)
                .HasColumnType("nvarchar(80)")
                .HasMaxLength(80)
                .IsUnicode(false);

            builder.Property(e => e.SecondLastName)
                .HasColumnType("nvarchar(80)")
                .HasMaxLength(80)
                .IsUnicode(false);

            builder.Property(e => e.DocumentNumber)
                .HasColumnType("nvarchar(20)")
                .HasMaxLength(20)
                .IsUnicode(false);

            builder.Property(e => e.PublicKey)
                .HasColumnType("nvarchar(max)");

            builder.Property(e => e.Token)
                .HasColumnType("nvarchar(max)");

            builder.HasOne(u => u.Role)
                .WithMany(r => r.Users)
                .HasForeignKey(u => u.RoleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_User_Role");
        }
    }
}