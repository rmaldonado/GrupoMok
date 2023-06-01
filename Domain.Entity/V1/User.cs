using Domain.Entity.Bases;
using System;
using System.Collections.Generic;

namespace Domain.Entity.V1
{
    public partial class User : BaseEntity
    {
        public User()
        {
            UsersCompanys = new HashSet<UsersCompany>();
        }
        public string Name { get; set; }
        public string FirstLastName { get; set; }
        public string? SecondLastName { get; set; }
        public short DocumentType { get; set; }
        public string DocumentNumber { get; set; }
        public string? UserName { get; set; }
        public string? Password { get; set; }
        public string? Email { get; set; }
        public bool RequireReLogin { get; set; }
        public int FailedLoginAttempts { get; set; }
        public bool IsSystemAccount { get; set; }
        public string? LastIpAddress { get; set; }
        public DateTime LastLoginDate { get; set; }
        public string PublicKey { get; set; }
        public int RoleId { get; set; }
        public string? Token { get; set; }
        public bool IsExternal { get; set; }
        public virtual Role Role { get; set; } = null!;

        public virtual ICollection<UsersCompany> UsersCompanys { get; set; }
    }
}