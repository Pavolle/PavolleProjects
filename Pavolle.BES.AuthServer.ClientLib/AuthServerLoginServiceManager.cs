using Pavolle.BES.AuthServer.ViewModels.Request;
using Pavolle.BES.AuthServer.ViewModels.Response;
using Pavolle.Core.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.BES.AuthServer.ClientLib
{
    public class AuthServerLoginServiceManager : Singleton<AuthServerLoginServiceManager>
    {
        private AuthServerLoginServiceManager() { }

        public SignInResponse SignIn(LoginRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
