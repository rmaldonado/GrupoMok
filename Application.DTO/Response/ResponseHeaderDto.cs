using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTO.Response
{
    public class ResponseHeaderDto
    {
        //public string tranxIniDate { get; set; }
        //public string tranxEndDate { get; set; }
        //public string requestSignature { get; set; }
        //public long millis { get; set; }
        public string TransactionStartDatetime { get; set; }
        public string TransactionEndDatetime { get; set; }
        public string Millis { get; set; }
    }
}
