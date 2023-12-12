using Pavolle.BES.AuthServer.ViewModels.Criteria;
using Pavolle.BES.AuthServer.ViewModels.Request;
using Pavolle.BES.AuthServer.ViewModels.Response;
using Pavolle.BES.ViewModels.Request;
using Pavolle.Core.Utils;
using Pavolle.Core.ViewModels.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.BES.AuthServer.Business.Manager
{
    public class ApiServiceManager : Singleton<ApiServiceManager>
    {
        private ApiServiceManager() { }

        public ApiServiceListResponse List(ApiServiceCriteria request)
        {
            throw new NotImplementedException();
        }

        public ApiServiceDetailResponse Detail(long? oid, IntegrationAppRequestBase request)
        {
            throw new NotImplementedException();
        }

        public ResponseBase Edit(long? oid, EditApiServiceRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
