using Pavolle.BES.LogServer.ViewModels.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.BES.LogServer.ViewModels.Model
{
    public class LogModel : LogRequest
    {
        public DateTime TimeToArrive { get; set; }
    }
}
