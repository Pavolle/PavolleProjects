using log4net;
using Pavolle.Core.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.MessageService.Business.Manager
{
    public class MessageManager:Singleton<MessageManager>
    {
        static readonly ILog _log = LogManager.GetLogger(typeof(MessageManager));
        private MessageManager() { }
    }
}
