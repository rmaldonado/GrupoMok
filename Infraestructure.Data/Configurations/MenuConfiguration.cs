using Domain.Entity.V1;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infraestructure.Data.Configuration
{
    public class MenuConfiguration : IEntityTypeConfiguration<Menu>
    {
        public void Configure(EntityTypeBuilder<Menu> builder)
        {

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                .HasColumnName("MenuId");

            builder.HasMany(e => e.Children)
                .WithOne(e => e.ParentItem)
                .HasForeignKey(e => e.ParentId)
                .HasConstraintName("FK_Menu_ParentItem");

            builder.Property(e => e.Icon)
                    .HasMaxLength(50)
                    .IsUnicode(false);

            builder.Property(e => e.Name)
                .HasColumnType("nvarchar(100)")
                .HasMaxLength(150)
                .IsUnicode(false);

            builder.Property(e => e.Url)
                .HasColumnType("nvarchar(150)")
                .HasMaxLength(150)
                .IsUnicode(false);


            builder.Property(e => e.Url)
                .HasMaxLength(150)
                .IsUnicode(false);

        }
    }
}