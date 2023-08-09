using Pavolle.Core.Enums;
using Pavolle.MessageService.Common.Enums;
using System;
using System.Collections.Generic;
using System.Security.Principal;

namespace Pavolle.MessageService.WebSecurity
{
    public class CustomPrincipal : IPrincipal
    {
        public CustomPrincipal(CustomIdentity identity,  string sessionId, long? kurumOid, EUserType? kullaniciTipi, ELanguage? dil, string requestIp)
        {
            if (identity == null)
            {
                //TODO Log indentity error
            }

            this.Identity = identity;
            this.SessionId = sessionId;
            this.KurumOid = kurumOid;
            this.KullaniciTipi = kullaniciTipi;
            this.Dil = dil;
            this.RequestIp = requestIp;
        }

        public IIdentity Identity { get; private set; }
        public string SessionId { get; set; }
        public long? KurumOid { get; set; }
        public EUserType? KullaniciTipi { get; set; }
        public ELanguage? Dil { get; set; }
        public string RequestIp { get; set; }

        public bool IsInRole(string role)
        {
            return false;
        }
    }
}
