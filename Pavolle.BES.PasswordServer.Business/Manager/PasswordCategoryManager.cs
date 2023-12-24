using DevExpress.Xpo;
using Pavolle.BES.AuthServer.ClientLib;
using Pavolle.BES.PasswordServer.DbModels;
using Pavolle.BES.PasswordServer.DbModels.Entities;
using Pavolle.BES.PasswordServer.ViewModels.Request;
using Pavolle.BES.PasswordServer.ViewModels.Response;
using Pavolle.BES.PasswordServer.ViewModels.ViewData;
using Pavolle.BES.SettingServer.ClientLib;
using Pavolle.BES.TranslateServer.ClientLib;
using Pavolle.BES.TranslateServer.Common.Enums;
using Pavolle.BES.ViewModels.Request;
using Pavolle.BES.ViewModels.Response;
using Pavolle.Core.Utils;
using Pavolle.Core.ViewModels.Response;
using Pavolle.Core.ViewModels.ViewData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.BES.PasswordServer.Business.Manager
{
    public class PasswordCategoryManager : Singleton<PasswordCategoryManager>
    {
        private PasswordCategoryManager () { }

        public ResponseBase Add(AddPasswordCategoryRequest request)
        {
            var response = new ResponseBase();
            //request Kontrolleri

            using(Session session= PasswordServerXpoManager.Instance.GetNewSession())
            {
                if(session.Query<PasswordCategory>().Any(t=>t.Definition==request.Definition && t.OrganizationOid==request.OrganizationOid)) 
                {
                    response.ErrorMessage = TranslateServiceManager.Instance.GetMessage(EMessageCode.DataCreatedBefore, SettingServiceManager.Instance.GetDefaultLanguage());
                    response.StatusCode = 400;
                    return response;
                }

                var passCategory = new PasswordCategory(session)
                {
                    Definition = request.Definition,
                    IsPersonal = request.IsPersonal.Value
                };

                if(request.IsPersonal.Value)
                {
                    passCategory.BelongUserOid = request.UserOid;
                }
                passCategory.Save();
            }

            return response;
        }

        public PasswordCategoryDetailResponse Detail(long? oid, BesRequestBase request)
        {
            var response = new PasswordCategoryDetailResponse();
            //request Kontrolleri

            using (Session session = PasswordServerXpoManager.Instance.GetNewSession())
            {
                var data = session.Query<PasswordCategory>().FirstOrDefault(t => t.Oid == oid);
                if(data==null)
                {
                    response.ErrorMessage = TranslateServiceManager.Instance.GetMessage(EMessageCode.RecordNotFoundException, SettingServiceManager.Instance.GetDefaultLanguage());
                    response.StatusCode = 400;
                    return response;
                }

                response.Detail = new PasswordCategoryDetailViewData
                {
                    BelongUserOid = data.BelongUserOid,
                    Definition = data.Definition,
                    Oid = data.Oid,
                    IsPersonal = data.IsPersonal,
                    CreatedTime = data.CreatedTime,
                    LastUpdateTime = data.LastUpdateTime
                };

                if (data.IsPersonal)
                {
                    response.Detail.BelongPersonInfo = AuthServerUserServiceManager.Instance.GetPersonCacheModelFromUserOid(data.BelongUserOid);
                }
            }

            return response;
        }

        public ResponseBase Edit(long? oid, EditPasswordCategoryRequest request)
        {
            var response = new ResponseBase();
            //request Kontrolleri

            using (Session session = PasswordServerXpoManager.Instance.GetNewSession())
            {
                var passCategory = session.Query<PasswordCategory>().FirstOrDefault(t => t.Oid == oid);
                if (passCategory == null)
                {
                    response.ErrorMessage = TranslateServiceManager.Instance.GetMessage(EMessageCode.RecordNotFoundException, SettingServiceManager.Instance.GetDefaultLanguage());
                    response.StatusCode = 400;
                    return response;
                }

                passCategory.Definition = request.Definition;
                passCategory.LastUpdateTime = DateTime.Now;
                passCategory.Save();

                passCategory.Save();
            }

            return response;
        }

        public PasswordCategoryListResponse List(BesRequestBase request)
        {
            var response = new PasswordCategoryListResponse();
            //request Kontrolleri

            using (Session session = PasswordServerXpoManager.Instance.GetNewSession())
            {
                response.DataList = session.Query<PasswordCategory>().Where(t => t.OrganizationOid == request.OrganizationOid && (t.IsPersonal == false || t.BelongUserOid == request.UserOid)).Select(t => new PasswordCategoryViewData
                {
                    Oid = t.Oid,
                    CreatedTime =t.CreatedTime,
                    LastUpdateTime = t.LastUpdateTime,
                    Definition=t.Definition,
                    IsPersonal=t.IsPersonal
                }).ToList();
                
            }

            return response;
        }

        public LookupResponse Lookup(BesRequestBase request)
        {
            var response = new LookupResponse();
            //request Kontrolleri

            using (Session session = PasswordServerXpoManager.Instance.GetNewSession())
            {
                response.DataList = session.Query<PasswordCategory>().Where(t => t.OrganizationOid == request.OrganizationOid && (t.IsPersonal == false || t.BelongUserOid == request.UserOid)).Select(t => new LookupViewData
                {
                    Key = t.Oid,
                    Value = t.Definition,
                    IsDefault = false
                }).ToList();

            }

            return response;
        }
    }
}
