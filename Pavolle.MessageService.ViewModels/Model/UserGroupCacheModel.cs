using Pavolle.MessageService.Common.Enums;
using Pavolle.Core.Enums;

namespace Pavolle.MessageService.ViewModels.Model
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
