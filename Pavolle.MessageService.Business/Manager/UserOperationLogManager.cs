using log4net;
using Pavolle.Core.Utils;
using Pavolle.MessageService.ViewModels.Request;
using Pavolle.MessageService.ViewModels.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.MessageService.Business.Manager
{
    public class UserOperationLogManager:Singleton<UserOperationLogManager>
    {
        static readonly ILog _log = LogManager.GetLogger(typeof(UserOperationLogManager));
        private UserOperationLogManager()
        {

        }

        internal string Save(string appName, string service, MessageServiceRequestBase request, MessageServiceResponseBase response)
        {
            throw new NotImplementedException();
        }
    }
}
