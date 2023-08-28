using Microsoft.IdentityModel.Tokens;
using Pavolle.Core.Utils;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Pavolle.MessageService.WebSecurity
{
    public class MesssageServiceJwtTokenManager:Singleton<MesssageServiceJwtTokenManager>
    {
        private MesssageServiceJwtTokenManager() { }


        public string TokenOlustur(string username, string sessionId, string companyOid, string userType, string language, string requestIp)
        {
            var subject = new ClaimsIdentity(new[]
            {
                new Claim(SecurityConstsManager.Instance.GetUsernameKey(), username),
                new Claim(SecurityConstsManager.Instance.GetSesionIdKey(), sessionId),
                new Claim(SecurityConstsManager.Instance.GetCompanyOidKey(), companyOid),
                new Claim(SecurityConstsManager.Instance.GetUserTypeKey(), userType),
                new Claim(SecurityConstsManager.Instance.GetLanguageKey(), language),
                new Claim(SecurityConstsManager.Instance.GetRequestIp(), requestIp)
            });

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = subject,
                Expires = DateTime.Now.AddHours(72),
                Issuer = SecurityConstsManager.Issuer,
                Audience = SecurityConstsManager.Audience,
                SigningCredentials = new SigningCredentials(SecurityConstsManager.Instance.GetKey(), SecurityAlgorithms.HmacSha512Signature)
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var stringToken = tokenHandler.WriteToken(token);
            return stringToken;
        }
    }
}
