using Pavolle.Core.ViewModels.Response;
using Pavolle.MessageService.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.MessageService.ViewModels.Response
{
    public class AppDetailResponse : DetailResponseBase
    {
        public string About { get; set; }
        public EAppPlatform Platform { get; set; }
        public string Link { get; set; }
        public string AppId { get; set; }
        public string Name { get; set; }
    }
}
