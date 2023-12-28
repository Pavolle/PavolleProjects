using Pavolle.BES.AuthServer.Common.Enums;
using Pavolle.BES.ViewModels.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.BES.AuthServer.ViewModels.Request
{
    public class ForgotPasswordRequest : AnonymousRequestBase
    {
        //TODO Şimdilik mail server entegre edilerek mail server üzerinden varsayılan olarak kod gönderilecek.
        public ECommunicationType CommunicationType { get; set; }

        public string CommunicationValue { get; set; }
    }
}
