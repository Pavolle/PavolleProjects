using Pavolle.BES.AuthServer.Common.Enums;
using Pavolle.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.BES.WebSecurity
{
    public class BesPrincipal : IPrincipal
    {
        public BesPrincipal(BesIdentity identity, string sessionId, long? userGroupOid, EUserType? userType, ELanguage? language, string requestIp, DateTime? createdTime)
        {
            if (identity == null)
            {
                //TODO Log indentity error
            }
            this.Identity = identity;
            this.SessionId = sessionId;
            this.RequestIp = requestIp;
            this.UserGroupOid = userGroupOid;
            this.UserType = userType;
            this.Language = language;
            this.CreatedTime = createdTime;
        }

        public IIdentity Identity { get; private set; }

        public string SessionId { get; set; }

        public string RequestIp { get; set; }

        public long? UserGroupOid { get; set; }

        public EUserType? UserType { get; set; }

        public ELanguage? Language { get; set; }

        public DateTime? CreatedTime { get; set; }

        public bool IsInRole(string role)
        {
            return false;
        }
    }
}
