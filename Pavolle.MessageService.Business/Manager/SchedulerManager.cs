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
    public class SchedulerManager : Singleton<SchedulerManager>
    {
        public SchedulerDetailResponse Detail(long? oid, MessageServiceRequestBase request)
        {
            throw new NotImplementedException();
        }

        public MessageServiceResponseBase Edit(long? oid, SchedulerRequest request)
        {
            throw new NotImplementedException();
        }

        public SchedulerListResponse List(MessageServiceCriteriaBase criteria)
        {
            throw new NotImplementedException();
        }

        public object? Run(long? oid, MessageServiceRequestBase request)
        {
            throw new NotImplementedException();
        }
    }
}
