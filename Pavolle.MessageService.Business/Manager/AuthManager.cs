using Pavolle.Core.Utils;
using Pavolle.MessageService.ViewModels.Criteria;
using Pavolle.MessageService.ViewModels.Request;
using Pavolle.MessageService.ViewModels.Response;
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

        public object Detail(long? oid, MessageServiceRequestBase request)
        {
            throw new NotImplementedException();
        }

        public MessageServiceResponseBase Edit(long? oid, EditAuthRequest request)
        {
            throw new NotImplementedException();
        }

        public object List(ListAuthCriteria criteria)
        {
            throw new NotImplementedException();
        }

        internal List<UserAuthViewData>? GetAuthList(long userGroupOid)
        {
            throw new NotImplementedException();
        }
    }
}
