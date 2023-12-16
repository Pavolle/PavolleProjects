using Pavolle.BES.AuthServer.ViewModels.ViewData;
using Pavolle.Core.ViewModels.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.BES.AuthServer.ViewModels.Response
{
    public class SignInResponse : ResponseBase
    {
        public string Token { get; set; }
        public List<UserAuthorizationViewData> Authorizations { get; set; }
        public SingInUserDetailViewData UserDetail { get; set; }
    }
}
