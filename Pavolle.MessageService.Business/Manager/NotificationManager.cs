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
    public class NotificationManager:Singleton<NotificationManager>
    {
        private NotificationManager()
        {

        }

        public object? Detail(long? oid, MessageServiceRequestBase request)
        {
            //Otomatik görüntüleme de true olarak işaretlenecek.
            throw new NotImplementedException();
        }

        public object? List(MessageServiceCriteriaBase criteria)
        {
            throw new NotImplementedException();
        }
    }
}
