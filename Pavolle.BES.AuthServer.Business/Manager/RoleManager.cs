using DevExpress.Xpo;
using Pavolle.BES.AuthServer.Common.Enums;
using Pavolle.BES.AuthServer.DbModels;
using Pavolle.BES.AuthServer.DbModels.Entities;
using Pavolle.BES.AuthServer.ViewModels.Model;
using Pavolle.Core.Utils;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.BES.AuthServer.Business.Manager
{
    public class RoleManager : Singleton<RoleManager>
    {
        //Username Roles
        ConcurrentDictionary<string, List<UserRoleCacheModel>> _userRoles;
        DateTime _lastRefreshTime = DateTime.Now;

        public DateTime GetLastRefreshTime()
        {
            return _lastRefreshTime;
        }

        private RoleManager() 
        {
            _userRoles=new ConcurrentDictionary<string, List<UserRoleCacheModel>>();
        }

        public bool LoadCacheData()
        {
            bool success = false;
            using(Session session =AuthServerXpoManager.Instance.GetNewSession())
            {
                var dataList = session.Query<UserRole>().Select(t => new UserRoleCacheModel
                {
                    Username=t.User.Username,
                    OrganizationOid=t.Role.Organization ==null? (long?)null:t.Role.Organization.Oid,
                    OrganizationName = t.Role.Organization == null ? "" : t.Role.Organization.Name,
                    RoleName =t.Role.Name,
                    RoleOid=t.Role.Oid,
                    UserType=t.Role.UserType
                }).ToList();

                foreach (var item in dataList)
                {
                    if (_userRoles.ContainsKey(item.Username))
                    {
                        _userRoles[item.Username].Add(item);
                    }
                    else
                    {
                        _userRoles.TryAdd(item.Username, new List<UserRoleCacheModel> { item });
                    }
                }
            }
            _lastRefreshTime = DateTime.Now;
            return success;
        }

        internal long GetUserRoleOid(string username)
        {
            long roleOid = 0;
            return roleOid;
        }

        internal List<string> GetUserRolesString(string username)
        {
            //Burda eğer organizasyon kullanıcı varsa onun da adını eklememiz lazım. Örneğin Pavolle - Organization Admin
            List<string> userRoles = new List<string>();
            if (_userRoles.ContainsKey(username))
            {
                userRoles = _userRoles[username].Select(x => x.RoleName).ToList();
            }
            return userRoles;
        }

        internal EUserType GetUserType(string username)
        {
            EUserType userType = EUserType.NotUser ;
            return userType;
        }
    }
}
