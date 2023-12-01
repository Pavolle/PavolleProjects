using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.BES.AuthServer.ViewModels.Model
{
    public class TokenCacheModel
    {
        public DateTime ExpireDateTime { get; set; }
        public string Token { get; set; }
    }
}
