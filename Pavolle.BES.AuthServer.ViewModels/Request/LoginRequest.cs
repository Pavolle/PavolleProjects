using Pavolle.BES.ViewModels.Request;
using Pavolle.Core.ViewModels.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.BES.AuthServer.ViewModels.Request
{
    public class LoginRequest : AnonymousRequestBase
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
