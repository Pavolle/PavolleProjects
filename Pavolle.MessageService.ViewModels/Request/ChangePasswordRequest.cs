using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.MessageService.ViewModels.Request
{
    public class ChangePasswordRequest : MessageServiceRequestBase
    {

        public string Password { get; set; }
        public string PasswordAgain { get; set; }
    }
}
