using Pavolle.MessageService.Common.Enums;
using Pavolle.MessageService.ViewModels.Model;
using Pavolle.Core.ViewModels.Request;
using Pavolle.Core.Enums;

namespace Pavolle.MessageService.ViewModels.Request
{
    public class EditTranslateDataRequest : MessageServiceRequestBase
    {
        public string Variable { get; set; }
        public string EN { get; set; }
        public string TR { get; set; }
    }
}
