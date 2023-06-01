using System;

namespace Application.DTO.Response
{
    public class CompanyResponseDto
    {
        public Int32 CompanyId { get; set; }
        public string CompanyNumber { get; set; }
        public string CompanyName { get; set; }
        public string ContactName { get; set; }
        public string ContactPhone { get; set; }
        public string ContactEmail { get; set; }
        public int State { get; set; }
    }
}
