using Pavolle.B2B.Common.Enums;
using Pavolle.Core.ViewModels.Request

namespace Pavolle.B2B.ViewModels.Request
{
    public class B2BRequestBase : RequestBase
    {
        public string? Username { get; set; }
        public EUserType? UserType { get; set; }
        public long? UserGroupOid { get; set; }
        public string? SessionId { get; set; }
    }
}
