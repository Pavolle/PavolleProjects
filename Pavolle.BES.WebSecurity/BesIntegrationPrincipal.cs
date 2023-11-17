using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.BES.WebSecurity
{
    public class BesIntegrationPrincipal : IPrincipal
    {
        public IIdentity Identity { get; private set; }
        public string Ip { get; private set; }
        public string AppCode { get; private set; }
        public string AppId { get; private set; }

        public BesIntegrationPrincipal(BesIdentity identity, string ip, string appCode, string appId)
        {
            this.Ip = ip;
            this.AppCode = appCode;
            this.AppId = appId;
        }

        public bool IsInRole(string role)
        {
            return false;
        }
    }
}
