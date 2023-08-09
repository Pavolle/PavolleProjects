using Pavolle.Core.ViewModels.ViewData;
using Pavolle.MessageService.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.MessageService.ViewModels.ViewData
{
    public class AppViewData : ViewDataBase
    {
        public string Name { get; set; }
        public string About { get; set; }
        public EAppPlatform Platform { get; set; }
        public string Link { get; set; }
        public string AppId { get; set; }
    }
}
