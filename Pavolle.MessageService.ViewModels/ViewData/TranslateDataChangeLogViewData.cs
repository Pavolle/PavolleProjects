using Pavolle.MessageService.Common.Enums;
using Pavolle.Core.Enums;
using Pavolle.MessageService.ViewModels.Model;
using Pavolle.Core.ViewModels.ViewData;

namespace Pavolle.MessageService.ViewModels.ViewData
{
    public class TranslateDataChangeLogViewData : MessageServiceViewDataBase
    {
        public string Variable { get; set; }
        public string OldEN { get; set; }
        public string NewEN { get; set; }
        public string OldTR { get; set; }
        public string NewTR { get; set; }
    }
}
