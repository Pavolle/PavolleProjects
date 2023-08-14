using DevExpress.Xpo;
using log4net;
using Pavolle.Core.Utils;
using Pavolle.Core.ViewModels.Criteria;
using Pavolle.Core.ViewModels.Request;
using Pavolle.Core.ViewModels.Response;
using Pavolle.Core.ViewModels.ViewData;
using Pavolle.Multilanguage;
using Pavolle.MessageService.DbModels;
using Pavolle.MessageService.DbModels.Entities;
using Pavolle.MessageService.ViewModels.Criteria;
using Pavolle.MessageService.ViewModels.Request;
using Pavolle.MessageService.ViewModels.Response;
using Pavolle.MessageService.ViewModels.ViewData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.MessageService.Business.Manager
{
    public class AppManager:Singleton<AppManager>
    {
        static readonly ILog _log = LogManager.GetLogger(typeof(AppManager));
        private AppManager() { }


        //TODO Project Manager de eklenecek
        public MessageServiceResponseBase Add(AppRequest request)
        {
            string logBase=LogHelperManager.Instance.GetLogBase(request);
            _log.Info(logBase + "Başlatılıyor");
            var response=CheckAppRequest(request);
            if(response.Success)
            {
                using(Session session = XpoManager.Instance.GetNewSession())
                {
                    var company = session.Query<Company>().FirstOrDefault(t => t.Oid == request.CompanyOid);
                    response = ValidationManager.Instance.CheckNull(company, EMessageCode.Company);
                    if (response.Success)
                    {
                        var app = new App(session)
                        {
                            Name = request.Name,
                            Company = company,
                            About = request.About,
                            Platform = request.Platform.Value,
                            Link = request.Link
                        };
                        app.Save();

                        string appId = GenerateAppID(company.Code, company.Oid.ToString(), app.Oid.ToString());
                        app.AppId = appId;
                        app.Save();
                    }
                }
            }
            var logResponse=UserOperationLogManager.Instance.Save("MS","App=>Add",request, response);
            _log.Info(logBase + "Tamamlandı. Sonuç: " + logResponse);
            return response;
        }

        public MessageServiceResponseBase Edit(long? oid, AppRequest request)
        {
            string logBase = LogHelperManager.Instance.GetLogBase(request);
            _log.Info(logBase + "Başlatılıyor");
            var response = CheckAppRequest(request);
            if (!response.Success) return response;
            using (Session session = XpoManager.Instance.GetNewSession())
            {
                var app = session.Query<App>().FirstOrDefault(t => t.Oid == oid);
                response = ValidationManager.Instance.CheckNull(app, EMessageCode.App);
                if (app.Company.Oid == request.CompanyOid)
                {
                    if (response.Success)
                    {
                        app.About = request.About;
                        app.Platform = request.Platform.Value;
                        app.Link = request.Link;
                        app.LastUpdateTime = DateTime.Now;
                        app.Save();
                    }
                }
                else
                {
                    response = ValidationManager.Instance.GetIslemYapmaYetkinizYokturMessage();
                }
            }
            var logResponse = UserOperationLogManager.Instance.Save("MS", "App=>Edit", request, response);
            _log.Info(logBase + "Tamamlandı. Sonuç: " + logResponse);
            return response;
        }

        public AppListResponse List(MessageServiceCriteriaBase criteria)
        {
            var response = new AppListResponse();
            var valitionResponse = ValidationManager.Instance.CheckRequestBaseParameter(criteria);
            if (!valitionResponse.Success)
            {
                response.Success = false;
                response.ErrorMessage = valitionResponse.ErrorMessage;
                return response;
            }

            using(Session session = XpoManager.Instance.GetNewSession())
            {
                response.DataList = session.Query<App>()
                    .Where(t => t.Company.Oid == criteria.CompanyOid)
                    .Select(m => new AppViewData
                    {
                        Oid = m.Oid,
                        CreatedTime=m.CreatedTime,
                        LastUpdateTime=m.LastUpdateTime.Value,
                        Name=m.Name,
                        About=m.About,
                        Platform=m.Platform,
                        Link=m.Link,
                        AppId=m.AppId
                    }).ToList();
            }

            return response;
        }

        public LookupResponse Lookup(MessageServiceCriteriaBase criteria)
        {
            var response = new LookupResponse();
            var valitionResponse = ValidationManager.Instance.CheckRequestBaseParameter(criteria);
            if (!valitionResponse.Success)
            {
                response.Success = false;
                response.ErrorMessage = valitionResponse.ErrorMessage;
                return response;
            }

            using (Session session = XpoManager.Instance.GetNewSession())
            {
                response.DataList = session.Query<App>()
                    .Where(t => t.Company.Oid == criteria.CompanyOid)
                    .Select(m => new LookupViewData
                    {
                        Key = m.Oid,
                        Value = m.AppId + " - " + m.Name,
                        IsDefault = false
                    }).ToList();
            }

            return response;
        }

        public AppDetailResponse Detail(long? oid, MessageServiceRequestBase request)
        {
            var response = new AppDetailResponse();
            var valitionResponse = ValidationManager.Instance.CheckRequestBaseParameter(request);
            if (!valitionResponse.Success)
            {
                response.Success = false;
                response.ErrorMessage = valitionResponse.ErrorMessage;
                return response;
            }

            using (Session session = XpoManager.Instance.GetNewSession())
            {
                var app = session.Query<App>().FirstOrDefault(t => t.Oid == oid);

                if (app.Company.Oid == request.CompanyOid)
                {
                    if (response.Success)
                    {
                        response.Oid = app.Oid;
                        response.About = app.About;
                        response.Platform = app.Platform;
                        response.Link = app.Link;
                        response.Name = app.Name;
                        response.LastUpdateTime = app.LastUpdateTime;
                        response.AppId = app.AppId;
                        response.CreatedTime = app.CreatedTime;
                    }

                    //Uygulama versiyonu ile ilgili detay bilgisini sorgulayacak
                }
                else
                {
                    //yetki yok
                }
            }

            return response;
        }

        public MessageServiceResponseBase Delete(long oid, MessageServiceRequestBase request)
        {
            var response = new MessageServiceResponseBase();
            var valitionResponse = ValidationManager.Instance.CheckRequestBaseParameter(request);
            if (!valitionResponse.Success)
            {
                response.Success = false;
                response.ErrorMessage = valitionResponse.ErrorMessage;
                return response;
            }
            using (Session session = XpoManager.Instance.GetNewSession())
            {
                var app = session.Query<App>().FirstOrDefault(t => t.Oid == oid);
                response = ValidationManager.Instance.CheckNull(app, EMessageCode.App);
                if (app.Company.Oid == request.CompanyOid)
                {
                    if(session.Query<AppVersion>().Any(t=>t.App.Oid==oid))
                    {
                        //Hata silinemez
                    }
                    else
                    {
                        app.LastUpdateTime = DateTime.Now;
                        app.Save();

                        app.Delete();
                    }
                }
                else
                {
                    response = ValidationManager.Instance.GetIslemYapmaYetkinizYokturMessage();
                }
            }
            UserOperationLogManager.Instance.Save("MS", "App=>Delete", request, response);
            return response;
        }

        private MessageServiceResponseBase CheckAppRequest(AppRequest request)
        {
            var response = new MessageServiceResponseBase();
            response = ValidationManager.Instance.CheckRequestBaseParameter(request);
            if (!response.Success) return response;

            response = ValidationManager.Instance.CheckString(request.Name, false, 1, 100, EMessageCode.Name);
            if (!response.Success) return response;

            response = ValidationManager.Instance.CheckString(request.About, false, 0, 1000, EMessageCode.About);
            if (!response.Success) return response;

            response = ValidationManager.Instance.CheckString(request.Link, false, 0, 255, EMessageCode.Link);
            if (!response.Success) return response;

            response = ValidationManager.Instance.CheckNull(request.Platform, EMessageCode.Platform);
            if (!response.Success) return response;
            return response;
        }

        public string GenerateAppID(string companyCode, string companyId, string appOid)
        {
            var sonuc = "";
            sonuc += companyCode;

            if (companyId.Length == 1)
            {
                sonuc += "C000000" + companyId;
            }
            else if(companyId.Length == 2)
            {
                sonuc += "C00000" + companyId;
            }
            else if (companyId.Length == 3)
            {
                sonuc += "C0000" + companyId;
            }
            else if (companyId.Length == 4)
            {
                sonuc += "C000" + companyId;
            }
            else if (companyId.Length == 5)
            {
                sonuc += "C00" + companyId;
            }
            else if (companyId.Length == 6)
            {
                sonuc += "C0" + companyId;
            }
            else
            {
                sonuc += "C" + companyId;
            }

            if (appOid.Length == 1)
            {
                sonuc += "P000000000" + appOid;
            }
            else if (appOid.Length == 2)
            {
                sonuc += "P00000000" + appOid;
            }
            else if (appOid.Length == 3)
            {
                sonuc += "P0000000" + appOid;
            }
            else if (appOid.Length == 4)
            {
                sonuc += "P000000" + appOid;
            }
            else if (appOid.Length == 5)
            {
                sonuc += "P00000" + appOid;
            }
            else if (appOid.Length == 6)
            {
                sonuc += "P0000" + appOid;
            }
            else if (appOid.Length == 7)
            {
                sonuc += "P000" + appOid;
            }
            else if (appOid.Length == 8)
            {
                sonuc += "P00" + appOid;
            }
            else if (appOid.Length == 9)
            {
                sonuc += "P0" + appOid;
            }
            else
            {
                sonuc += "P" + appOid;
            }

            return sonuc;
        }
    }
}
