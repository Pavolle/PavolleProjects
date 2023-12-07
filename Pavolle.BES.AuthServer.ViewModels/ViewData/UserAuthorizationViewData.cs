using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.BES.AuthServer.ViewModels.ViewData
{
    public class UserAuthorizationViewData
    {
        public string ApiServiceKey { get; set; }
        public bool IsAuthority { get; set; }
    }
}
