using Microsoft.IdentityModel.Tokens;
using Pavolle.Core.Utils;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.BES.WebSecurity
{
    public class BesJwtTokenManager : Singleton<BesJwtTokenManager>
    {

        private BesJwtTokenManager() { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="username"></param>
        /// <param name="sessionId"></param>
        /// <param name="userGroupOid"></param>
        /// <param name="userType"></param>
        /// <param name="language"></param>
        /// <param name="requestIp"></param>
        /// <param name="createdTime">Epoch time</param>
        /// <returns></returns>
        public string CreateToken(string username, string sessionId, string userGroupOid, string userType, string language, string requestIp, string createdTime)
        {
            var subject = new ClaimsIdentity(new[]
            {
                new Claim(BesSecurityConstsManager.Instance.GetUsernameKey(), username),
                new Claim(BesSecurityConstsManager.Instance.GetSesionIdKey(), sessionId),
                new Claim(BesSecurityConstsManager.Instance.GetUserGroupOidKey(), userGroupOid),
                new Claim(BesSecurityConstsManager.Instance.GetUserTypeKey(), userType),
                new Claim(BesSecurityConstsManager.Instance.GetLanguageKey(), language),
                new Claim(BesSecurityConstsManager.Instance.GetCreatedTime(), language),
                new Claim(BesSecurityConstsManager.Instance.GetRequestIp(), createdTime)
            });

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = subject,
                Expires = DateTime.Now.AddHours(2),
                Issuer = BesSecurityConstsManager.Issuer,
                Audience = BesSecurityConstsManager.Audience,
                SigningCredentials = new SigningCredentials(BesSecurityConstsManager.Instance.GetKey(), SecurityAlgorithms.HmacSha512Signature)
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var stringToken = tokenHandler.WriteToken(token);
            return stringToken;
        }
    }
}
