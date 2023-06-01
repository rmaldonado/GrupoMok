namespace Domain.Entity.V1
{
    public partial class UserRole
    {
        public int UserRoleId { get; set; }
        public int? RoleId { get; set; }
        public int? UserId { get; set; }
        public int? State { get; set; }
        public int? CompanyId { get; set; }

        public virtual Company? Company { get; set; }
        public virtual Role? Role { get; set; }
        public virtual User? User { get; set; }
    }
}
