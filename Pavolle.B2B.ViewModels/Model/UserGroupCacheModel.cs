using Pavolle.B2B.Common.Enums;
using Pavolle.Core.Enums;

namespace Pavolle.B2B.ViewModels.Model
{
    public class UserGroupCacheModel
    {
        public long Oid { get; set; }
        public string Name { get; set; }
        public EUserType UserType { get; set; }
        public long? OrganizationOid { get; set; }
        public string OrganizationName { get; set; }
    }
}
