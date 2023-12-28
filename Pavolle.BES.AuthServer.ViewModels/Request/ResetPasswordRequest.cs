using Pavolle.BES.ViewModels.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.BES.AuthServer.ViewModels.Request
{
    public class ResetPasswordRequest : AnonymousRequestBase
    {
        public long ForgotPasswordDataOid { get; set; }
        public string Username { get; set; }
        public string CommunicationValue { get; set; }
        public string VerificationCode { get; set; }
    }
}
