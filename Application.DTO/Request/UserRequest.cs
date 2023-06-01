using System;

namespace Application.DTO.Request
{
    public class UserRequestEdit
    {
        public string Name { get; set; }
        public string FirstLastName { get; set; }
        public string? SecondLastName { get; set; }
        public Int16 DocumentType { get; set; }
        public string DocumentNumber { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public int State { get; set; }
        public string? LastIpAddress { get; set; }
        public bool IsExternal { get; set; }
        public int AuditUpdateUser { get; set; }
        public DateTime AuditUpdateDate { get; set; }
        public string PublicKey { get; set; }
    }
    public class UserRequestCreate
    {
        public string? Name { get; set; }
        public string FirstLastName { get; set; }
        public string? SecondLastName { get; set; }
        public Int16 DocumentType { get; set; }
        public string? DocumentNumber { get; set; }
        public string? Password { get; set; }
        public string? Email { get; set; }
        public int State { get; set; }
        public string? LastIpAddress { get; set; }
        public bool IsExternal { get; set; }
        public int AuditCreateUser { get; set; }
        public DateTime AuditCreateDate { get; set; }
        public string? PublicKey { get; set; }

    }
}
