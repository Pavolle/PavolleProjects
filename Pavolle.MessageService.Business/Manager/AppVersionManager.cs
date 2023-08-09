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
    public class AppVersionManager:Singleton<AppVersionManager>
    {
        private AppVersionManager() { }

        public MessageServiceResponseBase Delete(long oid, MessageServiceRequestBase request)
        {
            throw new NotImplementedException();
        }

        public object? Detail(long? oid, MessageServiceRequestBase request)
        {
            throw new NotImplementedException();
        }

        public MessageServiceResponseBase Edit(long? oid, AppVersionRequest request)
        {
            throw new NotImplementedException();
        }

        public MessageServiceResponseBase Add(AppVersionRequest request)
        {
            throw new NotImplementedException();
        }

        public object? List(AppVersionCriteria criteria)
        {
            throw new NotImplementedException();
        }

        public LookupResponse Lookup(AppVersionCriteria criteria)
        {
            throw new NotImplementedException();
        }
    }
}
