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
        public string Name { get; set; }
        public string Surname { get; set; }
    }
}
