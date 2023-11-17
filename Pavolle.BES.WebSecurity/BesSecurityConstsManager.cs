using Microsoft.IdentityModel.Tokens;
using Pavolle.Core.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.BES.WebSecurity
{
    internal class BesSecurityConstsManager : Singleton<BesSecurityConstsManager>
    {
        public const string SymmetricSecurityKeyString = "734df+5gdgaq@@&&www-3421-3-ff!dsfwwwdpavollefb34g7ugfdsfvfv--34sdewwe3er34rwwefd34ffssd5ww4545zss";
        public const string Issuer = "pavolle";
        public const string Audience = "pavolle";

        private readonly string UsernameKey;
        private readonly string SesionIdKey;
        private readonly string UserGroupOidKey;
        private readonly string UserTypeKey;
        private readonly string LanguageKey;
        private readonly SymmetricSecurityKey key;
        private readonly string RequestIpKey;
        private readonly string CreatedTime;

        private BesSecurityConstsManager()
        {
            UsernameKey = "UN";
            LanguageKey = "L";
            SesionIdKey = "SID";
            UserTypeKey = "UT";
            UserGroupOidKey = "UG";
            RequestIpKey = "RIP";
            CreatedTime = "CT";
            key = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(SymmetricSecurityKeyString)) { KeyId = "1000" };
        }

        public string GetCreatedTime()
        {
            return CreatedTime;
        }

        public string GetRequestIp()
        {
            return RequestIpKey;
        }

        public string GetLanguageKey()
        {
            return LanguageKey;
        }

        public string GetUsernameKey()
        {
            return UsernameKey;
        }

        public string GetSesionIdKey()
        {
            return SesionIdKey;
        }

        public string GetSymmetricSecurityKeyString()
        {
            return SymmetricSecurityKeyString;
        }

        public SymmetricSecurityKey GetKey()
        {
            return key;
        }

        public string GetUserGroupOidKey()
        {
            return UserGroupOidKey;
        }

        public string GetUserTypeKey()
        {
            return UserTypeKey;
        }

        public string GetKeyString()
        {
            return SymmetricSecurityKeyString;
        }
    }
}
