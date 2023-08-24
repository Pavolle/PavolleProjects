using DevExpress.Xpo;
using Pavolle.Core.Utils;
using Pavolle.MessageService.Common.Enums;
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
    public class AuthManager:Singleton<AuthManager>
    {
        //SystemAdmin=1,
        //CompanyAdmin=2,
        //User=3,
        //ProjectManager
        List<UserAuthViewData> _authsSystemAdmin;
        List<UserAuthViewData> _authsCompanyAdmin;
        List<UserAuthViewData> _authsProjectManager;
        List<UserAuthViewData> _authsDeveloper;
        List<UserAuthViewData> _authsTechSupport;
        List<UserAuthViewData> _authsLiveSupport;
        List<UserAuthViewData> _authsAnonymous;

        List<AuthViewData> _auths;

        private AuthManager()
        {
            LoadAuthorization();
        }

        private void LoadAuthorization()
        {
            using (Session session = XpoManager.Instance.GetNewSession())
            {
                _auths = session.Query<Auth>().Select(t => new AuthViewData
                {
                    Oid = t.Oid,
                    CreatedTime = t.CreatedTime,
                    LastUpdateTime = t.LastUpdateTime,
                    ApiKey = t.ApiKey,
                    ApiDefinition = t.ApiDefinition,
                    AdminAuth = t.AdminAuth,
                    CompanyAdminAuth = t.CompanyAdminAuth,
                    ProjectManagerAuth = t.ProjectManagerAuth,
                    DeveloperAuth = t.DeveloperAuth,
                    TecnicalSupportSpecialistAuth = t.TecnicalSupportSpecialistAuth,
                    LiveSupportSpecialistAuth = t.LiveSupportSpecialistAuth,
                    Editable = t.Editable,
                    Anonymous = t.Anonymous
                }).ToList();
            }

            _authsSystemAdmin = new List<UserAuthViewData>();
            _authsCompanyAdmin = new List<UserAuthViewData>();
            _authsProjectManager = new List<UserAuthViewData>(); ;
            _authsDeveloper = new List<UserAuthViewData>();
            _authsTechSupport = new List<UserAuthViewData>();
            _authsLiveSupport = new List<UserAuthViewData>();

            foreach (var item in _auths)
            {
                _authsSystemAdmin.Add(new UserAuthViewData { IsAutorized = item.AdminAuth, ApiKey = item.ApiKey.Replace("{oid}","") });
                _authsCompanyAdmin.Add(new UserAuthViewData { IsAutorized = item.CompanyAdminAuth, ApiKey = item.ApiKey.Replace("{oid}", "") });
                _authsProjectManager.Add(new UserAuthViewData { IsAutorized = item.ProjectManagerAuth, ApiKey = item.ApiKey.Replace("{oid}", "") });
                _authsDeveloper.Add(new UserAuthViewData { IsAutorized = item.DeveloperAuth, ApiKey = item.ApiKey.Replace("{oid}", "") });
                _authsTechSupport.Add(new UserAuthViewData { IsAutorized = item.TecnicalSupportSpecialistAuth, ApiKey = item.ApiKey.Replace("{oid}", "") });
                _authsLiveSupport.Add(new UserAuthViewData { IsAutorized = item.LiveSupportSpecialistAuth, ApiKey = item.ApiKey.Replace("{oid}", "") });
                _authsAnonymous.Add(new UserAuthViewData { IsAutorized = item.Anonymous, ApiKey = item.ApiKey.Replace("{oid}", "") });
            }
        }

        public AuthDetailResponse Detail(long? oid, MessageServiceRequestBase request)
        {
            var response= _auths.Where(t => t.Oid == oid.Value).Select(t => new AuthDetailResponse
            {
                Oid = t.Oid,
                AdminAuth = t.AdminAuth,
                Anonymous = t.Anonymous,
                ApiDefinition = t.ApiDefinition,
                ApiKey=t.ApiKey,
               CompanyAdminAuth=t.CompanyAdminAuth,
               CreatedTime=t.CreatedTime,
               DeveloperAuth=t.DeveloperAuth,
               Editable=t.Editable,
               LastUpdateTime=t.LastUpdateTime,
               LiveSupportSpecialistAuth=t.LiveSupportSpecialistAuth,
               ProjectManagerAuth=t.ProjectManagerAuth,
               TecnicalSupportSpecialistAuth = t.TecnicalSupportSpecialistAuth,
               Success=true
            }).FirstOrDefault();

            if (response == null)
            {
                response = new AuthDetailResponse();
                response.ErrorMessage = "";
                response.Success = false;
                return response;
            }
            else return response;
        }

        public MessageServiceResponseBase Edit(long? oid, AuthRequest request)
        {
            var response = new MessageServiceResponseBase();

            using(Session session = XpoManager.Instance.GetNewSession())
            {
                var auth = session.Query<Auth>().FirstOrDefault(t => t.Oid == oid.Value);
                if (auth == null)
                {
                    response.Success = false;
                    return response;
                }
                if (!auth.Editable)
                {
                    //Yetki ile ilgili süreçler değiştirilemez.
                    response.Success = false;
                    return response;
                }

                auth.ApiDefinition = request.ApiDefinition;
                auth.AdminAuth=request.AdminAuth;
                auth.CompanyAdminAuth = request.CompanyAdminAuth;
                auth.ProjectManagerAuth = request.ProjectManagerAuth;
                auth.DeveloperAuth = request.DeveloperAuth;
                auth.TecnicalSupportSpecialistAuth = request.TecnicalSupportSpecialistAuth;
                auth.LiveSupportSpecialistAuth=request.LiveSupportSpecialistAuth;
                auth.Save();

            }
            //TODO Success ise 
            LoadAuthorization();

            return response;
        }

        public AuthListResponse List(MessageServiceCriteriaBase criteria)
        {
            return new AuthListResponse
            {
                DataList = _auths
            };
        }

        internal List<UserAuthViewData> GetAuthForUserType(EUserType? userType)
        {
            switch (userType)
            {
                case EUserType.SystemAdmin:
                    return _authsSystemAdmin;
                case EUserType.CompanyAdmin:
                    return _authsCompanyAdmin;
                case EUserType.ProjectManager:
                    return _authsProjectManager;
                case EUserType.Developer:
                    return _authsDeveloper;
                case EUserType.TecnicalSupportSpecialist:
                    return _authsTechSupport;
                case EUserType.LiveSupportSpecialist:
                    return _authsLiveSupport;
                default:
                    return _authsAnonymous;
            }
        }

        public bool IsAuthorized(string apiKey, EUserType? userType)
        {
            UserAuthViewData? data;
            switch (userType)
            {
                case EUserType.SystemAdmin:
                    data = _authsSystemAdmin.FirstOrDefault(t => apiKey.StartsWith(t.ApiKey));
                    break;
                case EUserType.CompanyAdmin:
                    data = _authsCompanyAdmin.FirstOrDefault(t => apiKey.StartsWith(t.ApiKey));
                    break;
                case EUserType.ProjectManager:
                    data = _authsProjectManager.FirstOrDefault(t => apiKey.StartsWith(t.ApiKey));
                    break;
                case EUserType.Developer:
                    data = _authsDeveloper.FirstOrDefault(t => apiKey.StartsWith(t.ApiKey));
                    break;
                case EUserType.TecnicalSupportSpecialist:
                    data = _authsTechSupport.FirstOrDefault(t => apiKey.StartsWith(t.ApiKey));
                    break;
                case EUserType.LiveSupportSpecialist:
                    data = _authsLiveSupport.FirstOrDefault(t => apiKey.StartsWith(t.ApiKey));
                    break;
                default:
                    data = _authsAnonymous.FirstOrDefault(t => apiKey.StartsWith(t.ApiKey));
                    break;
            }
            if (data == null) return false;
            return data.IsAutorized;
        }
    }
}
