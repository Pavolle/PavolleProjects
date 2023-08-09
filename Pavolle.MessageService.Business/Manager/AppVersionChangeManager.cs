using Pavolle.Core.Utils;
using Pavolle.MessageService.ViewModels.Criteria;
using Pavolle.MessageService.ViewModels.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.MessageService.Business.Manager
{
    public class AppVersionChangeManager:Singleton<AppVersionChangeManager>
    {
        private AppVersionChangeManager() { }

        public object? Delete(long oid, MessageServiceRequestBase request)
        {
            throw new NotImplementedException();
        }

        public object? Detail(long? oid, MessageServiceRequestBase request)
        {
            throw new NotImplementedException();
        }

        public object? Edit(long? oid, VersionChangeRequest request)
        {
            throw new NotImplementedException();
        }

        public object? Add(VersionChangeRequest request)
        {
            throw new NotImplementedException();
        }

        public object? List(VersionChangeCriteria criteria)
        {
            throw new NotImplementedException();
        }
    }
}
