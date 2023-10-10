using Pavolle.MessageService.Common.Enums;
using Pavolle.MessageService.ViewModels.Model;
using Pavolle.Core.ViewModels.Request;
using Pavolle.Core.Enums;

namespace Pavolle.MessageService.ViewModels.Request
{
    public class AddUserGroupRequest : MessageServiceRequestBase
    {
        public long? OrganizationOid { get; set; }
        public string Name { get; set; }
        public EUserType? UserType { get; set; }
    }
}
