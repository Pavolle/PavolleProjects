using Pavolle.B2B.Common.Enums;
using Pavolle.Core.Enums;
using Pavolle.B2B.ViewModels.Model;
using Pavolle.Core.ViewModels.ViewData;

namespace Pavolle.B2B.ViewModels.ViewData
{
    public class UserViewData : B2BViewDataBase
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
