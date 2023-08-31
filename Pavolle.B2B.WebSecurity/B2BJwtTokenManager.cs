using Microsoft.IdentityModel.Tokens;
using Pavolle.Core.Utils;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Pavolle.B2B.WebSecurity
{
    public class B2BJwtTokenManager : Singleton<B2BJwtTokenManager>
    {

        private B2BJwtTokenManager() { }

        public string CreateToken(string username, string sessionId, string userGroupOid, string userType, string language, string requestIp)
        {
            var subject = new ClaimsIdentity(new[]
            {
                new Claim(B2BSecurityConstsManager.Instance.GetUsernameKey(), username),
                new Claim(B2BSecurityConstsManager.Instance.GetSesionIdKey(), sessionId),
                new Claim(B2BSecurityConstsManager.Instance.GetUserGroupOidKey(), userGroupOid),
                new Claim(B2BSecurityConstsManager.Instance.GetUserTypeKey(), userType),
                new Claim(B2BSecurityConstsManager.Instance.GetLanguageKey(), language),
                new Claim(B2BSecurityConstsManager.Instance.GetRequestIp(), requestIp)
            });

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = subject,
                Expires = DateTime.Now.AddHours(24),
                Issuer = B2BSecurityConstsManager.Issuer,
                Audience = B2BSecurityConstsManager.Audience,
                SigningCredentials = new SigningCredentials(B2BSecurityConstsManager.Instance.GetKey(), SecurityAlgorithms.HmacSha512Signature)
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var stringToken = tokenHandler.WriteToken(token);
            return stringToken;
        }
    }
}
