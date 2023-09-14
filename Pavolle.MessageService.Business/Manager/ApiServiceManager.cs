using Pavolle.Core.Utils;
using Pavolle.MessageService.ViewModels.Criteria;
using Pavolle.MessageService.ViewModels.Request;
using Pavolle.MessageService.ViewModels.Response;
using Pavolle.MessageService.ViewModels.ViewData;
using Pavolle.MessageService.ViewModels.Model;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExpress.Xpo;
using Pavolle.MessageService.DbModels;
using Pavolle.MessageService.DbModels.Entities;
using System.Security.Cryptography;

namespace Pavolle.MessageService.Business.Manager
{
    public class ApiServiceManager:Singleton<ApiServiceManager>
    {
        ConcurrentDictionary<long, AuhtorizationCacheModel> _services;
        private ApiServiceManager()
        {
            LoadAuthorizations();
        }

        private void LoadAuthorizations()
        {
            using (Session session = XpoManager.Instance.GetNewSession())
            {
                var services = session.Query<Auth>().Select(t => new AuhtorizationCacheModel
                {
                    Oid=t.Oid,
                    ApiKey = t.ApiService.ApiKey,
                    IsAuthority = t.IsAuhtority,
                    UserGroupOid = t.UserGroup.Oid,
                    MethodType = t.ApiService.MethodType
                }).ToList();

                foreach (var item in services)
                {
                    _services.TryAdd(item.Oid, item);
                }
            }
        }

        public ApiServiceListResponse List(ListApiServiceCriteria criteria)
        {
            throw new NotImplementedException();
        }

        public ApiServiceDetailResponse Detail(long? oid, MessageServiceRequestBase request)
        {
            throw new NotImplementedException();
        }

        public MessageServiceResponseBase Edit(long? oid, EditApiServiceRequest request)
        {
            throw new NotImplementedException();
        }

        internal List<UserAuthViewData>? GetAuthList(long userGroupOid)
        {
            throw new NotImplementedException();
        }
    }
}
