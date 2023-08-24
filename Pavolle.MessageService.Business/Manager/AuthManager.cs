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
                _authsSystemAdmin.Add(new UserAuthViewData { IsAutorized = item.AdminAuth, ApiKey = item.ApiKey });
                _authsCompanyAdmin.Add(new UserAuthViewData { IsAutorized = item.CompanyAdminAuth, ApiKey = item.ApiKey });
                _authsProjectManager.Add(new UserAuthViewData { IsAutorized = item.ProjectManagerAuth, ApiKey = item.ApiKey });
                _authsDeveloper.Add(new UserAuthViewData { IsAutorized = item.DeveloperAuth, ApiKey = item.ApiKey });
                _authsTechSupport.Add(new UserAuthViewData { IsAutorized = item.TecnicalSupportSpecialistAuth, ApiKey = item.ApiKey });
                _authsLiveSupport.Add(new UserAuthViewData { IsAutorized = item.LiveSupportSpecialistAuth, ApiKey = item.ApiKey });
                _authsAnonymous.Add(new UserAuthViewData { IsAutorized = item.Anonymous, ApiKey = item.ApiKey });
            }
        }

        public AuthDetailResponse Detail(long? oid, MessageServiceRequestBase request)
        {
            throw new NotImplementedException();
        }

        public MessageServiceResponseBase Edit(long? oid, AuthRequest request)
        {
            //TODO Success ise 
            LoadAuthorization();
            throw new NotImplementedException();
        }

        public AuthListResponse List(MessageServiceCriteriaBase criteria)
        {
            throw new NotImplementedException();
        }

        internal List<UserAuthViewData> GetAuthForUserType(EUserType userType)
        {
            throw new NotImplementedException();
        }

        public bool IsAuthorized(string apiKey, EUserType kullaniciTipi)
        {
            return false;
        }
    }
}
