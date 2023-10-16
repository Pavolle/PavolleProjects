using Pavolle.MessageService.Common.Enums;
using Pavolle.Core.Enums;

namespace Pavolle.MessageService.ViewModels.Model
{
    public class AuhtorizationCacheModel
    {
        public long Oid { get; set; }
        public long UserGroupOid { get; set; }
        public EApiServiceMethodType MethodType { get; set; }
        public string ApiKey { get; set; }
        public bool IsAuthority { get; set; }
        public bool Anonymous { get; set; }
        public string UserGroupName { get; set; }
        public long ApiServiceOid { get; set; }
    }
}
