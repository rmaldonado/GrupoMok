using Domain.Entity.Bases;
using System.Collections.Generic;

namespace Domain.Entity.V1
{
    public class Company : BaseEntity
    {
        public Company()
        {
            UserRoles = new HashSet<UserRole>();
            UsersCompanys = new HashSet<UsersCompany>();

        }
        public string? CompanyNumber { get; set; }
        public string? CompanyName { get; set; }
        public string? ContactName { get; set; }
        public string? ContactPhone { get; set; }
        public string? ContactEmail { get; set; }

        public virtual ICollection<UserRole> UserRoles { get; set; }
        public virtual ICollection<UsersCompany> UsersCompanys { get; set; }

    }
}
