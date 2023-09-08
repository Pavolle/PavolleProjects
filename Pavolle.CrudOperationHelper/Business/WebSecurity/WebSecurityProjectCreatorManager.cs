using Pavolle.Core.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.CrudOperationHelper.Business.WebSecurity
{
    public class WebSecurityProjectCreatorManager : Singleton<WebSecurityProjectCreatorManager>
    {
        private WebSecurityProjectCreatorManager() { }

        //TODO Daha sonra için bu altyapıyı tek tek classları oluşturacak hale getirmemiz gerekiyor.
        public bool Write(string companyName, string projectName, string projectPath, int tokenExpireHour, string issuer, string audience)
        {
            string projectNameRoot=companyName+"."+projectName;
            #region Identity
            string identityClass = "";
            identityClass += "using System.Security.Principal;" + Environment.NewLine;
            identityClass += "" + Environment.NewLine;
            identityClass += "namespace " + projectNameRoot + "." + AppConsts.WebSecurityProjectName + Environment.NewLine;
            identityClass += "{" + Environment.NewLine;
            identityClass += "    public class " + projectName + "Identity : IIdentity" + Environment.NewLine;
            identityClass += "    {" + Environment.NewLine;
            identityClass += "        public " + projectName + "Identity(string name, string authenticationType)" + Environment.NewLine;
            identityClass += "        {" + Environment.NewLine;
            identityClass += "            Name = name;" + Environment.NewLine;
            identityClass += "            IsAuthenticated = true;" + Environment.NewLine;
            identityClass += "            AuthenticationType = authenticationType;" + Environment.NewLine;
            identityClass += "        }" + Environment.NewLine;
            identityClass += "" + Environment.NewLine;
            identityClass += "        public string Name { get; private set; }" + Environment.NewLine;
            identityClass += "        public string AuthenticationType { get; private set; }" + Environment.NewLine;
            identityClass += "        public bool IsAuthenticated { get; private set; }" + Environment.NewLine;
            identityClass += "    }" + Environment.NewLine;
            identityClass += "}" + Environment.NewLine;

            bool createResult = FileHelperManager.Instance.WriteFile(projectPath, projectNameRoot + "." + AppConsts.WebSecurityProjectName, projectName + AppConsts.WebSecurityIdentityClassFileName, identityClass);
            #endregion

            #region Principal
            string principalClass = "";
            principalClass += "using Pavolle.Core.Enums;" + Environment.NewLine;
            principalClass += "using " + projectNameRoot + "." + AppConsts.CommonProjectName + "." + AppConsts.CommonEnumFolderName + ";" + Environment.NewLine;
            principalClass += "using System.Security.Principal;" + Environment.NewLine;
            principalClass += "" + Environment.NewLine;
            principalClass += "namespace " + projectNameRoot + "." + AppConsts.WebSecurityProjectName + Environment.NewLine;
            principalClass += "{" + Environment.NewLine;
            principalClass += "    public class " + projectName + "Principal : IPrincipal" + Environment.NewLine;
            principalClass += "    {" + Environment.NewLine;
            principalClass += "        public " + projectName + "Principal(" + projectName + "Identity identity,  string sessionId, long? userGroupOid, EUserType? userType, ELanguage? language, string requestIp)" + Environment.NewLine;
            principalClass += "        {" + Environment.NewLine;
            principalClass += "            if (identity == null)" + Environment.NewLine;
            principalClass += "            {" + Environment.NewLine;
            principalClass += "                //TODO Log indentity error" + Environment.NewLine;
            principalClass += "            }" + Environment.NewLine;
            principalClass += "            this.Identity = identity;" + Environment.NewLine;
            principalClass += "            this.SessionId = sessionId;" + Environment.NewLine;
            principalClass += "            this.UserGroupOid = userGroupOid;" + Environment.NewLine;
            principalClass += "            this.UserType = userType;" + Environment.NewLine;
            principalClass += "            this.Language = language;" + Environment.NewLine;
            principalClass += "            this.RequestIp = requestIp;" + Environment.NewLine;
            principalClass += "        }" + Environment.NewLine;
            principalClass += "" + Environment.NewLine;
            principalClass += "        public IIdentity Identity { get; private set; }" + Environment.NewLine;
            principalClass += "" + Environment.NewLine;
            principalClass += "        public string SessionId { get; set; }" + Environment.NewLine;
            principalClass += "" + Environment.NewLine;
            principalClass += "        public long? UserGroupOid { get; set; }" + Environment.NewLine;
            principalClass += "" + Environment.NewLine;
            principalClass += "        public EUserType? UserType { get; set; }" + Environment.NewLine;
            principalClass += "" + Environment.NewLine;
            principalClass += "        public ELanguage? Language { get; set; }" + Environment.NewLine;
            principalClass += "" + Environment.NewLine;
            principalClass += "        public string RequestIp { get; set; }" + Environment.NewLine;
            principalClass += "" + Environment.NewLine;
            principalClass += "        public bool IsInRole(string role)" + Environment.NewLine;
            principalClass += "        {" + Environment.NewLine;
            principalClass += "            return false;" + Environment.NewLine;
            principalClass += "        }" + Environment.NewLine;
            principalClass += "    }" + Environment.NewLine;
            principalClass += "}" + Environment.NewLine;

            createResult = FileHelperManager.Instance.WriteFile(projectPath, projectNameRoot + "." + AppConsts.WebSecurityProjectName, projectName + AppConsts.WebSecurityPrincipalClassFileName, principalClass);

            #endregion

            #region Jwt Token Manager
            string jwtTokenManagerClass = "";
            jwtTokenManagerClass += "using Microsoft.IdentityModel.Tokens;" + Environment.NewLine;
            jwtTokenManagerClass += "using Pavolle.Core.Utils;" + Environment.NewLine;
            jwtTokenManagerClass += "using System.IdentityModel.Tokens.Jwt;" + Environment.NewLine;
            jwtTokenManagerClass += "using System.Security.Claims;" + Environment.NewLine;
            jwtTokenManagerClass += "" + Environment.NewLine;
            jwtTokenManagerClass += "namespace " + projectNameRoot + "." + AppConsts.WebSecurityProjectName + Environment.NewLine;
            jwtTokenManagerClass += "{" + Environment.NewLine;
            jwtTokenManagerClass += "    public class " + projectName + "JwtTokenManager : Singleton<" + projectName + "JwtTokenManager>" + Environment.NewLine;
            jwtTokenManagerClass += "    {" + Environment.NewLine;
            jwtTokenManagerClass += "" + Environment.NewLine;
            jwtTokenManagerClass += "        private " + projectName + "JwtTokenManager() { }" + Environment.NewLine;
            jwtTokenManagerClass += "" + Environment.NewLine;
            jwtTokenManagerClass += "        public string CreateToken(string username, string sessionId, string userGroupOid, string userType, string language, string requestIp)" + Environment.NewLine;
            jwtTokenManagerClass += "        {" + Environment.NewLine;
            jwtTokenManagerClass += "            var subject = new ClaimsIdentity(new[]" + Environment.NewLine;
            jwtTokenManagerClass += "            {" + Environment.NewLine;
            jwtTokenManagerClass += "                new Claim(" + projectName + "SecurityConstsManager.Instance.GetUsernameKey(), username)," + Environment.NewLine;
            jwtTokenManagerClass += "                new Claim(" + projectName + "SecurityConstsManager.Instance.GetSesionIdKey(), sessionId)," + Environment.NewLine;
            jwtTokenManagerClass += "                new Claim(" + projectName + "SecurityConstsManager.Instance.GetUserGroupOidKey(), userGroupOid)," + Environment.NewLine;
            jwtTokenManagerClass += "                new Claim(" + projectName + "SecurityConstsManager.Instance.GetUserTypeKey(), userType)," + Environment.NewLine;
            jwtTokenManagerClass += "                new Claim(" + projectName + "SecurityConstsManager.Instance.GetLanguageKey(), language)," + Environment.NewLine;
            jwtTokenManagerClass += "                new Claim(" + projectName + "SecurityConstsManager.Instance.GetRequestIp(), requestIp)" + Environment.NewLine;
            jwtTokenManagerClass += "            });" + Environment.NewLine;
            jwtTokenManagerClass += "" + Environment.NewLine;
            jwtTokenManagerClass += "            var tokenDescriptor = new SecurityTokenDescriptor" + Environment.NewLine;
            jwtTokenManagerClass += "            {" + Environment.NewLine;
            jwtTokenManagerClass += "                Subject = subject," + Environment.NewLine;
            jwtTokenManagerClass += "                Expires = DateTime.Now.AddHours(" + tokenExpireHour.ToString() + ")," + Environment.NewLine;
            jwtTokenManagerClass += "                Issuer = " + projectName + "SecurityConstsManager.Issuer," + Environment.NewLine;
            jwtTokenManagerClass += "                Audience = " + projectName + "SecurityConstsManager.Audience," + Environment.NewLine;
            jwtTokenManagerClass += "                SigningCredentials = new SigningCredentials(" + projectName + "SecurityConstsManager.Instance.GetKey(), SecurityAlgorithms.HmacSha512Signature)" + Environment.NewLine;
            jwtTokenManagerClass += "            };" + Environment.NewLine;
            jwtTokenManagerClass += "" + Environment.NewLine;
            jwtTokenManagerClass += "            var tokenHandler = new JwtSecurityTokenHandler();" + Environment.NewLine;
            jwtTokenManagerClass += "            var token = tokenHandler.CreateToken(tokenDescriptor);" + Environment.NewLine;
            jwtTokenManagerClass += "            var stringToken = tokenHandler.WriteToken(token);" + Environment.NewLine;
            jwtTokenManagerClass += "            return stringToken;" + Environment.NewLine;
            jwtTokenManagerClass += "        }" + Environment.NewLine;
            jwtTokenManagerClass += "    }" + Environment.NewLine;
            jwtTokenManagerClass += "}" + Environment.NewLine;

            createResult = FileHelperManager.Instance.WriteFile(projectPath, projectNameRoot + "." + AppConsts.WebSecurityProjectName, projectName + AppConsts.WebSecurityJwtTokenManagerClassFileName, jwtTokenManagerClass);

            #endregion

            #region Security Const Manager
            string securityConstsManagerClass = "";
            securityConstsManagerClass += "using Microsoft.IdentityModel.Tokens;" + Environment.NewLine;
            securityConstsManagerClass += "using Pavolle.Core.Utils;" + Environment.NewLine;
            securityConstsManagerClass += "using System.Text;" + Environment.NewLine;
            securityConstsManagerClass += "" + Environment.NewLine;
            securityConstsManagerClass += "namespace " + projectNameRoot + "." + AppConsts.WebSecurityProjectName + Environment.NewLine;
            securityConstsManagerClass += "{" + Environment.NewLine;
            securityConstsManagerClass += "    public class " + projectName + "SecurityConstsManager : Singleton<" + projectName + "SecurityConstsManager>" + Environment.NewLine;
            securityConstsManagerClass += "    {" + Environment.NewLine;
            securityConstsManagerClass += "        public const string SymmetricSecurityKeyString = \"" + string.Format(AppConsts.WebSecurityKey, issuer, "PAVOLLE", issuer) + "\";" + Environment.NewLine;
            securityConstsManagerClass += "        public const string Issuer = \"" + issuer + "\";" + Environment.NewLine;
            securityConstsManagerClass += "        public const string Audience = \"" + audience + "\";" + Environment.NewLine;
            securityConstsManagerClass += "" + Environment.NewLine;
            securityConstsManagerClass += "        private readonly string UsernameKey;" + Environment.NewLine;
            securityConstsManagerClass += "        private readonly string SesionIdKey;" + Environment.NewLine;
            securityConstsManagerClass += "        private readonly string UserGroupOidKey;" + Environment.NewLine;
            securityConstsManagerClass += "        private readonly string UserTypeKey;" + Environment.NewLine;
            securityConstsManagerClass += "        private readonly string LanguageKey;" + Environment.NewLine;
            securityConstsManagerClass += "        private readonly SymmetricSecurityKey key;" + Environment.NewLine;
            securityConstsManagerClass += "        private readonly string RequestIpKey;" + Environment.NewLine;
            securityConstsManagerClass += "" + Environment.NewLine;
            securityConstsManagerClass += "        private " + projectName + "SecurityConstsManager()" + Environment.NewLine;
            securityConstsManagerClass += "        {" + Environment.NewLine;
            securityConstsManagerClass += "            UsernameKey = \"Username\";" + Environment.NewLine;
            securityConstsManagerClass += "            LanguageKey = \"Language\";" + Environment.NewLine;
            securityConstsManagerClass += "            SesionIdKey = \"SessionId\";" + Environment.NewLine;
            securityConstsManagerClass += "            UserTypeKey = \"UserType\";" + Environment.NewLine;
            securityConstsManagerClass += "            UserGroupOidKey = \"UserGroupOid\";" + Environment.NewLine;
            securityConstsManagerClass += "            RequestIpKey = \"RequestIP\";" + Environment.NewLine;
            securityConstsManagerClass += "            key = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(SymmetricSecurityKeyString)) { KeyId = \"1000\" };" + Environment.NewLine;
            securityConstsManagerClass += "        }" + Environment.NewLine;
            securityConstsManagerClass += "" + Environment.NewLine;
            securityConstsManagerClass += "        public string GetRequestIp()" + Environment.NewLine;
            securityConstsManagerClass += "        {" + Environment.NewLine;
            securityConstsManagerClass += "            return RequestIpKey;" + Environment.NewLine;
            securityConstsManagerClass += "        }" + Environment.NewLine;
            securityConstsManagerClass += "" + Environment.NewLine;
            securityConstsManagerClass += "        public string GetLanguageKey()" + Environment.NewLine;
            securityConstsManagerClass += "        {" + Environment.NewLine;
            securityConstsManagerClass += "            return LanguageKey;" + Environment.NewLine;
            securityConstsManagerClass += "        }" + Environment.NewLine;
            securityConstsManagerClass += "" + Environment.NewLine;
            securityConstsManagerClass += "        public string GetUsernameKey()" + Environment.NewLine;
            securityConstsManagerClass += "        {" + Environment.NewLine;
            securityConstsManagerClass += "            return UsernameKey;" + Environment.NewLine;
            securityConstsManagerClass += "        }" + Environment.NewLine;
            securityConstsManagerClass += "" + Environment.NewLine;
            securityConstsManagerClass += "        public string GetSesionIdKey()" + Environment.NewLine;
            securityConstsManagerClass += "        {" + Environment.NewLine;
            securityConstsManagerClass += "            return SesionIdKey;" + Environment.NewLine;
            securityConstsManagerClass += "        }" + Environment.NewLine;
            securityConstsManagerClass += "" + Environment.NewLine;
            securityConstsManagerClass += "        public string GetSymmetricSecurityKeyString()" + Environment.NewLine;
            securityConstsManagerClass += "        {" + Environment.NewLine;
            securityConstsManagerClass += "            return SymmetricSecurityKeyString;" + Environment.NewLine;
            securityConstsManagerClass += "        }" + Environment.NewLine;
            securityConstsManagerClass += "" + Environment.NewLine;
            securityConstsManagerClass += "        public SymmetricSecurityKey GetKey()" + Environment.NewLine;
            securityConstsManagerClass += "        {" + Environment.NewLine;
            securityConstsManagerClass += "            return key;" + Environment.NewLine;
            securityConstsManagerClass += "        }" + Environment.NewLine;
            securityConstsManagerClass += "" + Environment.NewLine;
            securityConstsManagerClass += "        public string GetUserGroupOidKey()" + Environment.NewLine;
            securityConstsManagerClass += "        {" + Environment.NewLine;
            securityConstsManagerClass += "            return UserGroupOidKey;" + Environment.NewLine;
            securityConstsManagerClass += "        }" + Environment.NewLine;
            securityConstsManagerClass += "" + Environment.NewLine;
            securityConstsManagerClass += "        public string GetUserTypeKey()" + Environment.NewLine;
            securityConstsManagerClass += "        {" + Environment.NewLine;
            securityConstsManagerClass += "            return UserTypeKey;" + Environment.NewLine;
            securityConstsManagerClass += "        }" + Environment.NewLine;
            securityConstsManagerClass += "" + Environment.NewLine;
            securityConstsManagerClass += "        public string GetKeyString()" + Environment.NewLine;
            securityConstsManagerClass += "        {" + Environment.NewLine;
            securityConstsManagerClass += "            return SymmetricSecurityKeyString;" + Environment.NewLine;
            securityConstsManagerClass += "        }" + Environment.NewLine;
            securityConstsManagerClass += "    }" + Environment.NewLine;
            securityConstsManagerClass += "}" + Environment.NewLine;
            #endregion

            createResult = FileHelperManager.Instance.WriteFile(projectPath, projectNameRoot + "." + AppConsts.WebSecurityProjectName, projectName + AppConsts.WebSecuritySecurityConstsManagerClassFileName, securityConstsManagerClass);


            string csprojWebSecurity = "";
            csprojWebSecurity += "<Project Sdk=\"Microsoft.NET.Sdk\">" + Environment.NewLine;
            csprojWebSecurity += "" + Environment.NewLine;
            csprojWebSecurity += "  <PropertyGroup>" + Environment.NewLine;
            csprojWebSecurity += "    <TargetFramework>net6.0</TargetFramework>" + Environment.NewLine;
            csprojWebSecurity += "    <ImplicitUsings>enable</ImplicitUsings>" + Environment.NewLine;
            csprojWebSecurity += "    <Nullable>enable</Nullable>" + Environment.NewLine;
            csprojWebSecurity += "  </PropertyGroup>" + Environment.NewLine;
            csprojWebSecurity += "" + Environment.NewLine;
            csprojWebSecurity += "  <ItemGroup>" + Environment.NewLine;
            csprojWebSecurity += "    <PackageReference Include=\"Microsoft.IdentityModel.Tokens\" Version=\"6.32.0\" />" + Environment.NewLine;
            csprojWebSecurity += "    <PackageReference Include=\"System.IdentityModel.Tokens.Jwt\" Version=\"6.32.0\" />" + Environment.NewLine;
            csprojWebSecurity += "  </ItemGroup>" + Environment.NewLine;
            csprojWebSecurity += "" + Environment.NewLine;
            csprojWebSecurity += "  <ItemGroup>" + Environment.NewLine;
            csprojWebSecurity += "    <ProjectReference Include=\"..\\" + projectNameRoot + "." + AppConsts.CommonProjectName + "\\" + projectNameRoot + "." + AppConsts.CommonProjectName + ".csproj\" />" + Environment.NewLine;
            csprojWebSecurity += "    <ProjectReference Include=\"..\\Pavolle.Core\\Pavolle.Core.csproj\" />" + Environment.NewLine;
            csprojWebSecurity += "  </ItemGroup>" + Environment.NewLine;
            csprojWebSecurity += "" + Environment.NewLine;
            csprojWebSecurity += "</Project>" + Environment.NewLine;

            createResult = FileHelperManager.Instance.EditFile(projectPath, projectNameRoot + "." + AppConsts.WebSecurityProjectName, projectNameRoot + "." + AppConsts.WebSecurityProjectName + ".csproj", csprojWebSecurity);
            return createResult;
        }
    }
}
