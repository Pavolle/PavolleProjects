using DevExpress.Xpo;
using log4net;
using Pavolle.Core.Utils;
using Pavolle.Core.Enums;
using Pavolle.MessageService.Common.Enums;
using Pavolle.MessageService.DbModels;
using Pavolle.MessageService.DbModels.Entities;
using Pavolle.MessageService.ViewModels.Criteria;
using Pavolle.MessageService.ViewModels.Model;
using Pavolle.MessageService.ViewModels.Request;
using Pavolle.MessageService.ViewModels.Response;
using Pavolle.MessageService.ViewModels.ViewData;
using System.Collections.Concurrent;

namespace Pavolle.MessageService.Business.Manager
{
    public class AuthManager : Singleton<AuthManager>
    {
        static readonly ILog _log = LogManager.GetLogger(typeof(AuthManager));
        ConcurrentDictionary<string, AuhtorizationCacheModel> _cacheData;
        private AuthManager() 
        {
            _log.Debug("Initialize " + nameof(AuthManager));
        }

        public void Initialize()
        {
            LoadCacheData();
        }

        private void LoadCacheData()
        {
            try
            {
                using (Session session = XpoManager.Instance.GetNewSession())
                {
                    var services = session.Query<Auth>().Select(t => new AuhtorizationCacheModel
                    {
                        Oid = t.Oid,
                        ApiKey = t.ApiService.ApiKey,
                        IsAuthority = t.IsAuhtority,
                        UserGroupOid = t.UserGroup.Oid,
                        MethodType = t.ApiService.MethodType,
                        Anonymous=t.ApiService.Anonymous
                    }).ToList();

                    _cacheData = new ConcurrentDictionary<string, AuhtorizationCacheModel>();
                    foreach (var item in services)
                    {
                        _cacheData.TryAdd(item.ApiKey.Replace("/{oid}",""), item);
                    }
                }
            }
            catch (Exception ex)
            {
                _log.Error("Unexpected error occured! Error: " + ex);
            }
        }

        internal List<UserAuthViewData> GetAuthList(long userGroupOid)
        {
            return _cacheData.ToList().Where(t => t.Value.UserGroupOid == userGroupOid).Select(t => new UserAuthViewData
            {
                ApiKey = t.Key,
                IsAuthority = t.Value.IsAuthority
            }).ToList();
        }

        public bool IsAuthority(string apiKey, long userGroupOid)
        {
            try
            {
                var data = _cacheData.FirstOrDefault(t => apiKey.StartsWith(t.Key) && t.Value.UserGroupOid==userGroupOid);
                if(data.Value.Anonymous) { return true; }
                return data.Value.IsAuthority;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
