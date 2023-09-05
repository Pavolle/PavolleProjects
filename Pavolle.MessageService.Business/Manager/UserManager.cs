using Pavolle.Core.Utils;
using Pavolle.Core.ViewModels.Response;
using Pavolle.MessageService.ViewModels.Criteria;
using Pavolle.MessageService.ViewModels.Request;
using Pavolle.MessageService.ViewModels.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.MessageService.Business.Manager
{
    public class UserManager : Singleton<UserManager>
    {
        private UserManager() { }

        public MessageServiceResponseBase Delete(long? oid, DeleteUserCriteria request)
        {
            throw new NotImplementedException();
        }

        public object Detail(long? oid, MessageServiceRequestBase request)
        {
            throw new NotImplementedException();
        }

        public MessageServiceResponseBase Edit(long? oid, EditUserRequest request)
        {
            throw new NotImplementedException();
        }

        public MessageServiceResponseBase Add( AddUserRequest request)
        {
            throw new NotImplementedException();
        }

        public object List(ListUserCriteria criteria)
        {
            throw new NotImplementedException();
        }

        public LookupResponse Lookup(LookupUserCriteria criteria)
        {
            throw new NotImplementedException();
        }
    }
}
