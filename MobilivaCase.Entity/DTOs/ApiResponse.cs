using MobilivaCase.Entity.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobilivaCase.Entity.DTOs
{
    public class ApiResponseDto<TData>
    {
        public Status Status { get; set; }
        public string ResultMessage { get; set; }
        public string ErrorCode { get; set; }
        public List<TData> Data { get; set; }
    }

}
