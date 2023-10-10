using Pavolle.MessageService.Common.Enums;
using Pavolle.MessageService.ViewModels.Model;
using Pavolle.Core.ViewModels.Request;
using Pavolle.Core.Enums;

namespace Pavolle.MessageService.ViewModels.Request
{
    public class ResetPasswordRequest : VerifyCodeRequest
    {
        public string NewPassword { get; set; }
        public string NewPasswordAgain { get; set; }
    }
}
