using Pavolle.Core.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.MessageService.Business.Manager
{
    public class CommunicationManager:Singleton<CommunicationManager>
    {
        private CommunicationManager() { }

        internal bool GenerateResetCodeAndSendEmailToUser(string username)
        {
            throw new NotImplementedException();
        }

        internal bool GenerateResetCodeAndSendSMSToUser(string username)
        {
            throw new NotImplementedException();
        }
    }
}
