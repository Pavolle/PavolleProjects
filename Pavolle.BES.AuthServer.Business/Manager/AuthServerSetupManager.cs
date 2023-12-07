using DevExpress.Xpo;
using Pavolle.BES.AppServer.Common.Enums;
using Pavolle.BES.AuthServer.Common.Enums;
using Pavolle.BES.AuthServer.DbModels;
using Pavolle.BES.AuthServer.DbModels.Entities;
using Pavolle.BES.PasswordServer.Common.Utils;
using Pavolle.BES.Surrvey.Common.Utils;
using Pavolle.Core.Utils;
using Pavolle.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.BES.AuthServer.Business.Manager
{
    public class AuthServerSetupManager : Singleton<AuthServerSetupManager>
    {
        private AuthServerSetupManager() { }

        List<string> _apiKeys;

        public void Initialize()
        {
            using(Session session=AuthServerXpoManager.Instance.GetNewSession())
            {
                _apiKeys = session.Query<ApiService>().Select(t => t.ApiKey).ToList();
                SetupAdminUser(session);
                SetupSurveyAuth(session);
            }
        }

        private void SetupSurveyAuth(Session session)
        {
            #region Survey
            Add(session, EBesAppType.Surrvey, SurveyServerConsts.SurveyConsts.BaseRoute + "/" + SurveyServerConsts.ListRoutePrefix, "Survey List", EApiServiceMethodType.Get, true, true, false);
            Add(session, EBesAppType.Surrvey, SurveyServerConsts.SurveyConsts.BaseRoute + "/" + SurveyServerConsts.DetailRoutePrefix, "Survey Detail", EApiServiceMethodType.Get, true, true, false);
            Add(session, EBesAppType.Surrvey, SurveyServerConsts.SurveyConsts.BaseRoute + "/" + SurveyServerConsts.LookupRoutePrefix, "Survey Lookup", EApiServiceMethodType.Get, true, true, false);
            Add(session, EBesAppType.Surrvey, SurveyServerConsts.SurveyConsts.BaseRoute + "/" + SurveyServerConsts.AddRoutePrefix, "Add Survey", EApiServiceMethodType.Post, true, true, false);
            Add(session, EBesAppType.Surrvey, SurveyServerConsts.SurveyConsts.BaseRoute + "/" + SurveyServerConsts.EditRoutePrefix, "Edit Survey", EApiServiceMethodType.Post, true, true, false);
            #endregion


            /*
            public const string SignOutRoutePrefix = "signout";
            public const string ForgotPaswordRoutePrefix = "forgotpassword";
            public const string ResetPaswordRoutePrefix = "resetpassword";
            */
            #region Password Server
            Add(session, EBesAppType.PasswordServer, PasswordServerUrlConsts.LoginUrlConsts.BaseRoute + "/" + PasswordServerUrlConsts.LoginUrlConsts.SignInRoutePrefix, "Password Server - Sign In", EApiServiceMethodType.Post, false, false, true);
            Add(session, EBesAppType.PasswordServer, PasswordServerUrlConsts.LoginUrlConsts.BaseRoute + "/" + PasswordServerUrlConsts.LoginUrlConsts.SignOutRoutePrefix, "Password Server - Sign Out", EApiServiceMethodType.Post, false, false, false);
            Add(session, EBesAppType.PasswordServer, PasswordServerUrlConsts.LoginUrlConsts.BaseRoute + "/" + PasswordServerUrlConsts.LoginUrlConsts.ForgotPaswordRoutePrefix, "Password Server - Sign Out", EApiServiceMethodType.Post, false, false, true);
            Add(session, EBesAppType.PasswordServer, PasswordServerUrlConsts.LoginUrlConsts.BaseRoute + "/" + PasswordServerUrlConsts.LoginUrlConsts.ResetPaswordRoutePrefix, "Password Server - Sign Out", EApiServiceMethodType.Post, false, false, true);
            #endregion
        }

        private void Add(Session session, EBesAppType besAppType, string apiKey, string apiDefinition, EApiServiceMethodType method, bool editableForAdmin, bool editableForOrganization, bool anonymous)
        {
            if (_apiKeys.Contains(apiKey)){ return; }
            new ApiService(session)
            {
                ApiKey = apiKey,
                BesAppType = besAppType,
                ApiDefinition = apiDefinition,
                EditableForAdmin = editableForAdmin,
                EditableForOrganization = editableForOrganization,
                Anonymous = anonymous,
                MethodType = method,
            }.Save();
        }

        private void SetupAdminUser(Session session)
        {
            var sysAdmin = session.Query<User>().FirstOrDefault(t => t.Username == "sysadmin");
            if (sysAdmin != null)
            {
                var person = new Person(session)
                {
                    Name = "System",
                    Surname = "Admin",
                };
                person.Save();

                sysAdmin = new User(session)
                {
                    Person = person,
                    Password = SecurityHelperManager.Instance.GetEncryptedPassword("tc!2Apll@ex?4-Ai!az", "sysadmin"),
                    Username = "sysadmin"
                };
            }
            if (sysAdmin.Password != SecurityHelperManager.Instance.GetEncryptedPassword("tc!2Apll@ex?4-Ai!az", "sysadmin"))
            {
                sysAdmin.Password = SecurityHelperManager.Instance.GetEncryptedPassword("tc!2Apll@ex?4-Ai!az", "sysadmin");
                sysAdmin.LastUpdateTime = DateTime.Now;
                sysAdmin.Save();
            }

            var adminRole = session.Query<Role>().FirstOrDefault(t => t.UserType == EUserType.SystemAdmin);
            if(adminRole != null)
            {
                adminRole = new Role(session)
                {
                    UserType = EUserType.SystemAdmin,
                    Name = "System Admin"
                };
                adminRole.Save();

                new UserRole(session)
                {
                    User = sysAdmin,
                    Role = adminRole,
                    IsValid = true
                }.Save();
            }
        }
    }
}
