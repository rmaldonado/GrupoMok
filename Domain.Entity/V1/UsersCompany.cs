namespace Domain.Entity.V1
{
    public class UsersCompany
    {
        public int UserCompanyId { get; set; }
        public int? CompanyId { get; set; }
        public int? UserId { get; set; }
        public int? State { get; set; }

        public virtual Company? Company { get; set; }
        public virtual User? User { get; set; }
    }
}
