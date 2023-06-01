using Domain.Entity.V1;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infraestructure.Data.Configuration
{
    public class UserRoleConfiguration : IEntityTypeConfiguration<UserRole>
    {
        public void Configure(EntityTypeBuilder<UserRole> builder)
        {
            builder.HasOne(d => d.Company)
                    .WithMany(p => p.UserRoles)
                    .HasForeignKey(d => d.CompanyId)
                    .HasConstraintName("FK_UserRoles_Company");

            builder.HasOne(d => d.Role)
                .WithMany(p => p.UserRoles)
                .HasForeignKey(d => d.RoleId)
                .HasConstraintName("FK_UserRoles_Role");

            //builder.HasOne(d => d.User)
            //    .WithMany(p => p.Role)
            //    .HasForeignKey(d => d.UserId)
            //    .HasConstraintName("FK_UserRoles_User");
        }
    }
}