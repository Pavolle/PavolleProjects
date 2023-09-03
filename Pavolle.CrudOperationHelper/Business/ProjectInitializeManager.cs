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

        public bool Start(string projectName, string projectNameRoot, string projectPath, string userType, string issuer, string audience, int tokenExpireHour, string language)
        {
            //TODO Öncesinde projeye kütüphane ve bağlantıları ekleyeceğiz.
            GenerateDbModels(projectName, projectNameRoot, projectPath, userType, language); //ok
            //TODO Auth Manager sınıfı eklenecek.
            GenerateWebSecurityLayer(projectName, projectNameRoot, projectPath, issuer, audience, tokenExpireHour); //Ok

            GenerateBaseViewModelsClass(projectName, projectNameRoot, projectPath);

            GenerateControllerAndBusiness(projectNameRoot, projectPath, projectName);

            GenerateOrganizationBusiness(projectNameRoot, projectPath);

            GenerateUserBusiness(projectNameRoot, projectPath);
            GenerateSystemSettingBusiness(projectNameRoot, projectPath);
            GenerateScheduleBusiness(projectNameRoot, projectPath);
            GenerateUserSessionBusiness(projectNameRoot, projectPath);
            GenerateLoginBusiness(projectNameRoot, projectPath);
            GenerateSetupManager(projectNameRoot, projectPath);

            return true;
        }

        private void GenerateBaseViewModelsClass(string projectName, string projectNameRoot, string projectPath)
        {
            //Bu kısım da core'de olması lazım.
            string viewDataBaseClass = "";
            viewDataBaseClass += "using Pavolle.Core.ViewModels.ViewData;" + Environment.NewLine;
            viewDataBaseClass += "namespace " + projectNameRoot + "." + AppConsts.ViewModelsProjectName + "." + AppConsts.ViewModelsViewDataFolderName + Environment.NewLine;
            viewDataBaseClass += "{" + Environment.NewLine;
            viewDataBaseClass += "    public class " + projectName + AppConsts.ViewModelsViewDataBaseClassName +" : ViewDataBase" + Environment.NewLine;
            viewDataBaseClass += "    {" + Environment.NewLine;
            viewDataBaseClass += "    }" + Environment.NewLine;
            viewDataBaseClass += "}" + Environment.NewLine;

            bool createResult = FileHelperManager.Instance.WriteFile(projectPath, projectNameRoot + "." + AppConsts.ViewModelsProjectName + "/" + AppConsts.ViewModelsViewDataFolderName, projectName + AppConsts.ViewModelsViewDataBaseClassName + ".cs", viewDataBaseClass);


            string requestBaseClass = "";
            requestBaseClass += "using Pavolle.Core.ViewModels.Request;" + Environment.NewLine;
            requestBaseClass += "using "+projectNameRoot+"."+AppConsts.CommonProjectName+"."+AppConsts.CommonEnumFolderName+";" + Environment.NewLine;
            requestBaseClass += "" + Environment.NewLine;
            requestBaseClass += "namespace " + projectNameRoot + "." + AppConsts.ViewModelsProjectName + "." + AppConsts.ViewModelsRequestFolderName + Environment.NewLine;
            requestBaseClass += "{" + Environment.NewLine;
            requestBaseClass += "    public class " + projectName + AppConsts.ViewModelsRequestBaseClassName + ":RequestBase" + Environment.NewLine;
            requestBaseClass += "    {" + Environment.NewLine;
            requestBaseClass += "" + Environment.NewLine;
            requestBaseClass += "        public string? Username { get; set; }" + Environment.NewLine;
            requestBaseClass += "" + Environment.NewLine;
            requestBaseClass += "        public "+AppConsts.UserTypeEnumClassName+"? UserType { get; set; }" + Environment.NewLine;
            requestBaseClass += "" + Environment.NewLine;
            requestBaseClass += "        public long? UserGroupOid { get; set; }" + Environment.NewLine;
            requestBaseClass += "" + Environment.NewLine;
            requestBaseClass += "        public string? SessionId { get; set; }" + Environment.NewLine;
            requestBaseClass += "" + Environment.NewLine;
            requestBaseClass += "    }" + Environment.NewLine;
            requestBaseClass += "}" + Environment.NewLine;

            createResult = FileHelperManager.Instance.WriteFile(projectPath, projectNameRoot + "." + AppConsts.ViewModelsProjectName + "/" + AppConsts.ViewModelsRequestFolderName, projectName + AppConsts.ViewModelsRequestBaseClassName + ".cs", requestBaseClass);


            string responseBaseClass = "";
            responseBaseClass += "using Pavolle.Core.ViewModels.Response;" + Environment.NewLine;
            responseBaseClass += "namespace "+projectNameRoot+"."+AppConsts.ViewModelsProjectName+"."+AppConsts.ViewModelsResponseFolderName+"" + Environment.NewLine;
            responseBaseClass += "{" + Environment.NewLine;
            responseBaseClass += "    public class "+projectName+AppConsts.ViewModelsResponseBaseClassName +":" +"ResponseBase" + Environment.NewLine;
            responseBaseClass += "    {" + Environment.NewLine;
            responseBaseClass += "    }" + Environment.NewLine;
            responseBaseClass += "}" + Environment.NewLine;

            createResult = FileHelperManager.Instance.WriteFile(projectPath, projectNameRoot + "." + AppConsts.ViewModelsProjectName + "/" + AppConsts.ViewModelsResponseFolderName, projectName + AppConsts.ViewModelsResponseBaseClassName + ".cs", responseBaseClass);

            string criteriaBaseClass = "";
            criteriaBaseClass += "using "+projectNameRoot+"."+AppConsts.ViewModelsProjectName+"."+AppConsts.ViewModelsRequestFolderName+";" +Environment.NewLine;
            criteriaBaseClass += "";
            criteriaBaseClass += "namespace " + projectNameRoot + "." + AppConsts.ViewModelsProjectName + "." + AppConsts.ViewModelsCriteriaFolderName + Environment.NewLine;
            criteriaBaseClass += "{" + Environment.NewLine;
            criteriaBaseClass += "    public class "+projectName+"CriteriaBase:"+projectName+"RequestBase" + Environment.NewLine;
            criteriaBaseClass += "    {" + Environment.NewLine;
            criteriaBaseClass += "    }" + Environment.NewLine;
            criteriaBaseClass += "}" + Environment.NewLine;

            createResult = FileHelperManager.Instance.WriteFile(projectPath, projectNameRoot + "." + AppConsts.ViewModelsProjectName + "/" + AppConsts.ViewModelsCriteriaFolderName, projectName + AppConsts.ViewModelsCriteriaBaseClassName + ".cs", criteriaBaseClass);
        }

        private void GenerateControllerAndBusiness(string projectNameRoot, string projectPath, string projectName)
        {
            GenerateLoginClasses(projectNameRoot, projectPath, projectName);
        }

        private void GenerateLoginClasses(string projectNameRoot, string projectPath, string projectName)
        {
            string controller = "";
            controller += "using Microsoft.AspNetCore.Mvc;" + Environment.NewLine;
            controller += "using " + projectNameRoot + ".Business.Manager;" + Environment.NewLine;
            controller += "using " + projectNameRoot + ".Common.Utils;" + Environment.NewLine;
            controller += "using " + projectNameRoot + ".ViewModels.Request;" + Environment.NewLine;
            controller += "" + Environment.NewLine;
            controller += "namespace " + projectNameRoot + ".WebApp.Controllers" + Environment.NewLine;
            controller += "{" + Environment.NewLine;
            controller += "    [Produces(\"application/json\")]" + Environment.NewLine;
            controller += "    [Route("+projectName+"ApiUrlConsts.LoginRouteConsts.Route)]" + Environment.NewLine;
            controller += "    public class LoginController : Controller" + Environment.NewLine;
            controller += "    {" + Environment.NewLine;
            controller += "" + Environment.NewLine;
            controller += "        [HttpPost(MessageServiceApiUrlConsts.LoginRouteConsts.SignInRoutePrefix)]" + Environment.NewLine;
            controller += "        public ActionResult SignIn([FromBody] LoginRequest request)" + Environment.NewLine;
            controller += "        {" + Environment.NewLine;
            controller += "            return Ok(LoginManager.Instance.SignIn(request));" + Environment.NewLine;
            controller += "        }" + Environment.NewLine;
            controller += "" + Environment.NewLine;
            controller += "        [HttpPost(MessageServiceApiUrlConsts.LoginRouteConsts.SignOutRoutePrefix)]" + Environment.NewLine;
            controller += "        public ActionResult SignOut(MessageServiceRequestBase request)" + Environment.NewLine;
            controller += "        {" + Environment.NewLine;
            controller += "            return Ok(LoginManager.Instance.SignOut(request));" + Environment.NewLine;
            controller += "        }" + Environment.NewLine;
            controller += "" + Environment.NewLine;
            controller += "        [HttpPost(MessageServiceApiUrlConsts.LoginRouteConsts.ForgotPaswordRoutePrefix)]" + Environment.NewLine;
            controller += "        public ActionResult ForgotPasword([FromBody]ForgotPasswordRequest request)" + Environment.NewLine;
            controller += "        {" + Environment.NewLine;
            controller += "            return Ok(LoginManager.Instance.ForgotPasword(request));" + Environment.NewLine;
            controller += "        }" + Environment.NewLine;
            controller += "" + Environment.NewLine;
            controller += "        [HttpPost(MessageServiceApiUrlConsts.LoginRouteConsts.VerifyCodeRoutePrefix)]" + Environment.NewLine;
            controller += "        public ActionResult VerifyCode([FromBody] VerifyCodeRequest request)" + Environment.NewLine;
            controller += "        {" + Environment.NewLine;
            controller += "            return Ok(LoginManager.Instance.VerifyCode(request));" + Environment.NewLine;
            controller += "        }" + Environment.NewLine;
            controller += "" + Environment.NewLine;
            controller += "        [HttpPost(MessageServiceApiUrlConsts.LoginRouteConsts.ResetPaswordRoutePrefix)]" + Environment.NewLine;
            controller += "        public ActionResult ResetPassword([FromBody] ResetPasswordRequest request)" + Environment.NewLine;
            controller += "        {" + Environment.NewLine;
            controller += "            return Ok(LoginManager.Instance.ResetPassword(request));" + Environment.NewLine;
            controller += "        }" + Environment.NewLine;
            controller += "    }" + Environment.NewLine;
            controller += "}" + Environment.NewLine;


        }

        private void GenerateDbModels(string projectName, string projectNameRoot, string projectPath, string userType, string language)
        {
            InitiliazeDbModelsCsProject(projectNameRoot, projectPath, projectName);
            GenerateBaseObject(projectNameRoot, projectPath); //Ok
            GeneratXpoManagerClass(projectNameRoot, projectPath); //Ok
            GenerateUserSessionClass(projectNameRoot, projectPath); //Ok
            GenerateTranslateDataClass(projectNameRoot, projectPath, language);//Ok
            GenerateCountryClass(projectNameRoot, projectPath);
            GenerateCityClass(projectNameRoot, projectPath);
            GenerateOrganizationClass(projectNameRoot, projectPath);
            GenerateSystemSettingsClass(projectNameRoot, projectPath);
            GenerateSchedulerClass(projectNameRoot, projectPath);
            GenerateUserClass(projectNameRoot, projectPath);
            GenerateAuthClassess(projectNameRoot, projectPath, userType);
        }

        private void GenerateOrganizationClass(string projectNameRoot, string projectPath)
        {
            string dbClass = "";
            dbClass += "using DevExpress.Xpo;" + Environment.NewLine;
            dbClass += "" + Environment.NewLine;
            dbClass += "namespace " + projectNameRoot + "." + AppConsts.DBModelsProjectName + "." + AppConsts.DBModelsEntitiesFolderName + Environment.NewLine;
            dbClass += "{" + Environment.NewLine;
            dbClass += "" + Environment.NewLine;
            dbClass += "    [Persistent(\"organizations\")]" + Environment.NewLine;
            dbClass += "    public class " + AppConsts.DBModelsOrganizationClassName + " : " + AppConsts.DBModelsBaseObjectClassName + Environment.NewLine;
            dbClass += "    {" + Environment.NewLine;
            dbClass += "" + Environment.NewLine;
            dbClass += "        public " + AppConsts.DBModelsOrganizationClassName + "(Session session) : base(session)" + Environment.NewLine;
            dbClass += "        {" + Environment.NewLine;
            dbClass += "        }" + Environment.NewLine;
            dbClass += "" + Environment.NewLine;
            dbClass += "        [Persistent(\"name\")]" + Environment.NewLine;
            dbClass += "        [Size(1000)]" + Environment.NewLine;
            dbClass += "        public string Name { get; set; }" + Environment.NewLine;
            dbClass += "" + Environment.NewLine;
            dbClass += "        [Persistent(\"code\")]" + Environment.NewLine;
            dbClass += "        [Size(5)]" + Environment.NewLine;
            dbClass += "        public string Code { get; set; }" + Environment.NewLine;
            dbClass += "" + Environment.NewLine;
            dbClass += "        [Persistent(\"address\")]" + Environment.NewLine;
            dbClass += "        [Size(1000)]" + Environment.NewLine;
            dbClass += "        public string Address { get; set; }" + Environment.NewLine;
            dbClass += "" + Environment.NewLine;
            dbClass += "        [Persistent(\"langitude\")]" + Environment.NewLine;
            dbClass += "        public double? Langitude { get; set; }" + Environment.NewLine;
            dbClass += "" + Environment.NewLine;
            dbClass += "        [Persistent(\"latitude\")]" + Environment.NewLine;
            dbClass += "        public double? Latitude { get; set; }" + Environment.NewLine;
            dbClass += "" + Environment.NewLine;
            dbClass += "        [Persistent(\"upper_organization_oid\")]" + Environment.NewLine;
            dbClass += "        public Organization UpperOrganization { get; set; }" + Environment.NewLine;
            dbClass += "" + Environment.NewLine;
            dbClass += "        [Persistent(\"country_oid\")]" + Environment.NewLine;
            dbClass += "        public Country Country { get; set; }" + Environment.NewLine;
            dbClass += "" + Environment.NewLine;
            dbClass += "        [Persistent(\"city_oid\")]" + Environment.NewLine;
            dbClass += "        public City City { get; set; }" + Environment.NewLine;
            dbClass += "" + Environment.NewLine;
            dbClass += "        [Persistent(\"zip_code\")]" + Environment.NewLine;
            dbClass += "        [Size(20)]" + Environment.NewLine;
            dbClass += "        public string ZipCode { get; set; }" + Environment.NewLine;
            dbClass += "    }" + Environment.NewLine;
            dbClass += "}" + Environment.NewLine;
            bool createResult = FileHelperManager.Instance.WriteFile(projectPath, projectNameRoot + "." + AppConsts.DBModelsProjectName + "/" + AppConsts.DBModelsEntitiesFolderName, AppConsts.DBModelsOrganizationClassFileName, dbClass);
        }

        private void GenerateCityClass(string projectNameRoot, string projectPath)
        {
            string dbClass = "";
            dbClass += "using DevExpress.Xpo;" + Environment.NewLine;
            dbClass += "" + Environment.NewLine;
            dbClass += "namespace " + projectNameRoot + "." + AppConsts.DBModelsProjectName + "." + AppConsts.DBModelsEntitiesFolderName + Environment.NewLine;
            dbClass += "{" + Environment.NewLine;
            dbClass += "" + Environment.NewLine;
            dbClass += "    [Persistent(\"cities\")]" + Environment.NewLine;
            dbClass += "    public class " + AppConsts.DBModelsCityClassName + " : " + AppConsts.DBModelsBaseObjectClassName + Environment.NewLine;
            dbClass += "    {" + Environment.NewLine;
            dbClass += "" + Environment.NewLine;
            dbClass += "        public " + AppConsts.DBModelsCityClassName + "(Session session) : base(session)" + Environment.NewLine;
            dbClass += "        {" + Environment.NewLine;
            dbClass += "        }" + Environment.NewLine;
            dbClass += "" + Environment.NewLine;
            dbClass += "        [Persistent(\"code\")]" + Environment.NewLine;
            dbClass += "        [Size(20)]" + Environment.NewLine;
            dbClass += "        public string Code { get; set; }" + Environment.NewLine;
            dbClass += "" + Environment.NewLine;
            dbClass += "        [Persistent(\"country_oid\")]" + Environment.NewLine;
            dbClass += "        public Country Country { get; set; }" + Environment.NewLine;
            dbClass += "" + Environment.NewLine;
            dbClass += "        [Persistent(\"name_td_oid\")]" + Environment.NewLine;
            dbClass += "        public "+AppConsts.DBModelsTranslateDataClassName+" Name { get; set; }" + Environment.NewLine;
            dbClass += "    }" + Environment.NewLine;
            dbClass += "}" + Environment.NewLine;
            bool createResult = FileHelperManager.Instance.WriteFile(projectPath, projectNameRoot + "." + AppConsts.DBModelsProjectName + "/" + AppConsts.DBModelsEntitiesFolderName, AppConsts.DBModelsCityClassFileName, dbClass);
        }

        private void GenerateCountryClass(string projectNameRoot, string projectPath)
        {
            string dbClass = "";
            dbClass += "using DevExpress.Xpo;" + Environment.NewLine;
            dbClass += "" + Environment.NewLine;
            dbClass += "namespace "+projectNameRoot+"."+AppConsts.DBModelsProjectName+"."+AppConsts.DBModelsEntitiesFolderName + Environment.NewLine;
            dbClass += "{" + Environment.NewLine;
            dbClass += "" + Environment.NewLine;
            dbClass += "    [Persistent(\"countries\")]" + Environment.NewLine;
            dbClass += "    public class " + AppConsts.DBModelsCountryClassName + " : " + AppConsts.DBModelsBaseObjectClassName + Environment.NewLine;
            dbClass += "    {" + Environment.NewLine;
            dbClass += "" + Environment.NewLine;
            dbClass += "        public "+AppConsts.DBModelsCountryClassName+"(Session session) : base(session)" + Environment.NewLine;
            dbClass += "        {" + Environment.NewLine;
            dbClass += "        }" + Environment.NewLine;
            dbClass += "" + Environment.NewLine;
            dbClass += "        [Persistent(\"iso2\")]" + Environment.NewLine;
            dbClass += "        [Size(2)]" + Environment.NewLine;
            dbClass += "        public string ISOCode2 { get; set; }" + Environment.NewLine;
            dbClass += "" + Environment.NewLine;
            dbClass += "        [Persistent(\"iso3\")]" + Environment.NewLine;
            dbClass += "        [Size(3)]" + Environment.NewLine;
            dbClass += "        public string ISOCode3 { get; set; }" + Environment.NewLine;
            dbClass += "" + Environment.NewLine;
            dbClass += "        [Persistent(\"phone_code\")]" + Environment.NewLine;
            dbClass += "        [Size(30)]" + Environment.NewLine;
            dbClass += "        public string PhoneCode { get; set; }" + Environment.NewLine;
            dbClass += "" + Environment.NewLine;
            dbClass += "        [Persistent(\"name_td_oid\")]" + Environment.NewLine;
            dbClass += "        public "+AppConsts.DBModelsTranslateDataClassName+" Name { get; set; }" + Environment.NewLine;
            dbClass += "    }" + Environment.NewLine;
            dbClass += "}" + Environment.NewLine;
            bool createResult = FileHelperManager.Instance.WriteFile(projectPath, projectNameRoot + "." + AppConsts.DBModelsProjectName + "/" + AppConsts.DBModelsEntitiesFolderName, AppConsts.DBModelsCountryClassFileName, dbClass);
        }

        private void InitiliazeDbModelsCsProject(string projectNameRoot, string projectPath, string projectName)
        {
            string dbModelscsproj = "";
            dbModelscsproj += "<Project Sdk=\"Microsoft.NET.Sdk\">" + Environment.NewLine;
            dbModelscsproj += "" + Environment.NewLine;
            dbModelscsproj += "  <PropertyGroup>" + Environment.NewLine;
            dbModelscsproj += "    <TargetFramework>net6.0</TargetFramework>" + Environment.NewLine;
            dbModelscsproj += "    <ImplicitUsings>enable</ImplicitUsings>" + Environment.NewLine;
            dbModelscsproj += "    <Nullable>enable</Nullable>" + Environment.NewLine;
            dbModelscsproj += "  </PropertyGroup>" + Environment.NewLine;
            dbModelscsproj += "" + Environment.NewLine;
            dbModelscsproj += "  <ItemGroup>" + Environment.NewLine;
            dbModelscsproj += "    <PackageReference Include=\"DevExpress.Xpo\" Version=\"23.1.3\" />" + Environment.NewLine;
            dbModelscsproj += "  </ItemGroup>" + Environment.NewLine;
            dbModelscsproj += "" + Environment.NewLine;
            dbModelscsproj += "  <ItemGroup>" + Environment.NewLine;
            dbModelscsproj += "    <ProjectReference Include=\"..\\"+projectNameRoot+"."+AppConsts.CommonProjectName+"\\"+projectNameRoot+"."+AppConsts.CommonProjectName+".csproj\" />" + Environment.NewLine;
            dbModelscsproj += "    <ProjectReference Include=\"..\\Pavolle.Core\\Pavolle.Core.csproj\" />" + Environment.NewLine;
            dbModelscsproj += "  </ItemGroup>" + Environment.NewLine;
            dbModelscsproj += "" + Environment.NewLine;
            dbModelscsproj += "</Project>" + Environment.NewLine;

            bool createcsprojResult = FileHelperManager.Instance.EditFile(projectPath, projectNameRoot + "." + AppConsts.DBModelsProjectName, projectNameRoot + "." + AppConsts.DBModelsProjectName + ".csproj", dbModelscsproj);
        }

        private void GenerateUserClass(string projectNameRoot, string projectPath)
        {
            string userClass = "";
            userClass += "using DevExpress.Xpo;" + Environment.NewLine;
            userClass += "using " + projectNameRoot + "." + AppConsts.CommonProjectName + "." + AppConsts.CommonEnumFolderName + ";" + Environment.NewLine;
            userClass += "" + Environment.NewLine;
            userClass += "namespace " + projectNameRoot + "." + AppConsts.DBModelsProjectName + "." + AppConsts.DBModelsEntitiesFolderName + Environment.NewLine;
            userClass += "{" + Environment.NewLine;
            userClass += "    [Persistent(\"users\")]" + Environment.NewLine;
            userClass += "    public class "+AppConsts.DBModelsUserClassName+" : "+AppConsts.DBModelsBaseObjectClassName + Environment.NewLine;
            userClass += "    {" + Environment.NewLine;
            userClass += "" + Environment.NewLine;
            userClass += "        public "+AppConsts.DBModelsUserClassName+"(Session session) : base(session)" + Environment.NewLine;
            userClass += "        {" + Environment.NewLine;
            userClass += "        }" + Environment.NewLine;
            userClass += "" + Environment.NewLine;
            userClass += "        [Persistent(\"organization_oid\")]" + Environment.NewLine;
            userClass += "        public Organization Organization { get; set; }" + Environment.NewLine;
            userClass += "" + Environment.NewLine;
            userClass += "        [Persistent(\"username\")]" + Environment.NewLine;
            userClass += "        [Size(50)]" + Environment.NewLine;
            userClass += "        [Indexed(Name = \"index_users_username\", Unique = true)]" + Environment.NewLine;
            userClass += "        public string Username { get; set; }" + Environment.NewLine;
            userClass += "" + Environment.NewLine;
            userClass += "        [Persistent(\"user_type\")]" + Environment.NewLine;
            userClass += "        public EUserType UserType { get; set; }" + Environment.NewLine;
            userClass += "" + Environment.NewLine;
            userClass += "        [Persistent(\"name\")]" + Environment.NewLine;
            userClass += "        [Size(255)]" + Environment.NewLine;
            userClass += "        public string Name { get; set; }" + Environment.NewLine;
            userClass += "" + Environment.NewLine;
            userClass += "        [Persistent(\"surname\")]" + Environment.NewLine;
            userClass += "        [Size(255)]" + Environment.NewLine;
            userClass += "        public string Surname { get; set; }" + Environment.NewLine;
            userClass += "" + Environment.NewLine;
            userClass += "        [Persistent(\"email\")]" + Environment.NewLine;
            userClass += "        [Size(255)]" + Environment.NewLine;
            userClass += "        public string Email { get; set; }" + Environment.NewLine;
            userClass += "" + Environment.NewLine;
            userClass += "        [Persistent(\"phone_number\")]" + Environment.NewLine;
            userClass += "        [Size(50)]" + Environment.NewLine;
            userClass += "        public string PhoneNumber { get; set; }" + Environment.NewLine;
            userClass += "" + Environment.NewLine;
            userClass += "        [Persistent(\"password\")]" + Environment.NewLine;
            userClass += "        [Size(1000)]" + Environment.NewLine;
            userClass += "        public string Password { get; set; }" + Environment.NewLine;
            userClass += "" + Environment.NewLine;
            userClass += "        [Persistent(\"wrong_try_count\")]" + Environment.NewLine;
            userClass += "        public int WrongTryCount { get; set; }" + Environment.NewLine;
            userClass += "" + Environment.NewLine;
            userClass += "        [Persistent(\"is_locked\")]" + Environment.NewLine;
            userClass += "        public bool IsLocked { get; set; }" + Environment.NewLine;
            userClass += "" + Environment.NewLine;
            userClass += "        [Persistent(\"code\")]" + Environment.NewLine;
            userClass += "        [Size(10)]" + Environment.NewLine;
            userClass += "        public string Code { get; set; }" + Environment.NewLine;
            userClass += "    }" + Environment.NewLine;
            userClass += "}" + Environment.NewLine;

            bool createResult = FileHelperManager.Instance.WriteFile(projectPath, projectNameRoot + "." + AppConsts.DBModelsProjectName + "/" + AppConsts.DBModelsEntitiesFolderName, AppConsts.DBModelsUserClassFileName, userClass);
        }

        private void GenerateTranslateDataClass(string projectNameRoot, string projectPath, string language)
        {
            string[] _languages = language.Split(',');
            string translateDataClass = "";
            translateDataClass += "using DevExpress.Xpo;" + Environment.NewLine;
            translateDataClass += "" + Environment.NewLine;
            translateDataClass += "namespace "+projectNameRoot+"."+AppConsts.DBModelsProjectName+"." +AppConsts.DBModelsEntitiesFolderName + Environment.NewLine;
            translateDataClass += "{" + Environment.NewLine;
            translateDataClass += "    [Persistent(\"translate_datas\")]" + Environment.NewLine;
            translateDataClass += "    public class "+AppConsts.DBModelsTranslateDataClassName+" : "+AppConsts.DBModelsBaseObjectClassName + Environment.NewLine;
            translateDataClass += "    {" + Environment.NewLine;
            translateDataClass += "        public "+AppConsts.DBModelsTranslateDataClassName+"(Session session) : base(session)" + Environment.NewLine;
            translateDataClass += "        {" + Environment.NewLine;
            translateDataClass += "        }" + Environment.NewLine;
            translateDataClass += "" + Environment.NewLine;
            translateDataClass += "        [Persistent(\"variable\")]" + Environment.NewLine;
            translateDataClass += "        [Size(1000)]" + Environment.NewLine;
            translateDataClass += "        public string Variable { get; set; }" + Environment.NewLine;
            translateDataClass += "" + Environment.NewLine;

            foreach (var item in _languages)
            {
                translateDataClass += "        [Persistent(\""+item.ToLower()+"\")]" + Environment.NewLine;
                translateDataClass += "        [Size(1000)]" + Environment.NewLine;
                translateDataClass += "        public string "+item.ToUpper()+" { get; set; }" + Environment.NewLine;
                translateDataClass += "" + Environment.NewLine;
            }
            translateDataClass += "    }" + Environment.NewLine;
            translateDataClass += "}" + Environment.NewLine;

            bool createResult = FileHelperManager.Instance.WriteFile(projectPath, projectNameRoot + "." + AppConsts.DBModelsProjectName + "/" + AppConsts.DBModelsEntitiesFolderName, AppConsts.DBModelsTranslateDataClassFileName, translateDataClass);
        }

        private void GenerateSchedulerClass(string projectNameRoot, string projectPath)
        {
            string schedulerTypeEnumClass = "";
            schedulerTypeEnumClass += "namespace " + projectNameRoot + "." + AppConsts.CommonProjectName + "." + AppConsts.CommonEnumFolderName + Environment.NewLine;
            schedulerTypeEnumClass += "{" + Environment.NewLine;
            schedulerTypeEnumClass += "    public enum "+ AppConsts.SchedulerTypeEnumClassName  + Environment.NewLine;
            schedulerTypeEnumClass += "    {" + Environment.NewLine;
            schedulerTypeEnumClass += "        CleanSession = 1," + Environment.NewLine;
            schedulerTypeEnumClass += "    }" + Environment.NewLine;
            schedulerTypeEnumClass += "}" + Environment.NewLine;

            bool createEnumClassResult = FileHelperManager.Instance.WriteFile(projectPath, projectNameRoot + "." + AppConsts.CommonProjectName + "/" + AppConsts.CommonEnumFolderName, AppConsts.SchedulerTypeEnumClassFileName, schedulerTypeEnumClass);


            string schedulerClass = "";
            schedulerClass += "using DevExpress.Xpo;" + Environment.NewLine;
            schedulerClass += "using "+projectNameRoot+"."+AppConsts.CommonProjectName+"."+AppConsts.CommonEnumFolderName+";" + Environment.NewLine;
            schedulerClass += "" + Environment.NewLine;
            schedulerClass += "namespace " + projectNameRoot + "." + AppConsts.DBModelsProjectName + "." + AppConsts.DBModelsEntitiesFolderName + Environment.NewLine;
            schedulerClass += "{" + Environment.NewLine;
            schedulerClass += "    [Persistent(\"schedulers\")]" + Environment.NewLine;
            schedulerClass += "    public class " + AppConsts.DBModelsSchedulerClassName + " : " + AppConsts.DBModelsBaseObjectClassName + Environment.NewLine;
            schedulerClass += "    {" + Environment.NewLine;
            schedulerClass += "" + Environment.NewLine;
            schedulerClass += "        public " + AppConsts.DBModelsSchedulerClassName + "(Session session) : base(session)" + Environment.NewLine;
            schedulerClass += "        {" + Environment.NewLine;
            schedulerClass += "        }" + Environment.NewLine;
            schedulerClass += "" + Environment.NewLine;
            schedulerClass += "        [Persistent(\"scheduler_type\")]" + Environment.NewLine;
            schedulerClass += "        public ESchedulerType SchedulerType { get; set; }" + Environment.NewLine;
            schedulerClass += "" + Environment.NewLine;
            schedulerClass += "        [Persistent(\"name\")]" + Environment.NewLine;
            schedulerClass += "        [Size(255)]" + Environment.NewLine;
            schedulerClass += "        public string Name { get; set; }" + Environment.NewLine;
            schedulerClass += "" + Environment.NewLine;
            schedulerClass += "        [Persistent(\"cron\")]" + Environment.NewLine;
            schedulerClass += "        [Size(30)]" + Environment.NewLine;
            schedulerClass += "        public string Cron { get; set; }" + Environment.NewLine;
            schedulerClass += "" + Environment.NewLine;
            schedulerClass += "        [Persistent(\"last_run_time\")]" + Environment.NewLine;
            schedulerClass += "        public DateTime LastRunTime { get; set; }" + Environment.NewLine;
            schedulerClass += "    }" + Environment.NewLine;
            schedulerClass += "}" + Environment.NewLine;
            bool schedulerClasssResult = FileHelperManager.Instance.WriteFile(projectPath, projectNameRoot + "." + AppConsts.DBModelsProjectName + "/" + AppConsts.DBModelsEntitiesFolderName, AppConsts.DBModelsSchedulerClassFileName, schedulerClass);


            string schedulerLogClass = "";
            schedulerLogClass += "using DevExpress.Xpo;" + Environment.NewLine;
            schedulerLogClass += "" + Environment.NewLine;
            schedulerLogClass += "namespace " + projectNameRoot + "." + AppConsts.DBModelsProjectName + "." + AppConsts.DBModelsEntitiesFolderName + Environment.NewLine;
            schedulerLogClass += "{" + Environment.NewLine;
            schedulerLogClass += "    [Persistent(\"scheduler_logs\")]" + Environment.NewLine;
            schedulerLogClass += "    public class " + AppConsts.DBModelsSchedulerLogClassName + " : " + AppConsts.DBModelsBaseObjectClassName + Environment.NewLine;
            schedulerLogClass += "    {" + Environment.NewLine;
            schedulerLogClass += "" + Environment.NewLine;
            schedulerLogClass += "        public " + AppConsts.DBModelsSchedulerLogClassName + "(Session session) : base(session)" + Environment.NewLine;
            schedulerLogClass += "        {" + Environment.NewLine;
            schedulerLogClass += "        }" + Environment.NewLine;
            schedulerLogClass += "" + Environment.NewLine;
            schedulerLogClass += "        [Persistent(\"scheduler_oid\")]" + Environment.NewLine;
            schedulerLogClass += "        public Scheduler Scheduler { get; set; }" + Environment.NewLine;
            schedulerLogClass += "" + Environment.NewLine;
            schedulerLogClass += "        [Persistent(\"start_time\")]" + Environment.NewLine;
            schedulerLogClass += "        public DateTime StartTime { get; set; }" + Environment.NewLine;
            schedulerLogClass += "" + Environment.NewLine;
            schedulerLogClass += "        [Persistent(\"end_time\")]" + Environment.NewLine;
            schedulerLogClass += "        public DateTime EndTime { get; set; }" + Environment.NewLine;
            schedulerLogClass += "" + Environment.NewLine;
            schedulerLogClass += "        [Persistent(\"success\")]" + Environment.NewLine;
            schedulerLogClass += "        public bool Success { get; set; }" + Environment.NewLine;
            schedulerLogClass += "" + Environment.NewLine;
            schedulerLogClass += "        [Persistent(\"result\")]" + Environment.NewLine;
            schedulerLogClass += "        [Size(1000)]" + Environment.NewLine;
            schedulerLogClass += "        public string Result { get; set; }" + Environment.NewLine;
            schedulerLogClass += "    }" + Environment.NewLine;
            schedulerLogClass += "}" + Environment.NewLine;

            schedulerClasssResult = FileHelperManager.Instance.WriteFile(projectPath, projectNameRoot + "." + AppConsts.DBModelsProjectName + "/" + AppConsts.DBModelsEntitiesFolderName, AppConsts.DBModelsSchedulerLogClassFileName, schedulerLogClass);
        }

        private void GenerateSystemSettingsClass(string projectNameRoot, string projectPath)
        {
            string settingTypeEnumClass = "";
            settingTypeEnumClass += "namespace " + projectNameRoot + "." + AppConsts.CommonProjectName + "." + AppConsts.CommonEnumFolderName + Environment.NewLine;
            settingTypeEnumClass += "{" + Environment.NewLine;
            settingTypeEnumClass += "    public enum " + AppConsts.SettingTypeEnumClassName + Environment.NewLine;
            settingTypeEnumClass += "    {" + Environment.NewLine;
            settingTypeEnumClass += "        SchedulerControlCron = 1," + Environment.NewLine;
            settingTypeEnumClass += "    }" + Environment.NewLine;
            settingTypeEnumClass += "}" + Environment.NewLine;

            bool createEnumClassResult = FileHelperManager.Instance.WriteFile(projectPath, projectNameRoot + "." + AppConsts.CommonProjectName + "/" + AppConsts.CommonEnumFolderName, AppConsts.SettingTypeEnumClassFileName, settingTypeEnumClass);


            string settingClass = "";
            settingClass += "using DevExpress.Xpo;" + Environment.NewLine;
            settingClass += "using " + projectNameRoot + "." + AppConsts.CommonProjectName + "." + AppConsts.CommonEnumFolderName + ";" + Environment.NewLine;
            settingClass += "" + Environment.NewLine;
            settingClass += "namespace " + projectNameRoot + "." + AppConsts.DBModelsProjectName + "." + AppConsts.DBModelsEntitiesFolderName + Environment.NewLine;
            settingClass += "{" + Environment.NewLine;
            settingClass += "    [Persistent(\"schedulers\")]" + Environment.NewLine;
            settingClass += "    public class " + AppConsts.DBModelsSettingClassName + " : " + AppConsts.DBModelsBaseObjectClassName + Environment.NewLine;
            settingClass += "    {" + Environment.NewLine;
            settingClass += "" + Environment.NewLine;
            settingClass += "        public " + AppConsts.DBModelsSettingClassName + "(Session session) : base(session)" + Environment.NewLine;
            settingClass += "        {" + Environment.NewLine;
            settingClass += "        }" + Environment.NewLine;
            settingClass += "" + Environment.NewLine;
            settingClass += "        [Persistent(\"setting_type\")]" + Environment.NewLine;
            settingClass += "        public ESettingType SettingType { get; set; }" + Environment.NewLine;
            settingClass += "" + Environment.NewLine;
            settingClass += "        [Persistent(\"setting_name\")]" + Environment.NewLine;
            settingClass += "        [Size(1000)]" + Environment.NewLine;
            settingClass += "        public string SettingName { get; set; }" + Environment.NewLine;
            settingClass += "" + Environment.NewLine;
            settingClass += "        [Persistent(\"value\")]" + Environment.NewLine;
            settingClass += "        [Size(1000)]" + Environment.NewLine;
            settingClass += "        public string Value { get; set; }" + Environment.NewLine;
            settingClass += "    }" + Environment.NewLine;
            settingClass += "}" + Environment.NewLine;
            bool schedulerClasssResult = FileHelperManager.Instance.WriteFile(projectPath, projectNameRoot + "." + AppConsts.DBModelsProjectName + "/" + AppConsts.DBModelsEntitiesFolderName, AppConsts.DBModelsSettingClassFileName, settingClass);


            string settingChangeLogClass = "";
            settingChangeLogClass += "using DevExpress.Xpo;" + Environment.NewLine;
            settingChangeLogClass += "" + Environment.NewLine;
            settingChangeLogClass += "namespace " + projectNameRoot + "." + AppConsts.DBModelsProjectName + "." + AppConsts.DBModelsEntitiesFolderName + Environment.NewLine;
            settingChangeLogClass += "{" + Environment.NewLine;
            settingChangeLogClass += "    [Persistent(\"scheduler_logs\")]" + Environment.NewLine;
            settingChangeLogClass += "    public class " + AppConsts.DBModelsSettingChangeLogClassName + " : " + AppConsts.DBModelsBaseObjectClassName + Environment.NewLine;
            settingChangeLogClass += "    {" + Environment.NewLine;
            settingChangeLogClass += "" + Environment.NewLine;
            settingChangeLogClass += "        public " + AppConsts.DBModelsSettingChangeLogClassName + "(Session session) : base(session)" + Environment.NewLine;
            settingChangeLogClass += "        {" + Environment.NewLine;
            settingChangeLogClass += "        }" + Environment.NewLine;
            settingChangeLogClass += "" + Environment.NewLine;
            settingChangeLogClass += "        [Persistent(\"setting_oid\")]" + Environment.NewLine;
            settingChangeLogClass += "        public Setting Setting { get; set; }" + Environment.NewLine;
            settingChangeLogClass += "" + Environment.NewLine;
            settingChangeLogClass += "        [Persistent(\"user_oid\")]" + Environment.NewLine;
            settingChangeLogClass += "        public User User { get; set; }" + Environment.NewLine;
            settingChangeLogClass += "" + Environment.NewLine;
            settingChangeLogClass += "        [Persistent(\"old_value\")]" + Environment.NewLine;
            settingChangeLogClass += "        [Size(1000)]" + Environment.NewLine;
            settingChangeLogClass += "        public string OldValue { get; set; }" + Environment.NewLine;
            settingChangeLogClass += "" + Environment.NewLine;
            settingChangeLogClass += "        [Persistent(\"new_value\")]" + Environment.NewLine;
            settingChangeLogClass += "        [Size(1000)]" + Environment.NewLine;
            settingChangeLogClass += "        public string NewValue { get; set; }" + Environment.NewLine;
            settingChangeLogClass += "    }" + Environment.NewLine;
            settingChangeLogClass += "}" + Environment.NewLine;

            schedulerClasssResult = FileHelperManager.Instance.WriteFile(projectPath, projectNameRoot + "." + AppConsts.DBModelsProjectName + "/" + AppConsts.DBModelsEntitiesFolderName, AppConsts.DBModelsSettingChangeLogClassFileName, settingChangeLogClass);
        }

        private void GenerateUserSessionClass(string projectNameRoot, string projectPath)
        {
            string userSessionClass = "";
            userSessionClass += "using DevExpress.Xpo;" + Environment.NewLine;
            userSessionClass += "" + Environment.NewLine;
            userSessionClass += "namespace " + projectNameRoot + "." + AppConsts.DBModelsProjectName + "." + AppConsts.DBModelsEntitiesFolderName + Environment.NewLine;
            userSessionClass += "{" + Environment.NewLine;
            userSessionClass += "    [Persistent(\"user_sessions\")]" + Environment.NewLine;
            userSessionClass += "    public class " + AppConsts.DBModelsEntitiesFolderName + " : " + AppConsts.DBModelsBaseObjectClassName + Environment.NewLine;
            userSessionClass += "    {" + Environment.NewLine;
            userSessionClass += "        public "+ AppConsts.DBModelsEntitiesFolderName + "(Session session) : base(session)" + Environment.NewLine;
            userSessionClass += "        {" + Environment.NewLine;
            userSessionClass += "        }" + Environment.NewLine;
            userSessionClass += "" + Environment.NewLine;
            userSessionClass += "        [Persistent(\"token\")]" + Environment.NewLine;
            userSessionClass += "        [Size(1000)]" + Environment.NewLine;
            userSessionClass += "        public string Token { get; set; }" + Environment.NewLine;
            userSessionClass += "" + Environment.NewLine;
            userSessionClass += "        [Persistent(\"request_ip\")]" + Environment.NewLine;
            userSessionClass += "        [Size(20)]" + Environment.NewLine;
            userSessionClass += "        public string RequestIp { get; set; }" + Environment.NewLine;
            userSessionClass += "    }" + Environment.NewLine;
            userSessionClass += "}" + Environment.NewLine;

            bool createResult = FileHelperManager.Instance.WriteFile(projectPath, projectNameRoot + "." + AppConsts.DBModelsProjectName + "/" + AppConsts.DBModelsEntitiesFolderName, AppConsts.DBModelsUserSessionClassFileName, userSessionClass);
        }

        private void GenerateSetupManager(string projectNameRoot, string projectPath)
        {
        }

        private void GenerateAuthClassess(string projectNameRoot, string projectPath, string userType)
        {
            string userTypeEnumClass = "";
            userTypeEnumClass+= "namespace "+projectNameRoot+"."+AppConsts.CommonProjectName+"."+AppConsts.CommonEnumFolderName + Environment.NewLine;
            userTypeEnumClass += "{" + Environment.NewLine;
            userTypeEnumClass += "    public enum "+AppConsts.UserTypeEnumClassName+"" + Environment.NewLine;
            userTypeEnumClass += "    {" + Environment.NewLine;
            userTypeEnumClass += "        SystemAdmin = 1," + Environment.NewLine;
            userTypeEnumClass += "        SystemUser = 2," + Environment.NewLine;
            userTypeEnumClass += "        OrganizationAdmin = 3," + Environment.NewLine;
            userTypeEnumClass += "        OrganizationUser = 4" + Environment.NewLine;
            userTypeEnumClass += "    }" + Environment.NewLine;
            userTypeEnumClass += "}" + Environment.NewLine;
            bool createcsprojResult = FileHelperManager.Instance.WriteFile(projectPath, projectNameRoot + "." + AppConsts.CommonProjectName + "/" + AppConsts.CommonEnumFolderName, AppConsts.UserTypeEnumClassFileName, userTypeEnumClass);

            string methodTypeEnumClass = "";
            methodTypeEnumClass += "namespace " + projectNameRoot + "." + AppConsts.CommonProjectName + "." + AppConsts.CommonEnumFolderName + Environment.NewLine;
            methodTypeEnumClass += "{" + Environment.NewLine;
            methodTypeEnumClass += "    public enum " + AppConsts.ApiMethodTypeEnumClassName + "" + Environment.NewLine;
            methodTypeEnumClass += "    {" + Environment.NewLine;
            methodTypeEnumClass += "        Get = 1," + Environment.NewLine;
            methodTypeEnumClass += "        Post = 2," + Environment.NewLine;
            methodTypeEnumClass += "        Put = 3," + Environment.NewLine;
            methodTypeEnumClass += "        Delete = 4" + Environment.NewLine;
            methodTypeEnumClass += "    }" + Environment.NewLine;
            methodTypeEnumClass += "}" + Environment.NewLine;

            createcsprojResult = FileHelperManager.Instance.WriteFile(projectPath, projectNameRoot + "." + AppConsts.CommonProjectName +"/"+AppConsts.CommonEnumFolderName, AppConsts.ApiMethodTypeEnumClassFileName, methodTypeEnumClass);

            string userGroupClass = "";
            userGroupClass += "using DevExpress.Xpo;" + Environment.NewLine;
            userGroupClass += "using "+projectNameRoot+"."+AppConsts.CommonProjectName+"."+ AppConsts.CommonEnumFolderName + ";" + Environment.NewLine;
            userGroupClass += "" + Environment.NewLine;
            userGroupClass += "namespace "+projectNameRoot+"."+AppConsts.DBModelsProjectName+"."+AppConsts.DBModelsEntitiesFolderName + Environment.NewLine;
            userGroupClass += "{" + Environment.NewLine;
            userGroupClass += "    [Persistent(\"user_groups\")]" + Environment.NewLine;
            userGroupClass += "    public class "+AppConsts.UserGroupClassName+" : "+AppConsts.DBModelsBaseObjectClassName+"" + Environment.NewLine;
            userGroupClass += "    {" + Environment.NewLine;
            userGroupClass += "" + Environment.NewLine;
            userGroupClass += "        public "+AppConsts.UserGroupClassName+"(Session session) : base(session)" + Environment.NewLine;
            userGroupClass += "        {" + Environment.NewLine;
            userGroupClass += "        }" + Environment.NewLine;
            userGroupClass += "" + Environment.NewLine;
            userGroupClass += "        [Persistent(\"organization_oid\")]" + Environment.NewLine;
            userGroupClass += "        public Organization Organization { get; set; }" + Environment.NewLine;
            userGroupClass += "" + Environment.NewLine;
            userGroupClass += "        [Persistent(\"name\")]" + Environment.NewLine;
            userGroupClass += "        [Size(255)]" + Environment.NewLine;
            userGroupClass += "        public string Name { get; set; }" + Environment.NewLine;
            userGroupClass += "" + Environment.NewLine;
            userGroupClass += "        [Persistent(\"user_type\")]" + Environment.NewLine;
            userGroupClass += "        public "+AppConsts.UserTypeEnumClassName+" UserType { get; set; }" + Environment.NewLine;
            userGroupClass += "    }" + Environment.NewLine;
            userGroupClass += "}" + Environment.NewLine;

            createcsprojResult = FileHelperManager.Instance.WriteFile(projectPath, projectNameRoot + "." + AppConsts.DBModelsProjectName + "/" + AppConsts.DBModelsEntitiesFolderName, AppConsts.UserGroupClassFileName, userGroupClass);

            string apiServiceClass = "";
            apiServiceClass += "using DevExpress.Xpo;" + Environment.NewLine;
            apiServiceClass += "using " + projectNameRoot + "." + AppConsts.CommonProjectName + "." + AppConsts.CommonEnumFolderName + ";" + Environment.NewLine;
            apiServiceClass += "" + Environment.NewLine;
            apiServiceClass += "namespace " + projectNameRoot + "." + AppConsts.DBModelsProjectName + "." + AppConsts.DBModelsEntitiesFolderName + Environment.NewLine;
            apiServiceClass += "{" + Environment.NewLine;
            apiServiceClass += "    [Persistent(\"user_groups\")]" + Environment.NewLine;
            apiServiceClass += "    public class " + AppConsts.ApiServiceClassName + " : " + AppConsts.DBModelsBaseObjectClassName + "" + Environment.NewLine;
            apiServiceClass += "    {" + Environment.NewLine;
            apiServiceClass += "" + Environment.NewLine;
            apiServiceClass += "        public " + AppConsts.ApiServiceClassName + "(Session session) : base(session)" + Environment.NewLine;
            apiServiceClass += "        {" + Environment.NewLine;
            apiServiceClass += "        }" + Environment.NewLine;
            apiServiceClass += "" + Environment.NewLine;
            apiServiceClass += "        [Persistent(\"api_key\")]" + Environment.NewLine;
            apiServiceClass += "        [Size(255)]" + Environment.NewLine;
            apiServiceClass += "        public string ApiKey { get; set; }" + Environment.NewLine;
            apiServiceClass += "" + Environment.NewLine;
            apiServiceClass += "        [Persistent(\"api_definition_td_oid\")]" + Environment.NewLine;
            apiServiceClass += "        [Size(255)]" + Environment.NewLine;
            apiServiceClass += "        public TranslateData ApiDefinition { get; set; }" + Environment.NewLine;
            apiServiceClass += "" + Environment.NewLine;
            apiServiceClass += "        [Persistent(\"method_type\")]" + Environment.NewLine;
            apiServiceClass += "        public EApiServiceMethodType MethodType { get; set; }" + Environment.NewLine;
            apiServiceClass += "" + Environment.NewLine;
            apiServiceClass += "        [Persistent(\"editable_for_admin\")]" + Environment.NewLine;
            apiServiceClass += "        public bool EditableForAdmin { get; set; }" + Environment.NewLine;
            apiServiceClass += "" + Environment.NewLine;
            apiServiceClass += "        [Persistent(\"editable_for_organization\")]" + Environment.NewLine;
            apiServiceClass += "        public bool EditableForOrganization { get; set; }" + Environment.NewLine;
            apiServiceClass += "" + Environment.NewLine;
            apiServiceClass += "        [Persistent(\"Anonymous\")]" + Environment.NewLine;
            apiServiceClass += "        public bool Anonymous { get; set; }" + Environment.NewLine;
            apiServiceClass += "    }" + Environment.NewLine;
            apiServiceClass += "}" + Environment.NewLine;

            createcsprojResult = FileHelperManager.Instance.WriteFile(projectPath, projectNameRoot + "." + AppConsts.DBModelsProjectName + "/" + AppConsts.DBModelsEntitiesFolderName, AppConsts.ApiServiceClassFileName, apiServiceClass);

            string authClass = "";
            authClass += "using DevExpress.Xpo;" + Environment.NewLine;
            authClass += "using " + projectNameRoot + "." + AppConsts.CommonProjectName + "." + AppConsts.CommonEnumFolderName + ";" + Environment.NewLine;
            authClass += "" + Environment.NewLine;
            authClass += "namespace " + projectNameRoot + "." + AppConsts.DBModelsProjectName + "." + AppConsts.DBModelsEntitiesFolderName + Environment.NewLine;
            authClass += "{" + Environment.NewLine;
            authClass += "    [Persistent(\"user_groups\")]" + Environment.NewLine;
            authClass += "    public class " + AppConsts.DBModelsAuthClassName + " : " + AppConsts.DBModelsBaseObjectClassName + "" + Environment.NewLine;
            authClass += "    {" + Environment.NewLine;
            authClass += "" + Environment.NewLine;
            authClass += "        public " + AppConsts.DBModelsAuthClassName + "(Session session) : base(session)" + Environment.NewLine;
            authClass += "        {" + Environment.NewLine;
            authClass += "        }" + Environment.NewLine;
            authClass += "" + Environment.NewLine;
            authClass += "        [Persistent(\"api_service_oid\")]" + Environment.NewLine;
            authClass += "        public ApiService ApiService { get; set; }" + Environment.NewLine;
            authClass += "" + Environment.NewLine;
            authClass += "        [Persistent(\"user_group_oid\")]" + Environment.NewLine;
            authClass += "        public UserGroup UserGroup { get; set; }" + Environment.NewLine;
            authClass += "" + Environment.NewLine;
            authClass += "        [Persistent(\"is_authority\")]" + Environment.NewLine;
            authClass += "        public bool IsAuhtority { get; set; }" + Environment.NewLine;
            authClass += "    }" + Environment.NewLine;
            authClass += "}" + Environment.NewLine;


            createcsprojResult = FileHelperManager.Instance.WriteFile(projectPath, projectNameRoot + "." + AppConsts.DBModelsProjectName + "/" + AppConsts.DBModelsEntitiesFolderName, AppConsts.DBModelsAuthClassFileName, authClass);

        }

        private void GenerateUserSessionBusiness(string projectNameRoot, string projectPath)
        {
        }

        private void GenerateLoginBusiness(string projectNameRoot, string projectPath)
        {
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

        private void GenerateOrganizationBusiness(string projectNameRoot, string projectPath)
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


        public bool GeneratXpoManagerClass(string projectNameRoot, string projectPath)
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


        private void GenerateWebSecurityLayer(string projectName, string projectNameRoot, string projectPath, string issuer, string audience, int tokenExpireHour)
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

            bool createprincipalClassResult = FileHelperManager.Instance.WriteFile(projectPath, projectNameRoot + "." + AppConsts.WebSecurityProjectName, projectName + AppConsts.WebSecurityPrincipalClassFileName, principalClass);

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

            bool createSecurityConstManagerClassResult = FileHelperManager.Instance.WriteFile(projectPath, projectNameRoot + "." + AppConsts.WebSecurityProjectName, projectName + AppConsts.WebSecuritySecurityConstsManagerClassFileName, securityConstsManagerClass);


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
            csprojWebSecurity += "    <ProjectReference Include=\"..\\"+projectNameRoot+"."+AppConsts.CommonProjectName+"\\"+projectNameRoot+"."+AppConsts.CommonProjectName+".csproj\" />" + Environment.NewLine;
            csprojWebSecurity += "    <ProjectReference Include=\"..\\Pavolle.Core\\Pavolle.Core.csproj\" />" + Environment.NewLine;
            csprojWebSecurity += "  </ItemGroup>" + Environment.NewLine;
            csprojWebSecurity += "" + Environment.NewLine;
            csprojWebSecurity += "</Project>" + Environment.NewLine;

            bool createcsprojResult = FileHelperManager.Instance.EditFile(projectPath, projectNameRoot + "." + AppConsts.WebSecurityProjectName, projectNameRoot + "." + AppConsts.WebSecurityProjectName + ".csproj", csprojWebSecurity);
        }

    }
}
