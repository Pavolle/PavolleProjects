using Pavolle.MessageService.Common.Enums;
using Pavolle.Core.Enums;
using Pavolle.MessageService.ViewModels.Model;
using Pavolle.Core.ViewModels.ViewData;

namespace Pavolle.MessageService.ViewModels.ViewData
{
    public class OrganizationViewData : MessageServiceViewDataBase
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public string Address { get; set; }
        public string LogoBase64 { get; set; }
    }
}
