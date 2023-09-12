using Pavolle.B2B.Common.Enums;
using Pavolle.Core.Enums;

namespace Pavolle.B2B.ViewModels.Model
{
    public class UserSessionCacheModel
    {
        public string SessionId { get; set; }
        public string RequestIp { get; set; }
        public string Token { get; set; }
        public DateTime LastOperationTime { get; set; }
        public string Username { get; set; }
    }
}
