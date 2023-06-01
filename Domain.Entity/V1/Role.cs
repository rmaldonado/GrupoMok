using Domain.Entity.Bases;
using System.Collections.Generic;

namespace Domain.Entity.V1
{
    public partial class Role : BaseEntity
    {
        public Role()
        {
            MenuRoles = new HashSet<MenuRole>();
            UserRoles = new HashSet<UserRole>();
        }

        public string? NameRole { get; set; }
        public string? Description { get; set; }

        public virtual ICollection<User> Users { get; set; }
        public virtual ICollection<MenuRole> MenuRoles { get; set; }
        public virtual ICollection<UserRole> UserRoles { get; set; }
    }
}
