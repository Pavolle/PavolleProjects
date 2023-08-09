using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.MessageService.ViewModels.Request
{
    public class AppErrorRequest:MessageServiceRequestBase
    {
        public string AppId { get; set; }
        public string Version { get; set; }
        public string Header { get; set; }
        public string Content { get; set; }
    }
}
