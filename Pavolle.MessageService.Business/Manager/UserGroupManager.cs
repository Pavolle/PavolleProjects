using DevExpress.Xpo;
using Pavolle.Core.Utils;
using Pavolle.MessageService.DbModels;
using Pavolle.MessageService.DbModels.Entities;
using Pavolle.MessageService.ViewModels.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.MessageService.Business.Manager
{
    public class UserGroupManager:Singleton<UserGroupManager>
    {
        List<UserGroupCacheModel> _userGroups;
        private UserGroupManager()
        {
            using (Session session = XpoManager.Instance.GetNewSession())
            {
                ReloadUserGroups(session);
            }
        }

        private void ReloadUserGroups(Session session)
        {
            _userGroups = session.Query<UserGroup>().Select(t => new UserGroupCacheModel
            {
                Oid=t.Oid,
                Name = t.Name,
                UserType = t.UserType,
                OrganizationName = t.Organization == null ? "" : t.Organization.Name,
                OrganizationOid = t.Organization == null ? (long?)null : t.Organization.Oid
            }).ToList();
        }

        internal string GetUserGroupDefinition(long userGroupOid)
        {
            var userGroup = _userGroups.FirstOrDefault(t => t.Oid == userGroupOid);
            if (userGroup == null) return "";
            if (userGroup.OrganizationOid == null) return userGroup.Name;
            return userGroup.OrganizationName + " - " + userGroup.Name;
        }
    }
}
