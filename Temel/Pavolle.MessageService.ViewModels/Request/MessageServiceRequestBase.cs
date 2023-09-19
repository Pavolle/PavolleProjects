using Pavolle.Core.ViewModels.Request;
using Pavolle.MessageService.Common.Enums;

namespace Pavolle.MessageService.ViewModels.Request
{
    public class MessageServiceRequestBase:RequestBase
    {

        public string? Username { get; set; }

        public EUserType? UserType { get; set; }

        public long? UserGroupOid { get; set; }

        public string? SessionId { get; set; }

    }
}
