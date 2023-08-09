using Pavolle.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.Core.ViewModels.Request
{
    public class RequestBase:IRequest
    {
        public ELanguage? Language { get; set; }
        public string RequestIp { get; set; }
    }
}
