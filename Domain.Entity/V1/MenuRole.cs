﻿namespace Domain.Entity.V1
{
    public partial class MenuRole
    {
        public int MenuRolId { get; set; }
        public int? RoleId { get; set; }
        public int? MenuId { get; set; }
        public int? State { get; set; }
        public virtual Menu? Menu { get; set; }
        public virtual Role? Role { get; set; }
    }
}
