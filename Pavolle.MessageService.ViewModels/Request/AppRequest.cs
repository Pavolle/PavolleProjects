using Pavolle.MessageService.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.MessageService.ViewModels.Request
{
    public class AppRequest:MessageServiceRequestBase
    {
        public string Name { get; set; }
        public string About { get; set; }
        public EAppPlatform? Platform { get; set; }
        public string Link { get; set; }
        public string Base64Image { get; set; }
    }
}
