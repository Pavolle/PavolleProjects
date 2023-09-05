using Pavolle.Core.Utils;
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
    public class SchedulerManager:Singleton<SchedulerManager>
    {
        private SchedulerManager() { }

        public object Detail(long? oid, MessageServiceRequestBase request)
        {
            throw new NotImplementedException();
        }

        public MessageServiceResponseBase Edit(long? oid, EditSchedulerRequest request)
        {
            throw new NotImplementedException();
        }

        public object List(ListSchedulerCriteria criteria)
        {
            throw new NotImplementedException();
        }

        public MessageServiceResponseBase Run(long? oid, RunSchedulerRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
