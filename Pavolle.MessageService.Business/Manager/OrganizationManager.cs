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
    public class OrganizationManager:Singleton<OrganizationManager>
    {
        public OrganizationManager() { }

        public MessageServiceResponseBase Delete(long? oid, DeleteOrganizationCriteria request)
        {
            throw new NotImplementedException();
        }

        public object Detail(long? oid, MessageServiceRequestBase request)
        {
            throw new NotImplementedException();
        }

        public MessageServiceResponseBase Edit(long? oid, EditOrganizationRequest request)
        {
            throw new NotImplementedException();
        }

        public MessageServiceResponseBase Add(AddOrganizationRequest request)
        {
            throw new NotImplementedException();
        }


        public object List(ListOrganizationCriteria criteria)
        {
            throw new NotImplementedException();
        }

        public LookupResponse Lookup(LookupOrganizationCriteria criteria)
        {
            throw new NotImplementedException();
        }
    }
}
