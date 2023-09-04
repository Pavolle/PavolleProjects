using Pavolle.Core.Utils;
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
        private AuthManager()
        {

        }

        internal List<UserAuthViewData>? GetAuthList(long userGroupOid)
        {
            throw new NotImplementedException();
        }
    }
}
