using Pavolle.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.MessageService.ViewModels.Request
{
    public class SendVerificationCodeRequest : MessageServiceRequestBase
    {
        public ECommunicationType CommunicationType { get; set; }
    }
}
