using Domain.Entity.V1;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Infraestructure.Data.Contexts
{
    public partial class ProdContext : DbContext
    {
        public ProdContext()
        { }

        public ProdContext(DbContextOptions<ProdContext> options) : base(options)
        {
            //Database.EnsureCreated();
            GrupoMokDbInitializer.Initialize(this);
        }

        public virtual DbSet<Company> Companys { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;
        public virtual DbSet<Menu> Menus { get; set; } = null!;
        public virtual DbSet<Role> Roles { get; set; } = null!;
        public virtual DbSet<Permission> Permissions { get; set; } = null!;
        public virtual DbSet<MenuRole> MenuRoles { get; set; } = null!;
        public virtual DbSet<UserRole> UserRoles { get; set; } = null!;
        public virtual DbSet<UsersCompany> UsersCompanys { get; set; } = null!;


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            OnModelCreatingPartial(modelBuilder);
        
            //new DbInitializer(modelBuilder).Seed();
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
