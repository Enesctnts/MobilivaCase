using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobilivaCase.Core.Utilities.Results
{
    public class ApiResponse 
    {

        public enum StatusCode { Success = 1, Failed = -1 }
        public StatusCode Status { get; set; }
        public string ResultMessage { get; set; }
        public int ErrorCode { get; set; }
        public object Data { get; set; }
    }
}
