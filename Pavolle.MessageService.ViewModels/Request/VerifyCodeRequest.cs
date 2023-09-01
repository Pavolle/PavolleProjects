using Pavolle.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.MessageService.ViewModels.Request
{
    public class VerifyCodeRequest
    {
        public string Username { get; set; }
        public string Code { get; set; }
    }
}
