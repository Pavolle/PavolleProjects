using Pavolle.Core.Utils;
using Pavolle.MessageService.ViewModels.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.MessageService.Business.Manager
{
    public class LogHelperManager:Singleton<LogHelperManager>
    {
        private LogHelperManager() { }

        public string GetLogBase(MessageServiceRequestBase request)
        {
            var sonuc = "";
            return sonuc;
        }
    }
}
