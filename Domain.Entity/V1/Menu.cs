using Domain.Entity.Bases;
using System.Collections.Generic;

namespace Domain.Entity.V1
{
    public partial class Menu : BaseEntity
    {
        public Menu()
        {
            Children = new HashSet<Menu>();
            MenuRoles = new HashSet<MenuRole>();
        }

        public string? Name { get; set; }
        public string? Icon { get; set; }
        public string? Url { get; set; }
        public int? ParentId { get; set; }
        public virtual ICollection<Menu> Children { get; set; }
        public virtual Menu ParentItem { get; set; }
        public virtual ICollection<MenuRole> MenuRoles { get; set; }
    }
}
