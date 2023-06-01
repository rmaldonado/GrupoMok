
using Domain.Entity.V1;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure.Data.Contexts
{
    public class GrupoMokDBContext : DbContext
    {
        public GrupoMokDBContext(DbContextOptions<ProdContext> options)
            : base(options)
        {
            Database.EnsureCreated();
           // AgunsaDBInitializer.Initialize(this);
        }   


        public virtual DbSet<Company> Companys { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;
        public virtual DbSet<Menu> Menus { get; set; } = null!;
        public virtual DbSet<Role> Roles { get; set; } = null!;
        public virtual DbSet<Permission> Permissions { get; set; } = null!;
        public virtual DbSet<MenuRole> MenuRoles { get; set; } = null!;
        public virtual DbSet<UserRole> UserRoles { get; set; } = null!;
        public virtual DbSet<UsersCompany> UsersCompanys { get; set; } = null!;
    }
}
