using Pavolle.Core.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.CrudOperationHelper.Business
{
    public class ProjectInitializeManager:Singleton<ProjectInitializeManager>
    {
        private ProjectInitializeManager()
        {

        }

        //User Request Log
        //Log all request and response
        //Log .net log

        public bool Start(string projectName, string projectNameRoot, string projectPath, string userType, string issuer, int tokenExpireHour)
        {
            GenerateBaseObject(projectNameRoot, projectPath);
            GeneratXpoMnaagerClass(projectNameRoot, projectPath);

            //TODO Auth Manager sınıfı eklenecek.
            GenerateUserTypeClassess(projectNameRoot, projectPath, userType);
            GenerateWebSecurityLayer(projectName, projectNameRoot, projectPath, issuer, tokenExpireHour);

            GenerateCompanyBusiness(projectNameRoot, projectPath);

            GenerateUserBusiness(projectNameRoot, projectPath);
            GenerateSystemSettingBusiness(projectNameRoot, projectPath);
            GenerateScheduleBusiness(projectNameRoot, projectPath);
            GenerateUserSessionBusiness(projectNameRoot, projectPath);
            GenerateLoginBusiness(projectNameRoot, projectPath);
            GenerateSetupManager(projectNameRoot, projectPath);

            return true;
        }

        private void GenerateSetupManager(string projectNameRoot, string projectPath)
        {
        }

        private void GenerateUserTypeClassess(string projectNameRoot, string projectPath, string userType)
        {
            string[] userTypes = userType.Split(',');
            int enumBaslangicSayisi = 1;
            string userTypeEnumClass = "";
            userTypeEnumClass += "namespace " + projectNameRoot + "." + AppConsts.CommonProjectName + "." + AppConsts.CommonEnumFolderName + "" + Environment.NewLine;
            userTypeEnumClass += "{" + Environment.NewLine;
            userTypeEnumClass += "    public enum EUserType" + Environment.NewLine;
            userTypeEnumClass += "    {" + Environment.NewLine;

            string authorizationDbClass = "";
            authorizationDbClass += "using DevExpress.Xpo;" + Environment.NewLine;
            authorizationDbClass += "using System;" + Environment.NewLine;
            authorizationDbClass += "using System.Collections.Generic;" + Environment.NewLine;
            authorizationDbClass += "using System.Linq;" + Environment.NewLine;
            authorizationDbClass += "using System.Text;" + Environment.NewLine;
            authorizationDbClass += "using System.Threading.Tasks;" + Environment.NewLine;
            authorizationDbClass += "" + Environment.NewLine;
            authorizationDbClass += "namespace " + projectNameRoot + "." + AppConsts.DBModelsProjectName + "." + AppConsts.DBModelsEntitiesFolderName + Environment.NewLine;
            authorizationDbClass += "{" + Environment.NewLine;
            authorizationDbClass += "    [Persistent(\"authorizations\")]" + Environment.NewLine;
            authorizationDbClass += "    public class " + AppConsts.DBModelsAuthClassName.Replace(".cs", "") + " : BaseObject" + Environment.NewLine;
            authorizationDbClass += "    {" + Environment.NewLine;
            authorizationDbClass += "" + Environment.NewLine;
            authorizationDbClass += "        public " + AppConsts.DBModelsAuthClassName.Replace(".cs", "") + "(Session session) : base(session)" + Environment.NewLine;
            authorizationDbClass += "        {" + Environment.NewLine;
            authorizationDbClass += "        }" + Environment.NewLine;
            authorizationDbClass += "" + Environment.NewLine;
            authorizationDbClass += "        [Persistent(\"api_key\")]" + Environment.NewLine;
            authorizationDbClass += "        [Size(255)]" + Environment.NewLine;
            authorizationDbClass += "        public string ApiKey { get; set; }" + Environment.NewLine;
            authorizationDbClass += "" + Environment.NewLine;
            authorizationDbClass += "        [Persistent(\"api_definition\")]" + Environment.NewLine;
            authorizationDbClass += "        [Size(255)]" + Environment.NewLine;
            authorizationDbClass += "        public string ApiDefinition { get; set; }" + Environment.NewLine;
            authorizationDbClass += "" + Environment.NewLine;
            foreach (var item in userTypes)
            {
                string itemClean = item.Trim().Replace(" ", "");
                userTypeEnumClass += "        " + itemClean + " = " + enumBaslangicSayisi + "," + Environment.NewLine;

                enumBaslangicSayisi++;

                authorizationDbClass += "        [Persistent(\"" + itemClean.ToLower() + "_auth\")]" + Environment.NewLine;
                authorizationDbClass += "        public string " + itemClean + "Auth { get; set; }" + Environment.NewLine;
                authorizationDbClass += "" + Environment.NewLine;
            }
            userTypeEnumClass += "    }" + Environment.NewLine;
            userTypeEnumClass += "}" + Environment.NewLine;


            authorizationDbClass += "        [Persistent(\"editable\")]" + Environment.NewLine;
            authorizationDbClass += "        public bool Editable { get; set; }" + Environment.NewLine;
            authorizationDbClass += "" + Environment.NewLine;
            authorizationDbClass += "        [Persistent(\"Anonymous\")]" + Environment.NewLine;
            authorizationDbClass += "        public bool Anonymous { get; set; }" + Environment.NewLine;
            authorizationDbClass += "    }" + Environment.NewLine;
            authorizationDbClass += "}" + Environment.NewLine;

            bool createEnumClassResult = FileHelperManager.Instance.WriteFile(projectPath, projectNameRoot + "." + AppConsts.CommonProjectName + "/" + AppConsts.CommonEnumFolderName, AppConsts.UserTypeEnumClassName, userTypeEnumClass);

            bool createAuthClassResult = FileHelperManager.Instance.WriteFile(projectPath, projectNameRoot + "." + AppConsts.DBModelsProjectName + "/" + AppConsts.DBModelsEntitiesFolderName, AppConsts.DBModelsAuthClassName, authorizationDbClass);
        }

        private void GenerateUserSessionBusiness(string projectNameRoot, string projectPath)
        {
        }

        private void GenerateLoginBusiness(string projectNameRoot, string projectPath)
        {
        }

        private void GenerateWebSecurityLayer(string projectName, string projectNameRoot, string projectPath, string issuer, int tokenExpireHour)
        {
            //Identity
            //SecurityConstManager
            //JwtTokenManager
            //Principal

            #region Identity
            string identityClass = "";
            identityClass += "using System.Security.Principal;" + Environment.NewLine;
            identityClass += "" + Environment.NewLine;
            identityClass += "namespace " + projectNameRoot + "." + AppConsts.WebSecurityProjectName + Environment.NewLine;
            identityClass += "{" + Environment.NewLine;
            identityClass += "    public class "+projectName+"Identity : IIdentity" + Environment.NewLine;
            identityClass += "    {" + Environment.NewLine;
            identityClass += "        public "+projectName+"Identity(string name, string authenticationType)" + Environment.NewLine;
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

            bool createidendityClassResult = FileHelperManager.Instance.WriteFile(projectPath, projectNameRoot + "." + AppConsts.WebSecurityProjectName, projectName + AppConsts.WebSecurityIdentityClassFileName, identityClass);
            #endregion

            #region Principal
            string principalClass = "";
            principalClass += "using Pavolle.Core.Enums;" + Environment.NewLine;
            principalClass += "using " + projectNameRoot + "." + AppConsts.CommonProjectName + "." + AppConsts.CommonEnumFolderName + ";" + Environment.NewLine;
            principalClass += "using System.Security.Principal;" + Environment.NewLine;
            principalClass += "" + Environment.NewLine;
            principalClass += "namespace " + projectNameRoot + "." + AppConsts.WebSecurityProjectName + Environment.NewLine;
            principalClass += "{" + Environment.NewLine;
            principalClass += "    public class "+projectName+"Principal : IPrincipal" + Environment.NewLine;
            principalClass += "    {" + Environment.NewLine;
            principalClass += "        public "+projectName+"Principal("+projectName+"Identity identity,  string sessionId, long? companyOid, EUserType? userType, ELanguage? language, string requestIp)" + Environment.NewLine;
            principalClass += "        {" + Environment.NewLine;
            principalClass += "            if (identity == null)" + Environment.NewLine;
            principalClass += "            {" + Environment.NewLine;
            principalClass += "                //TODO Log indentity error" + Environment.NewLine;
            principalClass += "            }" + Environment.NewLine;
            principalClass += "            this.Identity = identity;" + Environment.NewLine;
            principalClass += "            this.SessionId = sessionId;" + Environment.NewLine;
            principalClass += "            this.CompanyOid = companyOid;" + Environment.NewLine;
            principalClass += "            this.UserType = userType;" + Environment.NewLine;
            principalClass += "            this.Language = language;" + Environment.NewLine;
            principalClass += "            this.RequestIp = requestIp;" + Environment.NewLine;
            principalClass += "        }" + Environment.NewLine;
            principalClass += "" + Environment.NewLine;
            principalClass += "        public IIdentity Identity { get; private set; }" + Environment.NewLine;
            principalClass += "" + Environment.NewLine;
            principalClass += "        public string SessionId { get; set; }" + Environment.NewLine;
            principalClass += "" + Environment.NewLine;
            principalClass += "        public long? CompanyOid { get; set; }" + Environment.NewLine;
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

            bool createprincipalClassResult = FileHelperManager.Instance.WriteFile(projectPath, projectNameRoot + "." + AppConsts.WebSecurityProjectName, projectName + AppConsts.WebSecurityPrincipalClassFileName, principalClass);

            #endregion

            #region Jwt Token Manager
            string jwtTokenManagerClass = "";
            jwtTokenManagerClass += "using Microsoft.IdentityModel.Tokens;" + Environment.NewLine;
            jwtTokenManagerClass += "using Pavolle.Core.Utils;" + Environment.NewLine;
            jwtTokenManagerClass += "using System.IdentityModel.Tokens.Jwt;" + Environment.NewLine;
            jwtTokenManagerClass += "using System.Security.Claims;" + Environment.NewLine;
            jwtTokenManagerClass += "" + Environment.NewLine;
            jwtTokenManagerClass += "namespace "+projectNameRoot+"."+AppConsts.WebSecurityProjectName+ Environment.NewLine;
            jwtTokenManagerClass += "{" + Environment.NewLine;
            jwtTokenManagerClass += "    public class " + projectName + "JwtTokenManager : Singleton<" + projectName + "JwtTokenManager>" + Environment.NewLine;
            jwtTokenManagerClass += "    {" + Environment.NewLine;
            jwtTokenManagerClass += "" + Environment.NewLine;
            jwtTokenManagerClass += "        private " + projectName + "JwtTokenManager() { }" + Environment.NewLine;
            jwtTokenManagerClass += "" + Environment.NewLine;
            jwtTokenManagerClass += "        public string CreateToken(string username, string sessionId, string companyOid, string userType, string language, string requestIp)" + Environment.NewLine;
            jwtTokenManagerClass += "        {" + Environment.NewLine;
            jwtTokenManagerClass += "            var subject = new ClaimsIdentity(new[]" + Environment.NewLine;
            jwtTokenManagerClass += "            {" + Environment.NewLine;
            jwtTokenManagerClass += "                new Claim(" + projectName + "SecurityConstsManager.Instance.GetUsernameKey(), username)," + Environment.NewLine;
            jwtTokenManagerClass += "                new Claim(" + projectName + "SecurityConstsManager.Instance.GetSesionIdKey(), sessionId)," + Environment.NewLine;
            jwtTokenManagerClass += "                new Claim(" + projectName + "SecurityConstsManager.Instance.GetCompanyOidKey(), companyOid)," + Environment.NewLine;
            jwtTokenManagerClass += "                new Claim(" + projectName + "SecurityConstsManager.Instance.GetUserTypeKey(), userType)," + Environment.NewLine;
            jwtTokenManagerClass += "                new Claim(" + projectName + "SecurityConstsManager.Instance.GetLanguageKey(), language)," + Environment.NewLine;
            jwtTokenManagerClass += "                new Claim(" + projectName + "SecurityConstsManager.Instance.GetRequestIp(), requestIp)" + Environment.NewLine;
            jwtTokenManagerClass += "            });" + Environment.NewLine;
            jwtTokenManagerClass += "" + Environment.NewLine;
            jwtTokenManagerClass += "            var tokenDescriptor = new SecurityTokenDescriptor" + Environment.NewLine;
            jwtTokenManagerClass += "            {" + Environment.NewLine;
            jwtTokenManagerClass += "                Subject = subject," + Environment.NewLine;
            jwtTokenManagerClass += "                Expires = DateTime.Now.AddHours("+tokenExpireHour.ToString()+")," + Environment.NewLine;
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

            bool createJwtTokenManagerClassResult = FileHelperManager.Instance.WriteFile(projectPath, projectNameRoot + "." + AppConsts.WebSecurityProjectName, projectName + AppConsts.WebSecurityJwtTokenManagerClassFileName, jwtTokenManagerClass);

            #endregion

            #region Security Const Manager
            string securityConstsManagerClass = "";
            securityConstsManagerClass += "using Microsoft.IdentityModel.Tokens;" + Environment.NewLine;
            securityConstsManagerClass += "using Pavolle.Core.Utils;" + Environment.NewLine;
            securityConstsManagerClass += "using System.Text;" + Environment.NewLine;
            securityConstsManagerClass += "" + Environment.NewLine;
            securityConstsManagerClass += "namespace " + projectNameRoot + "." + AppConsts.WebSecurityProjectName + Environment.NewLine;
            securityConstsManagerClass += "{" + Environment.NewLine;
            securityConstsManagerClass += "    public class "+projectName+"SecurityConstsManager : Singleton<"+projectName+"SecurityConstsManager>" + Environment.NewLine;
            securityConstsManagerClass += "    {" + Environment.NewLine;
            securityConstsManagerClass += "        public const string SymmetricSecurityKeyString = \"" + string.Format(AppConsts.WebSecurityKey, issuer, "PAVOLLE", issuer) + "\";" + Environment.NewLine;
            securityConstsManagerClass += "        public const string Issuer = \""+issuer+"\";" + Environment.NewLine;
            securityConstsManagerClass += "        public const string Audience = \""+issuer+"\";" + Environment.NewLine;
            securityConstsManagerClass += "" + Environment.NewLine;
            securityConstsManagerClass += "        private readonly string UsernameKey;" + Environment.NewLine;
            securityConstsManagerClass += "        private readonly string SesionIdKey;" + Environment.NewLine;
            securityConstsManagerClass += "        private readonly string CompanyOidKey;" + Environment.NewLine;
            securityConstsManagerClass += "        private readonly string UserTypeKey;" + Environment.NewLine;
            securityConstsManagerClass += "        private readonly string LanguageKey;" + Environment.NewLine;
            securityConstsManagerClass += "        private readonly SymmetricSecurityKey key;" + Environment.NewLine;
            securityConstsManagerClass += "        private readonly string RequestIpKey;" + Environment.NewLine;
            securityConstsManagerClass += "" + Environment.NewLine;
            securityConstsManagerClass += "        private "+projectName+"SecurityConstsManager()" + Environment.NewLine;
            securityConstsManagerClass += "        {" + Environment.NewLine;
            securityConstsManagerClass += "            UsernameKey = \"Username\";" + Environment.NewLine;
            securityConstsManagerClass += "            LanguageKey = \"Language\";" + Environment.NewLine;
            securityConstsManagerClass += "            SesionIdKey = \"SessionId\";" + Environment.NewLine;
            securityConstsManagerClass += "            UserTypeKey = \"UserType\";" + Environment.NewLine;
            securityConstsManagerClass += "            CompanyOidKey = \"CompanyOid\";" + Environment.NewLine;
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
            securityConstsManagerClass += "        public string GetCompanyOidKey()" + Environment.NewLine;
            securityConstsManagerClass += "        {" + Environment.NewLine;
            securityConstsManagerClass += "            return CompanyOidKey;" + Environment.NewLine;
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

            bool createSecurityConstManagerClassResult = FileHelperManager.Instance.WriteFile(projectPath, projectNameRoot + "." + AppConsts.WebSecurityProjectName, projectName + AppConsts.WebSecuritySecurityConstsManagerClassFileName, securityConstsManagerClass);

        }

        private void GenerateScheduleBusiness(string projectNameRoot, string projectPath)
        {
        }

        private void GenerateSystemSettingBusiness(string projectNameRoot, string projectPath)
        {
        }

        private void GenerateUserBusiness(string projectNameRoot, string projectPath)
        {
        }

        private void GenerateCompanyBusiness(string projectNameRoot, string projectPath)
        {
            /*
             Db Class
            Criteria, request, response, authorization(Cache eklenecek)
            service
            business
             */


        }

        public bool GenerateBaseObject(string projectNameRoot, string projectPath)
        {
            bool response = false;

            string baseObjectClass = "";
            baseObjectClass += "using DevExpress.Xpo;" + Environment.NewLine;
            baseObjectClass += "using System;" + Environment.NewLine;
            baseObjectClass += "using System.Collections.Generic;" + Environment.NewLine;
            baseObjectClass += "using System.Linq;" + Environment.NewLine;
            baseObjectClass += "using System.Text;" + Environment.NewLine;
            baseObjectClass += "using System.Threading.Tasks;" + Environment.NewLine;
            baseObjectClass += "" + Environment.NewLine;
            baseObjectClass += "namespace " + projectNameRoot + "." + AppConsts.DBModelsProjectName + "." + AppConsts.DBModelsEntitiesFolderName + Environment.NewLine;
            baseObjectClass += "{" + Environment.NewLine;
            baseObjectClass += "    [NonPersistent]" + Environment.NewLine;
            baseObjectClass += "    public class "+AppConsts.DBModelsBaseObjectClassName+" : XPBaseObject" + Environment.NewLine;
            baseObjectClass += "    {" + Environment.NewLine;
            baseObjectClass += "" + Environment.NewLine;
            baseObjectClass += "        public "+AppConsts.DBModelsBaseObjectClassName+"(Session session) : base(session)" + Environment.NewLine;
            baseObjectClass += "        {" + Environment.NewLine;
            baseObjectClass += "" + Environment.NewLine;
            baseObjectClass += "        }" + Environment.NewLine;
            baseObjectClass += "" + Environment.NewLine;
            baseObjectClass += "        public override void AfterConstruction()" + Environment.NewLine;
            baseObjectClass += "        {" + Environment.NewLine;
            baseObjectClass += "            base.AfterConstruction();" + Environment.NewLine;
            baseObjectClass += "            CreatedTime = DateTime.Now;" + Environment.NewLine;
            baseObjectClass += "        }" + Environment.NewLine;
            baseObjectClass += "" + Environment.NewLine;
            baseObjectClass += "        [Persistent(\"oid\")]" + Environment.NewLine;
            baseObjectClass += "        [Key(true)]" + Environment.NewLine;
            baseObjectClass += "        public long Oid { get; set; }" + Environment.NewLine;
            baseObjectClass += "" + Environment.NewLine;
            baseObjectClass += "        [Persistent(\"created_time\")]" + Environment.NewLine;
            baseObjectClass += "        public DateTime CreatedTime { get; set; }" + Environment.NewLine;
            baseObjectClass += "" + Environment.NewLine;
            baseObjectClass += "        [Persistent(\"last_update_time\")]" + Environment.NewLine;
            baseObjectClass += "        public DateTime? LastUpdateTime { get; set; }" + Environment.NewLine;
            baseObjectClass += "    }" + Environment.NewLine;
            baseObjectClass += "}" + Environment.NewLine;

            bool createBaseObjectClassResult = FileHelperManager.Instance.WriteFile(projectPath, projectNameRoot + "." + AppConsts.DBModelsProjectName + "/" + AppConsts.DBModelsEntitiesFolderName, AppConsts.DBModelsBaseObjectClassFileName, baseObjectClass);


            return response;
        }


        public bool GeneratXpoMnaagerClass(string projectNameRoot, string projectPath)
        {
            bool response = false;

            string xpoManagerClass = "";
            xpoManagerClass += "using DevExpress.Xpo.DB;" + Environment.NewLine;
            xpoManagerClass += "using DevExpress.Xpo.Metadata;" + Environment.NewLine;
            xpoManagerClass += "using DevExpress.Xpo;" + Environment.NewLine;
            xpoManagerClass += "using System.Reflection;" + Environment.NewLine;
            xpoManagerClass += "using System;" + Environment.NewLine;
            xpoManagerClass += "using System.Collections.Generic;" + Environment.NewLine;
            xpoManagerClass += "using System.Linq;" + Environment.NewLine;
            xpoManagerClass += "using System.Text;" + Environment.NewLine;
            xpoManagerClass += "using System.Threading.Tasks;" + Environment.NewLine;
            xpoManagerClass += "using "+projectNameRoot+"."+AppConsts.DBModelsProjectName+"."+AppConsts.DBModelsEntitiesFolderName+";" + Environment.NewLine;
            xpoManagerClass += "using Pavolle.Core.Utils;" + Environment.NewLine;
            xpoManagerClass += "" + Environment.NewLine;
            xpoManagerClass += "namespace " + projectNameRoot + "." + AppConsts.DBModelsProjectName + Environment.NewLine;
            xpoManagerClass += "{" + Environment.NewLine;
            xpoManagerClass += "    public class " + AppConsts.DBModelsXpoManagerClassName + " : Singleton<"+AppConsts.DBModelsXpoManagerClassName+">" + Environment.NewLine;
            xpoManagerClass += "    {" + Environment.NewLine;
            xpoManagerClass += "        private string _connectionString;" + Environment.NewLine;
            xpoManagerClass += "        public string ConnectionString" + Environment.NewLine;
            xpoManagerClass += "        {" + Environment.NewLine;
            xpoManagerClass += "            get { return _connectionString; }" + Environment.NewLine;
            xpoManagerClass += "        }" + Environment.NewLine;
            xpoManagerClass += "" + Environment.NewLine;
            xpoManagerClass += "        private readonly object LockObject = new object();" + Environment.NewLine;
            xpoManagerClass += "" + Environment.NewLine;
            xpoManagerClass += "        private "+AppConsts.DBModelsXpoManagerClassName+"()" + Environment.NewLine;
            xpoManagerClass += "        {" + Environment.NewLine;
            xpoManagerClass += "        }" + Environment.NewLine;
            xpoManagerClass += "" + Environment.NewLine;
            xpoManagerClass += "        public void InitXpo(String connectionString)" + Environment.NewLine;
            xpoManagerClass += "        {" + Environment.NewLine;
            xpoManagerClass += "            _connectionString = connectionString;" + Environment.NewLine;
            xpoManagerClass += "            SetDataLayer();" + Environment.NewLine;
            xpoManagerClass += "        }" + Environment.NewLine;
            xpoManagerClass += "" + Environment.NewLine;
            xpoManagerClass += "        public Session GetNewSession()" + Environment.NewLine;
            xpoManagerClass += "        {" + Environment.NewLine;
            xpoManagerClass += "            var session = new Session(DataLayer);" + Environment.NewLine;
            xpoManagerClass += "            return session;" + Environment.NewLine;
            xpoManagerClass += "        }" + Environment.NewLine;
            xpoManagerClass += "" + Environment.NewLine;
            xpoManagerClass += "        private volatile IDataLayer _fDataLayer;" + Environment.NewLine;
            xpoManagerClass += "" + Environment.NewLine;
            xpoManagerClass += "        private IDataLayer DataLayer" + Environment.NewLine;
            xpoManagerClass += "        {" + Environment.NewLine;
            xpoManagerClass += "            get" + Environment.NewLine;
            xpoManagerClass += "            {" + Environment.NewLine;
            xpoManagerClass += "                SetDataLayer();" + Environment.NewLine;
            xpoManagerClass += "                return _fDataLayer;" + Environment.NewLine;
            xpoManagerClass += "            }" + Environment.NewLine;
            xpoManagerClass += "        }" + Environment.NewLine;
            xpoManagerClass += "" + Environment.NewLine;
            xpoManagerClass += "        public XPClassInfo GetClassInfo(Type t)" + Environment.NewLine;
            xpoManagerClass += "        {" + Environment.NewLine;
            xpoManagerClass += "            return DataLayer.Dictionary.GetClassInfo(t);" + Environment.NewLine;
            xpoManagerClass += "        }" + Environment.NewLine;
            xpoManagerClass += "" + Environment.NewLine;
            xpoManagerClass += "        private void SetDataLayer()" + Environment.NewLine;
            xpoManagerClass += "        {" + Environment.NewLine;
            xpoManagerClass += "            if (_fDataLayer == null)" + Environment.NewLine;
            xpoManagerClass += "            {" + Environment.NewLine;
            xpoManagerClass += "                lock (LockObject)" + Environment.NewLine;
            xpoManagerClass += "                {" + Environment.NewLine;
            xpoManagerClass += "                    if (_fDataLayer == null)" + Environment.NewLine;
            xpoManagerClass += "                    {" + Environment.NewLine;
            xpoManagerClass += "                        _fDataLayer = GetDataLayer();" + Environment.NewLine;
            xpoManagerClass += "                    }" + Environment.NewLine;
            xpoManagerClass += "                }" + Environment.NewLine;
            xpoManagerClass += "            }" + Environment.NewLine;
            xpoManagerClass += "        }" + Environment.NewLine;
            xpoManagerClass += "" + Environment.NewLine;
            xpoManagerClass += "        public void SetDataLayer(IDataLayer dataLayer)" + Environment.NewLine;
            xpoManagerClass += "        {" + Environment.NewLine;
            xpoManagerClass += "            _fDataLayer = dataLayer;" + Environment.NewLine;
            xpoManagerClass += "        }" + Environment.NewLine;
            xpoManagerClass += "" + Environment.NewLine;
            xpoManagerClass += "        private IDataLayer GetDataLayer()" + Environment.NewLine;
            xpoManagerClass += "        {" + Environment.NewLine;
            xpoManagerClass += "            IDataLayer dl = null;" + Environment.NewLine;
            xpoManagerClass += "" + Environment.NewLine;
            xpoManagerClass += "            if (!string.IsNullOrEmpty(_connectionString))" + Environment.NewLine;
            xpoManagerClass += "            {" + Environment.NewLine;
            xpoManagerClass += "                XpoDefault.Session = null;" + Environment.NewLine;
            xpoManagerClass += "                XPDictionary dict = new ReflectionDictionary();" + Environment.NewLine;
            xpoManagerClass += "                string connectionPoolString = XpoDefault.GetConnectionPoolString(_connectionString, 30, 500);" + Environment.NewLine;
            xpoManagerClass += "                IDataStore store = XpoDefault.GetConnectionProvider(connectionPoolString, AutoCreateOption.DatabaseAndSchema);" + Environment.NewLine;
            xpoManagerClass += "                dict.GetDataStoreSchema(typeof(BaseObject).Assembly);" + Environment.NewLine;
            xpoManagerClass += "                dl = new ThreadSafeDataLayer(dict, store);" + Environment.NewLine;
            xpoManagerClass += "                Session newSession = new Session(dl);" + Environment.NewLine;
            xpoManagerClass += "                Assembly executingAssembly = Assembly.GetExecutingAssembly();" + Environment.NewLine;
            xpoManagerClass += "                Type[] array = executingAssembly.GetTypes().Where(t => t.IsSubclassOf(typeof(BaseObject))).ToArray();" + Environment.NewLine;
            xpoManagerClass += "                newSession.UpdateSchema(array);" + Environment.NewLine;
            xpoManagerClass += "            }" + Environment.NewLine;
            xpoManagerClass += "" + Environment.NewLine;
            xpoManagerClass += "            return dl;" + Environment.NewLine;
            xpoManagerClass += "        }" + Environment.NewLine;
            xpoManagerClass += "    }" + Environment.NewLine;
            xpoManagerClass += "}" + Environment.NewLine;

            bool createBaseObjectClassResult = FileHelperManager.Instance.WriteFile(projectPath, projectNameRoot + "." + AppConsts.DBModelsProjectName, AppConsts.DBModelsXpoManagerClassFileName, xpoManagerClass);


            return response;
        }
    }
}
