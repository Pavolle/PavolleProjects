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
    public class ApiServiceManager:Singleton<ApiServiceManager>
    {
        private ApiServiceManager()
        {

        }

        public ApiServiceDetailResponse Detail(long? oid, MessageServiceRequestBase request)
        {
            throw new NotImplementedException();
        }

        public MessageServiceResponseBase Edit(long? oid, EditApiServiceRequest request)
        {
            throw new NotImplementedException();
        }

        public ApiServiceListResponse List(ListApiServiceCriteria criteria)
        {
            throw new NotImplementedException();
        }

        internal List<UserAuthViewData>? GetAuthList(long userGroupOid)
        {
            throw new NotImplementedException();
        }
    }
}
