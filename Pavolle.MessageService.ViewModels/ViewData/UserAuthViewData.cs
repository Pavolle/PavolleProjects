using Pavolle.MessageService.Common.Enums;
using Pavolle.Core.Enums;
using Pavolle.MessageService.ViewModels.Model;
using Pavolle.Core.ViewModels.ViewData;

namespace Pavolle.MessageService.ViewModels.ViewData
{
    public class UserAuthViewData : MessageServiceViewDataBase
    {
        public string ApiKey { get; set; }
        public bool IsAuthority { get; set; }
    }
}
