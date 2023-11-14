using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.BES.LogServer.ViewModels.Request
{
    public class LogRequest
    {
        public string AppId { get; set; }
        public string ServerRequestIp { get; set; }
        public string RequestIp { get; set; }
        public string Username { get; set; }
        public string OrganizationOid { get; set; }
        public string LogLevel { get; set; }
        public string LogContent { get; set; }
        public bool SystemLog { get; set; }
        public bool UserOperationLog { get; set; }
        public DateTime SendToLogServerTime { get; set; }
    }
}
