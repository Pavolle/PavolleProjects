using Pavolle.B2B.Common.Enums;
using Pavolle.B2B.ViewModels.Model;
using Pavolle.Core.ViewModels.Request;
using Pavolle.Core.Enums;

namespace Pavolle.B2B.ViewModels.Request
{
    public class AddUserGroupRequest : B2BRequestBase
    {
        public long? OrganizationOid { get; set; }
        public string Name { get; set; }
        public EUserType? UserType { get; set; }
    }
}
