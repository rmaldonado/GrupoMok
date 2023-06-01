using Domain.Entity.V1;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace POS.Infrastructure.Persistences.Contexts.Configurations
{
    public class UsersCompanyConfiguration : IEntityTypeConfiguration<UsersCompany>
    {
        public void Configure(EntityTypeBuilder<UsersCompany> builder)
        {
            builder.HasKey(e => e.UserCompanyId)
                    .HasName("PK_UsersCompany");

            builder.HasOne(d => d.Company)
                .WithMany(p => p.UsersCompanys)
                .HasForeignKey(d => d.CompanyId)
                .HasConstraintName("FK_UsersCompany_Company");

            builder.HasOne(d => d.User)
                .WithMany(p => p.UsersCompanys)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_UsersCompany_Users");
        }
    }
}