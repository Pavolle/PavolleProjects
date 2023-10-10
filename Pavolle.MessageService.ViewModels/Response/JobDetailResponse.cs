using Pavolle.Core.Enums;
using Pavolle.MessageService.Common.Enums;
using Pavolle.MessageService.ViewModels.ViewData;
using Pavolle.Core.ViewModels.Response;

namespace Pavolle.MessageService.ViewModels.Response
{
    public class JobDetailResponse : MessageServiceResponseBase
    {
        public JobDetailViewData Detail { get; set; }
        public List<JobLogViewData> JobLogs { get; set; }
    }
}
