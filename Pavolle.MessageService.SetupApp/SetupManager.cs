using DevExpress.Xpo;
using log4net;
using Pavolle.Core.Utils;
using Pavolle.MessageService.Common.Enums;
using Pavolle.MessageService.Common.Utils;
using Pavolle.MessageService.DbModels;
using Pavolle.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.MessageService.Business.Manager
{
    public class SetupManager:Singleton<SetupManager>
    {
        private SetupManager()
        {

        }

        public void Setup(string managerCompany, string code, string adminusername, string adminpassword, int setupLanguage)
        {
            //Pavolle company oluştur.
            //Pavolle admin kullanıcısı oluştur.
            //Yetkileri yaz

           //Console.WriteLine ("Kurulum bilgileri kontrol ediliyor...");
            
           // using(Session session = XpoManager.Instance.GetNewSession())
           // {
           //     Organization company = session.Query<Organization>().FirstOrDefault(t => t.Name == managerCompany);
           //     if (company == null)
           //     {
           //         company = new Organization(session)
           //         {
           //             Name = managerCompany,
           //             Code=code,
           //             Address = ""
           //         };
           //         company.Save();
           //     }

           //     User sistemAdmin = session.Query<User>().FirstOrDefault(t => t.Username == adminusername && t.Organization.Oid==company.Oid);
           //     if(sistemAdmin == null)
           //     {
           //         sistemAdmin = new User(session)
           //         {
           //             Username = adminusername,
           //             Name = "System",
           //             Surname = "Admin",
           //             UserType = EUserType.SystemAdmin,
           //             Email = "agha.alizade@outlook.com",
           //             PhoneNumber = "",
           //             Organization = company,
           //             Password = SecurityHelperManager.Instance.GetEncryptedPassword(adminusername, adminpassword),
           //         };
           //         sistemAdmin.Save();

           //         Console.WriteLine(adminusername + " kullanıcısı oluşturuldu.");
           //     }

           //     string companyAdminUsername = code.ToLower() + "admin";
           //     User companyAdmin = session.Query<User>().FirstOrDefault(t => t.Username == companyAdminUsername && t.Organization.Oid == company.Oid);
           //     if (companyAdmin == null)
           //     {
           //         companyAdmin = new User(session)
           //         {
           //             Username = companyAdminUsername,
           //             Name = managerCompany,
           //             Surname = "Admin",
           //            // UserType = EUserType.CompanyAdmin,
           //             Email = "agha.alizade@outlook.com",
           //             PhoneNumber = "",
           //             Organization = company,
           //             Password = SecurityHelperManager.Instance.GetEncryptedPassword(companyAdminUsername, adminpassword),
           //         };
           //         companyAdmin.Save();


           //         Console.WriteLine(companyAdminUsername + " kullanıcısı oluşturuldu.");
           //     }

           //     YetkiYoksaYaz(session, MessageServiceApiUrlConsts.AuthRouteConsts.Route + "/" + MessageServiceApiUrlConsts.EditRoutePrefix, "Yetki Bilgileri Düzenleme", true, false, false, false, false, false, false, false);
           //     YetkiYoksaYaz(session, MessageServiceApiUrlConsts.AuthRouteConsts.Route + "/" + MessageServiceApiUrlConsts.ListRoutePrefix, "Yetki Listesi Görüntüleme", true, false, false, false, false, false, false, false);
           //     YetkiYoksaYaz(session, MessageServiceApiUrlConsts.AuthRouteConsts.Route + "/" + MessageServiceApiUrlConsts.DetailRoutePrefix, "Yetki Detayı Görüntüleme", true, false, false, false, false, false, false, false);

                
           //     YetkiYoksaYaz(session, MessageServiceApiUrlConsts.CompanyRouteConsts.Route + "/" + MessageServiceApiUrlConsts.AddRoutePrefix, "Kurum Oluşturma", true, true, false, false, false, false, false, false);
           //     YetkiYoksaYaz(session, MessageServiceApiUrlConsts.CompanyRouteConsts.Route + "/" + MessageServiceApiUrlConsts.EditRoutePrefix, "Kurum Bilgileri Düzenleme", true, true, false, false, false, false, false, false);
           //     YetkiYoksaYaz(session, MessageServiceApiUrlConsts.CompanyRouteConsts.Route + "/" + MessageServiceApiUrlConsts.DeleteRoutePrefix, "Kurum Silme", true, true, false, false, false, false, false, false);
           //     YetkiYoksaYaz(session, MessageServiceApiUrlConsts.CompanyRouteConsts.Route + "/" + MessageServiceApiUrlConsts.ListRoutePrefix, "Kurum Listesi Görüntüleme", true, true, false, false, false, false, false, false);
           //     YetkiYoksaYaz(session, MessageServiceApiUrlConsts.CompanyRouteConsts.Route + "/" + MessageServiceApiUrlConsts.DetailRoutePrefix, "Kurum Detayı Görüntüleme", true, true, false, false, false, false, false, false);
           //     YetkiYoksaYaz(session, MessageServiceApiUrlConsts.CompanyRouteConsts.Route + "/" + MessageServiceApiUrlConsts.LookupRoutePrefix, "Kurum Listesi Lookup", true, true, false, false, false, false, false, false);

           //     YetkiYoksaYaz(session, MessageServiceApiUrlConsts.LoginRouteConsts.Route + "/" + MessageServiceApiUrlConsts.LoginRouteConsts.SignInRoutePrefix, "Kullanıcı Girişi", false, false, false, false, false, false, false, true);
           //     YetkiYoksaYaz(session, MessageServiceApiUrlConsts.LoginRouteConsts.Route + "/" + MessageServiceApiUrlConsts.LoginRouteConsts.SignOutRoutePrefix, "Sistem Çıkışı", true, true, true, true, true, true, false, false);

           // }

        }

        private void YetkiYoksaYaz(Session session, string apiKey, string apiDefintion, 
            bool admin, 
            bool companyAdmin, 
            bool projectPanager,
            bool developer,
            bool tecnicalSupportSpecialist,
            bool liveSupportSpecialist,
            bool editable, 
            bool anonymous)
        {
            //Auth yetki = session.Query<Auth>().FirstOrDefault(t => t.ApiKey == apiKey);
            //if (yetki != null) return;

            Console.WriteLine(apiDefintion + " servisi için yetki bilgileri veritabanına yazılıyor...");
            //new Auth(session)
            //{
            //    ApiKey = apiKey,
            //    ApiDefinition = apiDefintion,
            //    AdminAuth = admin,
            //    CompanyAdminAuth = companyAdmin,
            //    ProjectManagerAuth= projectPanager,
            //    DeveloperAuth=developer,
            //    TecnicalSupportSpecialistAuth=tecnicalSupportSpecialist,
            //    LiveSupportSpecialistAuth=liveSupportSpecialist,
            //    Editable =editable,
            //    Anonymous=anonymous
            //}.Save();
            Console.WriteLine(apiDefintion + " servisi için yetki bilgileri veritabanına yazıldı.");

            //TranslateManager.Instance.Setup();
        }
    }
}
