using Pavolle.MessageService.Common.Enums;
using Pavolle.Core.Enums;
using Pavolle.MessageService.ViewModels.Model;
using Pavolle.Core.ViewModels.ViewData;

namespace Pavolle.MessageService.ViewModels.ViewData
{
    public class UserGroupViewData : MessageServiceViewDataBase
    {
        public long OrganizationOid { get; set; }
        public string Name { get; set; }
        public EUserType UserType { get; set; }
    }
}
