using Pavolle.B2B.Common.Enums;
using Pavolle.Core.Enums;
using Pavolle.B2B.ViewModels.Model;
using Pavolle.Core.ViewModels.ViewData;

namespace Pavolle.B2B.ViewModels.ViewData
{
    public class UserGroupViewData : B2BViewDataBase
    {
        public long OrganizationOid { get; set; }
        public string Name { get; set; }
        public EUserType UserType { get; set; }
    }
}
