using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.MessageService.ViewModels.Model
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
