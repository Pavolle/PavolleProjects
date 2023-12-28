using Pavolle.Core.ViewModels.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.BES.AuthServer.ViewModels.Response
{
    public class ForgotPasswordResponse : ResponseBase
    {
        public bool UserVerified { get; set; }
        public long? DataOid { get; set; }
    }
}
