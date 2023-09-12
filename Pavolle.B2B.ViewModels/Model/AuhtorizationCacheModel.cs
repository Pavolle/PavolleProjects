using Pavolle.B2B.Common.Enums;
using Pavolle.Core.Enums;

namespace Pavolle.B2B.ViewModels.Model
{
    public class AuhtorizationCacheModel
    {
        public long UserGroupOid { get; set; }
        public EApiServiceMethodType MethodType { get; set; }
        public string ApiKey { get; set; }
        public bool IsAuthority { get; set; }
    }
}
