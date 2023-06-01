using System.Collections.Generic;

namespace Application.DTO
{
    public class BaseRequestDto
    {
       
        public string Algorithm { get; set; }
        public List<DataItem> Items { get; set; }
        public string UserId { get; set; }
        //public string MerchantType { get; set; }
        public bool Status { get; set; }
     
    }
}