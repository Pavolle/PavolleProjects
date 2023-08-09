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
    public class MessageManagmentManager:Singleton<MessageManagmentManager>
    {
        private MessageManagmentManager() { }

        public object? Detail(long? oid, MessageServiceRequestBase request)
        {
            throw new NotImplementedException();
        }

        public object? List(MessageManagmentCriteria criteria)
        {
            throw new NotImplementedException();
        }
    }
}
