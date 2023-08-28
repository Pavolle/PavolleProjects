using Pavolle.Core.Enums;
using Pavolle.B2B.Common.Enums;
using System.Security.Principal;

namespace Pavolle.B2B.WebSecurity
{
    public class B2BPrincipal : IPrincipal
    {
        public B2BPrincipal(B2BIdentity identity,  string sessionId, long? organizationOid, EUserType? userType, ELanguage? language, string requestIp)
        {
            if (identity == null)
            {
                //TODO Log indentity error
            }
            this.Identity = identity;
            this.SessionId = sessionId;
            this.OrganizationOid = organizationOid;
            this.UserType = userType;
            this.Language = language;
            this.RequestIp = requestIp;
        }

        public IIdentity Identity { get; private set; }

        public string SessionId { get; set; }

        public long? OrganizationOid { get; set; }

        public EUserType? UserType { get; set; }

        public ELanguage? Language { get; set; }

        public string RequestIp { get; set; }

        public bool IsInRole(string role)
        {
            return false;
        }
    }
}
