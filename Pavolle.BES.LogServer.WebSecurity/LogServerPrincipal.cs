using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.BES.LogServer.WebSecurity
{
    public class LogServerPrincipal : IPrincipal
    {
        public IIdentity Identity { get; private set; }
        public string Ip { get; set; }

        public LogServerPrincipal(LogServerIdentity identity, string ip)
        {
            this.Ip = ip;
        }

        public bool IsInRole(string role)
        {
            return false;
        }
    }
}
