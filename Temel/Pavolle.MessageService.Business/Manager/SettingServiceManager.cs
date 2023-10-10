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
    public class SettingServiceManager : Singleton<SettingServiceManager>
    {
        private SettingServiceManager() 
        { 
        }



        public SettingListResponse List(ListSettingCriteria request)
        {
            throw new NotImplementedException();
        }

        public SettingDetailResponse Detail(long? oid, MessageServiceRequestBase request)
        {
            throw new NotImplementedException();
        }

        public MessageServiceResponseBase Edit(long? oid, EditSettingRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
