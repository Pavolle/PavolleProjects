using Microsoft.IdentityModel.Tokens;
using Pavolle.Core.Utils;
using System.Text;

namespace Pavolle.B2B.WebSecurity
{
    public class B2BSecurityConstsManager : Singleton<B2BSecurityConstsManager>
    {
        public const string SymmetricSecurityKeyString = "73Pavolle4df+5gdgaq@@&&www-3421-3-ff!dsfwwwdPAVOLLEfb34g7ugfdsfvfv-PAVOLLE-34sde-w!we3e!7/r34r@w*wefdPavollessd5ww4545zss";
        public const string Issuer = "Pavolle";
        public const string Audience = "Pavolle";

        private readonly string UsernameKey;
        private readonly string SesionIdKey;
        private readonly string UserGroupOidKey;
        private readonly string UserTypeKey;
        private readonly string LanguageKey;
        private readonly SymmetricSecurityKey key;
        private readonly string RequestIpKey;

        private B2BSecurityConstsManager()
        {
            UsernameKey = "Username";
            LanguageKey = "Language";
            SesionIdKey = "SessionId";
            UserTypeKey = "UserType";
            UserGroupOidKey = "UserGroupOid";
            RequestIpKey = "RequestIP";
            key = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(SymmetricSecurityKeyString)) { KeyId = "1000" };
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
