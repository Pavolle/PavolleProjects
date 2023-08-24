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
