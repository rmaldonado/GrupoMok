using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTO.Response {
    public class MenuResponseDto {
        public int MenuId { get; set; }
        public string? Name { get; set; }
        public string? Icon { get; set; }
        public string? Url { get; set; }
        public int? FatherId { get; set; }
        public int? State { get; set; }
    }
}
