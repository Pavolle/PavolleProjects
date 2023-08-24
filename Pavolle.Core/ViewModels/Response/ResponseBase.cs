using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.Core.ViewModels.Response
{
    public class ResponseBase
    {
        public bool Success { get; set; }=true;
        public string ErrorMessage { get; set; }
        public string SuccessMessage { get; set; }
        public string InfoMessage { get; set; }
        public string WarningMessage { get; set; }
    }
}
