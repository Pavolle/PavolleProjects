using Pavolle.MessageService.Common.Enums;
using Pavolle.MessageService.ViewModels.Model;
using Pavolle.Core.ViewModels.Request;
using Pavolle.Core.Enums;

namespace Pavolle.MessageService.ViewModels.Request
{
    public class EditJobRequest : MessageServiceRequestBase
    {
        public string Name { get; set; }
        public string Cron { get; set; }
        public bool? Active { get; set; }
    }
}
