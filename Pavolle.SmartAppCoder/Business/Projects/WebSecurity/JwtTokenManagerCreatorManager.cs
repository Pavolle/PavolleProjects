using Pavolle.SmartAppCoder.Common.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.SmartAppCoder.Business.Projects.WebSecurity
{
    internal class JwtTokenManagerCreatorManager : Singleton<JwtTokenManagerCreatorManager>
    {
        private JwtTokenManagerCreatorManager() { }

        public bool Create(string organizationName, string projectName, string projectPath, string tokenExpireHour)
        {
            string projectNameRoot = organizationName + "." + projectName;

            string classString = "";
            classString += "using Microsoft.IdentityModel.Tokens;" + Environment.NewLine;
            classString += "using "+organizationName+".Core.Utils;" + Environment.NewLine;
            classString += "using System.IdentityModel.Tokens.Jwt;" + Environment.NewLine;
            classString += "using System.Security.Claims;" + Environment.NewLine;
            classString += "" + Environment.NewLine;
            classString += "namespace " + projectNameRoot + ".WebSecurity" + Environment.NewLine;
            classString += "{" + Environment.NewLine;
            classString += "    public class " + projectName + "JwtTokenManager : Singleton<" + projectName + "JwtTokenManager>" + Environment.NewLine;
            classString += "    {" + Environment.NewLine;
            classString += "" + Environment.NewLine;
            classString += "        private " + projectName + "JwtTokenManager() { }" + Environment.NewLine;
            classString += "" + Environment.NewLine;
            classString += "        public string CreateToken(string username, string sessionId, string userGroupOid, string userType, string language, string requestIp)" + Environment.NewLine;
            classString += "        {" + Environment.NewLine;
            classString += "            var subject = new ClaimsIdentity(new[]" + Environment.NewLine;
            classString += "            {" + Environment.NewLine;
            classString += "                new Claim(" + projectName + "SecurityConstsManager.Instance.GetUsernameKey(), username)," + Environment.NewLine;
            classString += "                new Claim(" + projectName + "SecurityConstsManager.Instance.GetSesionIdKey(), sessionId)," + Environment.NewLine;
            classString += "                new Claim(" + projectName + "SecurityConstsManager.Instance.GetUserGroupOidKey(), userGroupOid)," + Environment.NewLine;
            classString += "                new Claim(" + projectName + "SecurityConstsManager.Instance.GetUserTypeKey(), userType)," + Environment.NewLine;
            classString += "                new Claim(" + projectName + "SecurityConstsManager.Instance.GetLanguageKey(), language)," + Environment.NewLine;
            classString += "                new Claim(" + projectName + "SecurityConstsManager.Instance.GetRequestIp(), requestIp)" + Environment.NewLine;
            classString += "            });" + Environment.NewLine;
            classString += "" + Environment.NewLine;
            classString += "            var tokenDescriptor = new SecurityTokenDescriptor" + Environment.NewLine;
            classString += "            {" + Environment.NewLine;
            classString += "                Subject = subject," + Environment.NewLine;
            classString += "                Expires = DateTime.Now.AddHours(" + tokenExpireHour + ")," + Environment.NewLine;
            classString += "                Issuer = " + projectName + "SecurityConstsManager.Issuer," + Environment.NewLine;
            classString += "                Audience = " + projectName + "SecurityConstsManager.Audience," + Environment.NewLine;
            classString += "                SigningCredentials = new SigningCredentials(" + projectName + "SecurityConstsManager.Instance.GetKey(), SecurityAlgorithms.HmacSha512Signature)" + Environment.NewLine;
            classString += "            };" + Environment.NewLine;
            classString += "" + Environment.NewLine;
            classString += "            var tokenHandler = new JwtSecurityTokenHandler();" + Environment.NewLine;
            classString += "            var token = tokenHandler.CreateToken(tokenDescriptor);" + Environment.NewLine;
            classString += "            var stringToken = tokenHandler.WriteToken(token);" + Environment.NewLine;
            classString += "            return stringToken;" + Environment.NewLine;
            classString += "        }" + Environment.NewLine;
            classString += "    }" + Environment.NewLine;
            classString += "}" + Environment.NewLine;

            return FileHelperManager.Instance.WriteFile(projectPath + "\\" + projectNameRoot + ".WebSecurity", "", projectName + "JwtTokenManager.cs", classString);
        }
    }
}