using DevExpress.Xpo;
using log4net;
using Pavolle.Core.Utils;
using Pavolle.Core.ViewModels.Response;
using Pavolle.MessageService.DbModels;
using Pavolle.MessageService.DbModels.Entities;
using Pavolle.MessageService.ViewModels.Criteria;
using Pavolle.MessageService.ViewModels.Model;
using Pavolle.MessageService.ViewModels.Request;
using Pavolle.MessageService.ViewModels.Response;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.MessageService.Business.Manager
{
    public class UserGroupManager : Singleton<UserGroupManager>
    {
        static readonly ILog _log = LogManager.GetLogger(typeof(UserGroupManager));
        ConcurrentDictionary<long, UserGroupCacheModel> _userGroups;
        private UserGroupManager(){}

        public void Initialize()
        {
            LoadUserGroups();
            _log.Debug("Initialize " + nameof(CityManager));
        }

        private void LoadUserGroups()
        {
            using (Session session = XpoManager.Instance.GetNewSession())
            {
                _userGroups = new ConcurrentDictionary<long, UserGroupCacheModel>();

                var _userGroupList = session.Query<UserGroup>().Select(t => new UserGroupCacheModel
                {
                    Oid = t.Oid,
                    Name = t.Name,
                    UserType = t.UserType,
                    OrganizationName = t.Organization == null ? "" : t.Organization.Name,
                    OrganizationOid = t.Organization == null ? (long?)null : t.Organization.Oid
                }).ToList();

                foreach (var item in _userGroupList)
                {
                    _userGroups.TryAdd(item.Oid, item);
                }
            }
        }

        public bool AddUserGroupToCache(UserGroupCacheModel userGroupCache)
        {
            bool response = false;
            return response;
        }

        public bool RemoveUserGroupFromCache(long oid)
        {
            bool response = false;
            return response;
        }

        public bool EditUserGroupCacheModel(long oid, UserGroupCacheModel userGroupCache)
        {
            bool response = false;
            return response;
        }

        internal string GetUserGroupDefinition(long userGroupOid)
        {
            if (!_userGroups.ContainsKey(userGroupOid)) return "";
            var userGroup = _userGroups[userGroupOid];
            if (userGroup == null) return "";
            if (userGroup.OrganizationOid == null) return userGroup.Name;
            return userGroup.OrganizationName + " - " + userGroup.Name;
        }

        public UserGroupListResponse List(ListUserGroupCriteria criteria)
        {
            throw new NotImplementedException();
        }

        public LookupResponse Lookup(LookupUserGroupCriteria criteria)
        {
            throw new NotImplementedException();
        }

        public UserGroupDetailResponse Detail(long? oid, MessageServiceRequestBase request)
        {
            throw new NotImplementedException();
        }

        public MessageServiceResponseBase Edit(long? oid, EditUserGroupRequest request)
        {
            throw new NotImplementedException();
        }

        public MessageServiceResponseBase Add(AddUserGroupRequest request)
        {
            throw new NotImplementedException();
        }

        public MessageServiceResponseBase Delete(long? oid, MessageServiceRequestBase request)
        {
            throw new NotImplementedException();
        }
    }
}
