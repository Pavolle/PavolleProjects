using Pavolle.MessageService.Common.Enums;
using Pavolle.Core.Enums;
using Pavolle.MessageService.ViewModels.Model;
using Pavolle.Core.ViewModels.ViewData;

namespace Pavolle.MessageService.ViewModels.ViewData
{
    public class TranslateDataViewData : MessageServiceViewDataBase
    {
        public string Variable { get; set; }
        public string EN { get; set; }
        public string TR { get; set; }
    }
}
