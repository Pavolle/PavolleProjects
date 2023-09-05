using Microsoft.IdentityModel.Tokens;
using Pavolle.Core.Utils;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Pavolle.MessageService.WebSecurity
{
    public class MessageServiceJwtTokenManager : Singleton<MessageServiceJwtTokenManager>
    {

        private MessageServiceJwtTokenManager() { }

        public string CreateToken(string username, string sessionId, string userGroupOid, string userType, string language, string requestIp)
        {
            var subject = new ClaimsIdentity(new[]
            {
                new Claim(MessageServiceSecurityConstsManager.Instance.GetUsernameKey(), username),
                new Claim(MessageServiceSecurityConstsManager.Instance.GetSesionIdKey(), sessionId),
                new Claim(MessageServiceSecurityConstsManager.Instance.GetUserGroupOidKey(), userGroupOid),
                new Claim(MessageServiceSecurityConstsManager.Instance.GetUserTypeKey(), userType),
                new Claim(MessageServiceSecurityConstsManager.Instance.GetLanguageKey(), language),
                new Claim(MessageServiceSecurityConstsManager.Instance.GetRequestIp(), requestIp)
            });

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = subject,
                Expires = DateTime.Now.AddHours(0),
                Issuer = MessageServiceSecurityConstsManager.Issuer,
                Audience = MessageServiceSecurityConstsManager.Audience,
                SigningCredentials = new SigningCredentials(MessageServiceSecurityConstsManager.Instance.GetKey(), SecurityAlgorithms.HmacSha512Signature)
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var stringToken = tokenHandler.WriteToken(token);
            return stringToken;
        }
    }
}
