using DevExpress.Xpo;
using Newtonsoft.Json;
using Pavolle.Core.Enums;
using Pavolle.MessageService.Business.Manager;
using Pavolle.MessageService.Common.Enums;
using Pavolle.MessageService.Common.Utils;
using Pavolle.MessageService.DbModels;
using Pavolle.MessageService.DbModels.Entities;
using Pavolle.Security;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("**********************************");

       Console.WriteLine("Setup  Message Service starting...");
      
        string[] text = File.ReadAllLines("appsettings.ini");
        string connectionString = text[0];
        Console.WriteLine("Connection string: " + connectionString);
        string adminUsername=text[1];
        Console.WriteLine("Admin Username: " + adminUsername);
        string adminPassword=text[2];
        Console.WriteLine("Admin Password: " + adminPassword);
        string adminPhoneNumber = text[3];
        Console.WriteLine("Admin Phone Number: " + adminPhoneNumber);
        string adminEmailNumber = text[4];
        Console.WriteLine("Admin Email: " + adminEmailNumber);

        bool status= DbManager.Instance.Initialize(connectionString);
        Console.WriteLine("Db connection " + (status ? "success. " : "fail!"));

        ELanguage defaultLanguage = ELanguage.Turkce;

        using (Session session = XpoManager.Instance.GetNewSession())
        {
            UserGroup userGroupAdmin = null;
            userGroupAdmin = session.Query<UserGroup>().FirstOrDefault(t => t.UserType == EUserType.SystemAdmin);
            if(userGroupAdmin == null)
            {
                userGroupAdmin = new UserGroup(session)
                {
                    Name = "Admin",
                    Organization = null,
                    UserType = EUserType.SystemAdmin
                };
                userGroupAdmin.Save();
            }
            if (!session.Query<User>().Any(t => t.Username == adminUsername))
            {
                var user = new User(session)
                {
                    UserType = EUserType.SystemAdmin,
                    Username = adminUsername,
                    UserGroup = userGroupAdmin,
                    Name = "System",
                    Surname = "Admin",
                    Email = adminEmailNumber,
                    EmailVerify = true,
                    PhoneNumber = adminPhoneNumber,
                    PhoneNumberVerify = true,
                    Password = SecurityHelperManager.Instance.GetEncryptedPassword(adminPassword, adminUsername),
                    IsLocked = false,
                    WrongTryCount = 0,
                    Code = ""
                };
                user.Save();
            }

            #region Setting
            CreateSettingRow(session, ESettingType.SchedulerControlCron, "Scheduler Control Cron", "");
            CreateSettingRow(session, ESettingType.SecurityLevel, "Security Level", ((int)ESecurityLevel.Master).ToString());
            CreateSettingRow(session, ESettingType.DefaultLanguage, "Default Language", ((int)defaultLanguage).ToString());
            CreateSettingRow(session, ESettingType.ResetCodeLenght, "Reset Code Lenght", "6");
            #endregion

            WriteAuth(session, userGroupAdmin, MessageServiceApiUrlConsts.LoginRouteConsts.Route + "/" + MessageServiceApiUrlConsts.LoginRouteConsts.SignInRoutePrefix, "Sign In", false, false, true, EApiServiceMethodType.Post, defaultLanguage);
            WriteAuth(session, userGroupAdmin, MessageServiceApiUrlConsts.LoginRouteConsts.Route + "/" + MessageServiceApiUrlConsts.LoginRouteConsts.SignOutRoutePrefix, "Sign Out", false, false, false, EApiServiceMethodType.Post, defaultLanguage);
        }


        Console.WriteLine("Setup Done.");
        Console.WriteLine("**********************************");

        Console.ReadLine();
    }

    private static void CreateSettingRow(Session session, ESettingType settingType, string name, string value)
    {
        if (!session.Query<Setting>().Any(t => t.SettingType == settingType))
        {
            new Setting(session)
            {
                SettingType = settingType,
                Value = value,
                SettingName = name
            }.Save();
        }
    }

    private static void WriteAuth(Session session, UserGroup userGroupAdmin, string apiKey, string apiDefinition, bool editableForAdmin, bool editableForOrganizationAdmin, bool anonymous, EApiServiceMethodType methodType, ELanguage defaultLanguage)
    {
        if (!session.Query<ApiService>().Any(t => t.ApiKey == apiKey))
        {
            


            var apiService = new ApiService(session)
            {
                ApiKey = apiKey,
                ApiDefinition = apiDefinition,
                MethodType = methodType,
                Anonymous = anonymous,
                EditableForAdmin = editableForAdmin,
                EditableForOrganization = editableForOrganizationAdmin
            };

            foreach (var userGroup in session.Query<UserGroup>())
            {
                bool isAuthority = false;
                if (userGroup.UserType == EUserType.SystemAdmin) { isAuthority = true; }
                new Auth(session)
                {
                    UserGroup = userGroup,
                    ApiService = apiService,
                    IsAuhtority = isAuthority
                }.Save();
            }
        }
    }
}