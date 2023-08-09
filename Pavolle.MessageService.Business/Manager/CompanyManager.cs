using DevExpress.Xpo;
using Pavolle.Core.Utils;
using Pavolle.Core.ViewModels.Response;
using Pavolle.MessageService.DbModels;
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
    public class CompanyManager:Singleton<CompanyManager>
    {
        private CompanyManager() { }

        public MessageServiceResponseBase Delete(long oid, MessageServiceRequestBase request)
        {
            throw new NotImplementedException();
        }

        public CompanyDetailResponse Detail(long? oid, MessageServiceRequestBase request)
        {
            throw new NotImplementedException();
        }

        public MessageServiceResponseBase Edit(long? oid, CompanyRequest request)
        {
            throw new NotImplementedException();
        }

        public MessageServiceResponseBase Add(CompanyRequest request)
        {
            var response=new MessageServiceResponseBase();
            using (Session session=XpoManager.Instance.GetNewSession())
            {

            }
            return response;
        }

        public CompanyListResponse List(MessageServiceCriteriaBase criteria)
        {
            throw new NotImplementedException();
        }

        public LookupResponse Lookup(MessageServiceCriteriaBase criteria)
        {
            throw new NotImplementedException();
        }
    }
}
