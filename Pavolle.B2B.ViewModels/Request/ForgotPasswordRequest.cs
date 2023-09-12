using Pavolle.B2B.Common.Enums;
using Pavolle.B2B.ViewModels.Model;
using Pavolle.Core.ViewModels.Request;
using Pavolle.Core.Enums;

namespace Pavolle.B2B.ViewModels.Request
{
    public class ForgotPasswordRequest : RequestBase
    {
        public string Username { get; set; }
        public ECommunicationType? CommunicationType { get; set; }
        public string CommunicationValue { get; set; }
    }
}
