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
    public class CityManager:Singleton<CityManager>
    {
        private CityManager() { }

        public object Detail(long? oid, MessageServiceRequestBase request)
        {
            throw new NotImplementedException();
        }

        public MessageServiceResponseBase Edit(long? oid, EditCityRequest request)
        {
            throw new NotImplementedException();
        }

        public MessageServiceResponseBase Add(AddCityRequest request)
        {
            throw new NotImplementedException();
        }

        public object List(ListCityCriteria criteria)
        {
            throw new NotImplementedException();
        }

        public LookupResponse Lookup(LookupCityCriteria criteria)
        {
            throw new NotImplementedException();
        }

        public MessageServiceResponseBase Delete(long? oid, DeleteCityCriteria request)
        {
            throw new NotImplementedException();
        }
    }
}
