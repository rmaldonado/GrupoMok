using System;

namespace Application.DTO.Request
{
    public class CompanyRequest
    {
        public Int32 CompanyId { get; set; }
        public string CompanyNumber { get; set; }
        public string CompanyName { get; set; }
        public string ContactName { get; set; }
        public string ContactPhone { get; set; }
        public string ContactEmail { get; set; }
        public Boolean IsActive { get; set; }
    }

    public class CompanyQueryRequest
    {
        public Int32? CompanyId { get; set; }
        public string? CompanyNumber { get; set; }
        public string? CompanyName { get; set; }
        public string? ContactName { get; set; }

    }


    public class CompanyRequestCreateDto
    {
        public string CompanyNumber { get; set; }
        public string CompanyName { get; set; }
        public string ContactName { get; set; }
        public string ContactPhone { get; set; }
        public string ContactEmail { get; set; }
    }
    public class CompanyRequestEditDto
    {
        public string CompanyNumber { get; set; }
        public string CompanyName { get; set; }
        public string ContactName { get; set; }
        public string ContactPhone { get; set; }
        public string ContactEmail { get; set; }
    }


}
