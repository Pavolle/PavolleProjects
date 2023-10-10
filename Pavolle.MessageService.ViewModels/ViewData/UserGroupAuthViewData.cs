using Pavolle.MessageService.Common.Enums;
using Pavolle.Core.Enums;
using Pavolle.MessageService.ViewModels.Model;
using Pavolle.Core.ViewModels.ViewData;

namespace Pavolle.MessageService.ViewModels.ViewData
{
    public class UserGroupAuthViewData : MessageServiceViewDataBase
    {
        public long ApiServiceOid { get; set; }
        public string ApiServiceName { get; set; }
        public bool IsAuhority { get; set; }
    }
}
