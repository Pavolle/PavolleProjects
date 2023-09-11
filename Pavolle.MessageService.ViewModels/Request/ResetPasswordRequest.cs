using Pavolle.Core.ViewModels.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.MessageService.ViewModels.Request
{
    public class ResetPasswordRequest:VerifyCodeRequest
    {
        public string NewPassword { get; set; }
        public string NewPasswordAgain { get; set; }
    }
}
