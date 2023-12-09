using Pavolle.BES.AuthServer.Common.Enums;
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

        private RoleManager() { }

        public bool LoadCacheData()
        {
            bool success = false;

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
            return userRoles;
        }

        internal EUserType GetUserType(string username)
        {
            EUserType userType = EUserType.NotUser ;
            return userType;
        }
    }
}
