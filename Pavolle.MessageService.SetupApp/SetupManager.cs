using DevExpress.Xpo;
using log4net;
using Pavolle.Core.Utils;
using Pavolle.MessageService.Common.Enums;
using Pavolle.MessageService.Common.Utils;
using Pavolle.MessageService.DbModels;
using Pavolle.MessageService.DbModels.Entities;
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

        public void Setup(string managerCompany, string code, string adminusername, string adminpassword)
        {
            //Pavolle company oluştur.
            //Pavolle admin kullanıcısı oluştur.
            //Yetkileri yaz

           Console.WriteLine ("Kurulum bilgileri kontrol ediliyor...");
            
            using(Session session = XpoManager.Instance.GetNewSession())
            {
                Company company = session.Query<Company>().FirstOrDefault(t => t.Name == managerCompany && t.Manager);
                if (company == null)
                {
                    company = new Company(session)
                    {
                        Name = managerCompany,
                        Code=code,
                        Manager = true,
                        Address = ""
                    };
                    company.Save();
                }

                User sistemAdmin = session.Query<User>().FirstOrDefault(t => t.Username == adminusername && t.Company.Oid==company.Oid);
                if(sistemAdmin == null)
                {
                    sistemAdmin = new User(session)
                    {
                        Username = adminusername,
                        Name = "System",
                        Surname = "Admin",
                        UserType = EUserType.SystemAdmin,
                        Email = "agha.alizade@outlook.com",
                        PhoneNumber = "",
                        Company = company,
                        Password = SecurityHelperManager.Instance.GetEncryptedPassword(adminusername, adminpassword),
                    };
                    sistemAdmin.Save();

                    company.AdminUser = sistemAdmin;

                    Console.WriteLine(adminusername + " kullanıcısı oluşturuldu.");
                }

                string companyAdminUsername = code.ToLower() + "admin";
                User companyAdmin = session.Query<User>().FirstOrDefault(t => t.Username == companyAdminUsername && t.Company.Oid == company.Oid);
                if (companyAdmin == null)
                {
                    companyAdmin = new User(session)
                    {
                        Username = companyAdminUsername,
                        Name = managerCompany,
                        Surname = "Admin",
                        UserType = EUserType.CompanyAdmin,
                        Email = "agha.alizade@outlook.com",
                        PhoneNumber = "",
                        Company = company,
                        Password = SecurityHelperManager.Instance.GetEncryptedPassword(companyAdminUsername, adminpassword),
                    };
                    companyAdmin.Save();


                    Console.WriteLine(companyAdminUsername + " kullanıcısı oluşturuldu.");
                }

                YetkiYoksaYaz(session, MessageServiceApiUrlConsts.AppRouteConsts.Route + "/" + MessageServiceApiUrlConsts.AddRoutePrefix, "Uygulama Oluşturma", false, true, false, true);
                YetkiYoksaYaz(session, MessageServiceApiUrlConsts.AppRouteConsts.Route + "/" + MessageServiceApiUrlConsts.EditRoutePrefix, "Uygulama Bilgileri Düzenleme", false, true, false, true);
                YetkiYoksaYaz(session, MessageServiceApiUrlConsts.AppRouteConsts.Route + "/" + MessageServiceApiUrlConsts.DeleteRoutePrefix, "Uygulama Silme", false, true, false, true);
                YetkiYoksaYaz(session, MessageServiceApiUrlConsts.AppRouteConsts.Route + "/" + MessageServiceApiUrlConsts.ListRoutePrefix, "Uygulama Listesi Görüntüleme", false, true, true, true);
                YetkiYoksaYaz(session, MessageServiceApiUrlConsts.AppRouteConsts.Route + "/" + MessageServiceApiUrlConsts.DetailRoutePrefix, "Uygulama Detayı Görüntüleme", false, true, true, true);
                YetkiYoksaYaz(session, MessageServiceApiUrlConsts.AppRouteConsts.Route + "/" + MessageServiceApiUrlConsts.LookupRoutePrefix, "Uygulama Listesi Lookup", false, true, true, true);

                YetkiYoksaYaz(session, MessageServiceApiUrlConsts.AuthRouteConsts.Route + "/" + MessageServiceApiUrlConsts.EditRoutePrefix, "Yetki Bilgileri Düzenleme", false, true, false, false);
                YetkiYoksaYaz(session, MessageServiceApiUrlConsts.AuthRouteConsts.Route + "/" + MessageServiceApiUrlConsts.ListRoutePrefix, "Yetki Listesi Görüntüleme", false, true, true, false);
                YetkiYoksaYaz(session, MessageServiceApiUrlConsts.AuthRouteConsts.Route + "/" + MessageServiceApiUrlConsts.DetailRoutePrefix, "Yetki Detayı Görüntüleme", false, true, true, false);
            }

        }

        private void YetkiYoksaYaz(Session session, string apiKey, string apiDefintion, bool admin, bool companyAdmin, bool companyUser, bool editable)
        {
            Auth yetki = session.Query<Auth>().FirstOrDefault(t => t.ApiKey == apiKey);
            if (yetki != null) return;

            Console.WriteLine(apiDefintion + " servisi için yetki bilgileri veritabanına yazılıyor...");
            new Auth(session)
            {
                ApiKey = apiKey,
                ApiDefinition = apiDefintion,
                AdminAuth = admin,
                CompanyAdminAuth = companyAdmin,
                CompanyUserAuth=companyUser,
                Editable=editable
            }.Save();
            Console.WriteLine(apiDefintion + " servisi için yetki bilgileri veritabanına yazıldı.");
        }
    }
}
