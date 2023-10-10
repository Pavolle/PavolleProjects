using Pavolle.MessageService.Common.Enums;
using Pavolle.MessageService.ViewModels.Model;
using Pavolle.Core.ViewModels.Request;
using Pavolle.Core.Enums;

namespace Pavolle.MessageService.ViewModels.Request
{
    public class ForgotPasswordRequest : RequestBase
    {
        public string Username { get; set; }
        public ECommunicationType? CommunicationType { get; set; }
        public string CommunicationValue { get; set; }
    }
}
