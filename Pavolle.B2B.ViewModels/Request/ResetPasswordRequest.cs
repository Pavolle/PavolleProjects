using Pavolle.B2B.Common.Enums;
using Pavolle.B2B.ViewModels.Model;
using Pavolle.Core.ViewModels.Request;
using Pavolle.Core.Enums;

namespace Pavolle.B2B.ViewModels.Request
{
    public class ResetPasswordRequest : VerifyCodeRequest
    {
        public string NewPassword { get; set; }
        public string NewPasswordAgain { get; set; }
    }
}
