using Pavolle.Core.ViewModels.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.BES.ViewModels.Response
{
    public class ServerStatusResponseBase : ResponseBase
    {
        public string AppInfo { get; set; }
        public string Version { get; set; }
        public string ReleaseDate { get; set; }
        public bool ServerStatus { get; set; }
        public string ServerStatusString { get; set; }
    }
}
