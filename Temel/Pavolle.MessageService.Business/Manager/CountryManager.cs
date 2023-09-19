using Pavolle.Core.Utils;
using Pavolle.Core.ViewModels.Response;
using Pavolle.MessageService.ViewModels.Criteria;
using Pavolle.MessageService.ViewModels.Request;
using Pavolle.MessageService.ViewModels.Response;

namespace Pavolle.MessageService.Business.Manager
{
    public class CountryManager:Singleton<CountryManager>
    {
        private CountryManager() { }

        public CountryListResponse List(ListCountryCriteria criteria)
        {
            throw new NotImplementedException();
        }

        public LookupResponse Lookup(LookupCountryCriteria criteria)
        {
            throw new NotImplementedException();
        }

        public CountryDetailResponse Detail(long? oid, MessageServiceRequestBase request)
        {
            throw new NotImplementedException();
        }

        public MessageServiceResponseBase Add(AddCountryRequest request)
        {
            throw new NotImplementedException();
        }

        public MessageServiceResponseBase Edit(long? oid, EditCountryRequest request)
        {
            throw new NotImplementedException();
        }

        public MessageServiceResponseBase Delete(long? oid, DeleteCountryCriteria request)
        {
            throw new NotImplementedException();
        }
    }
}
