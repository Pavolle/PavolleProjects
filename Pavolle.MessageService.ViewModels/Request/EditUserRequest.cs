using Pavolle.MessageService.Common.Enums;
using Pavolle.MessageService.ViewModels.Model;
using Pavolle.Core.ViewModels.Request;
using Pavolle.Core.Enums;

namespace Pavolle.MessageService.ViewModels.Request
{
    public class EditUserRequest : MessageServiceRequestBase
    {
        public long? UserGroupOid { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
    }
}
