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
    public class AppErrorManager:Singleton<AppErrorManager>
    {
        private AppErrorManager()
        {

        }

        public object? Detail(long? oid, MessageServiceRequestBase request)
        {
            throw new NotImplementedException();
        }

        public object? List(AppErrorCriteria criteria)
        {
            throw new NotImplementedException();
        }

        public object? Add(AppErrorRequest request)
        {
            //Rabbit katmanına eklenecek. Buradan alınıp tek tek işlenecek.
            throw new NotImplementedException();
        }
    }
}
