using log4net;
using Pavolle.BES.AuthServer.ViewModels.Request;
using Pavolle.BES.AuthServer.ViewModels.Response;
using Pavolle.Core.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.BES.AuthServer.Business.Manager
{
    public class LoginManager : Singleton<LoginManager>
    {
        static readonly ILog _log = LogManager.GetLogger(typeof(LoginManager));
        private LoginManager() { }

        public SignInResponse SignIn(LoginRequest request)
        {
            var response = new SignInResponse();

            return response;
        }
    }
}
