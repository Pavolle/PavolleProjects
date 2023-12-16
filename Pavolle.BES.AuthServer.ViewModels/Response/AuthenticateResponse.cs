using Pavolle.Core.ViewModels.Response;
using Pavolle.Core.ViewModels.ViewData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.BES.AuthServer.ViewModels.Response
{
    public class AuthenticateResponse : ResponseBase
    {
        public bool IsUserValidated { get; set; }
        public string SessionId { get; set; }
        public List<LookupViewData> RoleList { get; set; }
    }
}
