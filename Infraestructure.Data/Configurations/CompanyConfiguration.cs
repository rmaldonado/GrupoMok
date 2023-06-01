using Domain.Entity.V1;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infraestructure.Data.Configuration
{
    public class CompanyConfiguration : IEntityTypeConfiguration<Company>
    {

        public void Configure(EntityTypeBuilder<Company> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                .HasColumnName("CompanyId");

            builder.Property(e => e.CompanyNumber)
                   .HasColumnType("nvarchar(150)");

            builder.Property(e => e.CompanyName)
                   .HasColumnType("nvarchar(250)");

            builder.Property(e => e.ContactName)
                   .HasColumnType("nvarchar(200)");

            builder.Property(e => e.ContactPhone)
                   .HasColumnType("nvarchar(15)");

            builder.Property(e => e.ContactEmail)
                   .HasColumnType("nvarchar(100)");
        }
    }
}