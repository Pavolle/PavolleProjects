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

        internal List<string> GetUserRolesString(string username)
        {
            throw new NotImplementedException();
        }
    }
}
