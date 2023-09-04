using Pavolle.Core.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.MessageService.Business.Manager
{
    public class UserGroupManager:Singleton<UserGroupManager>
    {
        private UserGroupManager()
        {

        }

        internal string GetUserGroupDefinition(long userGroupOid)
        {
            throw new NotImplementedException();
        }
    }
}
