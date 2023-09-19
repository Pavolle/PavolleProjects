using Pavolle.MessageService.ViewModels.ViewData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.MessageService.ViewModels.Response
{
    public class TokenResponse:MessageServiceResponseBase
    {
        public int WrongTryCount { get; set; }
        public bool IsLocked { get; set; }
        public string Token { get; set; }
        public List<UserAuthViewData> Authorizations { get; set; }
        public UserInfoViewData UserInfo { get; set; }
    }
}
