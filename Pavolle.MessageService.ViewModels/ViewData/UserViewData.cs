using Pavolle.MessageService.Common.Enums;
using Pavolle.Core.Enums;
using Pavolle.MessageService.ViewModels.Model;
using Pavolle.Core.ViewModels.ViewData;

namespace Pavolle.MessageService.ViewModels.ViewData
{
    public class UserViewData : MessageServiceViewDataBase
    {
        public long? OrganizationOid { get; set; }
        public string OrganizationName { get; set; }
        public long UserGroupOid { get; set; }
        public string UserGroupName { get; set; }
        public string Username { get; set; }
        public EUserType UserType { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
    }
}
