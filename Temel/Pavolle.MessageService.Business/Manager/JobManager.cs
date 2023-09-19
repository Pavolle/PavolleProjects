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
    public class JobManager:Singleton<JobManager>
    {
        private JobManager() { }

        public JobListResponse List(ListJobCriteria criteria)
        {
            throw new NotImplementedException();
        }

        public JobDetailResponse Detail(long? oid, MessageServiceRequestBase request)
        {
            throw new NotImplementedException();
        }

        public MessageServiceResponseBase Edit(long? oid, EditJobRequest request)
        {
            throw new NotImplementedException();
        }

        public MessageServiceResponseBase Run(long? oid, RunJobRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
