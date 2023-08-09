using Pavolle.Core.Utils;
using Pavolle.MessageService.ViewModels.Criteria;
using Pavolle.MessageService.ViewModels.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.MessageService.Business.Manager
{
    public class IssueManager:Singleton<IssueManager>
    {
        private IssueManager() { }

        public object? Delete(long oid, MessageServiceRequestBase request)
        {
            throw new NotImplementedException();
        }

        public object? Detail(long? oid, MessageServiceRequestBase request)
        {
            throw new NotImplementedException();
        }

        public object? Edit(long? oid, IssueRequest request)
        {
            throw new NotImplementedException();
        }

        public object? Add(IssueRequest request)
        {
            throw new NotImplementedException();
        }

        public object? List(IssueCriteria criteria)
        {
            throw new NotImplementedException();
        }

        public object? Lookup(IssueCriteria criteria)
        {
            throw new NotImplementedException();
        }
    }
}
