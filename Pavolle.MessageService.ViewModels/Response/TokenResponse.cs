using Pavolle.MessageService.ViewModels.ViewData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.MessageService.ViewModels.Response
{
    public class TokenResponse : MessageServiceResponseBase
    {
        public string Token { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public List<UserAuthViewData> Auths { get; set; }
        public string Username { get; set; }
    }
}
