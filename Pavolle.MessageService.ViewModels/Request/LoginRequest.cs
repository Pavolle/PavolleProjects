using Pavolle.MessageService.Common.Enums;
using Pavolle.MessageService.ViewModels.Model;
using Pavolle.Core.ViewModels.Request;
using Pavolle.Core.Enums;

namespace Pavolle.MessageService.ViewModels.Request
{
    public class LoginRequest : RequestBase
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
