using Pavolle.Core.Enums;
using Pavolle.MessageService.Common.Enums;
using System.Security.Principal;

namespace Pavolle.MessageService.WebSecurity
{
    public class MessageServicePrincipal : IPrincipal
    {
        public MessageServicePrincipal(MessageServiceIdentity identity,  string sessionId, long? userGroupOid, EUserType? userType, ELanguage? language, string requestIp)
        {
            if (identity == null)
            {
                //TODO Log indentity error
            }
            this.Identity = identity;
            this.SessionId = sessionId;
            this.UserGroupOid = userGroupOid;
            this.UserType = userType;
            this.Language = language;
            this.RequestIp = requestIp;
        }

        public IIdentity Identity { get; private set; }

        public string SessionId { get; set; }

        public long? UserGroupOid { get; set; }

        public EUserType? UserType { get; set; }

        public ELanguage? Language { get; set; }

        public string RequestIp { get; set; }

        public bool IsInRole(string role)
        {
            return false;
        }
    }
}
