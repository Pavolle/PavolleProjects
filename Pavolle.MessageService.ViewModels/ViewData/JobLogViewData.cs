using Pavolle.MessageService.Common.Enums;
using Pavolle.Core.Enums;
using Pavolle.MessageService.ViewModels.Model;
using Pavolle.Core.ViewModels.ViewData;

namespace Pavolle.MessageService.ViewModels.ViewData
{
    public class JobLogViewData : MessageServiceViewDataBase
    {
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public bool Success { get; set; }
        public string Result { get; set; }
    }
}
