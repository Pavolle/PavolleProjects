using Pavolle.Core.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.BES.AuthServer.Business.Manager
{
    public class RoleManager : Singleton<RoleManager>
    {
        private RoleManager() { }

        internal string GetUserRolesString(string username)
        {
            throw new NotImplementedException();
        }
    }
}
