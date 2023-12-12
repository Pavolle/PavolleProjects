using Pavolle.BES.AuthServer.ViewModels.Criteria;
using Pavolle.BES.AuthServer.ViewModels.Request;
using Pavolle.BES.ViewModels.Request;
using Pavolle.Core.Utils;
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

        public object List(ApiServiceCriteria request)
        {
            throw new NotImplementedException();
        }

        public object Detail(long? oid, IntegrationAppRequestBase request)
        {
            throw new NotImplementedException();
        }

        public object Edit(long? oid, EditApiServiceRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
