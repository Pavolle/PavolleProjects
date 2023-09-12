using Pavolle.B2B.Common.Enums;
using Pavolle.B2B.ViewModels.Model;
using Pavolle.Core.ViewModels.Request;
using Pavolle.Core.Enums;

namespace Pavolle.B2B.ViewModels.Request
{
    public class EditUserGroupRequest : B2BRequestBase
    {
        public string Name { get; set; }
        public EUserType? UserType { get; set; }
        public List<UserGroupAuthRequestModel> Auhtorizations { get; set; }
    }
}
