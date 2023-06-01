using System;

namespace Application.DTO.Response
{
    public class UserResponseDto {

        public int UserId { get; set; }
        public string? Name { get; set; }
        public string? LastName { get; set; }
        public string? UserName { get; set; }
        public string? Email { get; set; }
        public Int16 DocumentType { get; set; }
        public string? DocumentNumber { get; set; }
        public bool RequireReLogin { get; set; }
        public bool IsSystemAccount { get; set; }
        public int State { get; set; }
        public string? StateUser { get; set; }
    }
}
