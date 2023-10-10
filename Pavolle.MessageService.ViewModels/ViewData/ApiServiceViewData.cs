using Pavolle.MessageService.Common.Enums;
using Pavolle.Core.Enums;
using Pavolle.MessageService.ViewModels.Model;
using Pavolle.Core.ViewModels.ViewData;

namespace Pavolle.MessageService.ViewModels.ViewData
{
    public class ApiServiceViewData : MessageServiceViewDataBase
    {
        public string ApiKey { get; set; }
        public string ApiDefinition { get; set; }
        public EApiServiceMethodType MethodType { get; set; }
        public bool EditableForAdmin { get; set; }
        public bool EditableForOrganization { get; set; }
        public bool Anonymous { get; set; }
    }
}
