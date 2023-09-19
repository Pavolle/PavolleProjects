using Pavolle.B2B.Common.Enums;
using Pavolle.Core.Enums;
using Pavolle.B2B.ViewModels.Model;
using Pavolle.Core.ViewModels.ViewData;

namespace Pavolle.B2B.ViewModels.ViewData
{
    public class JobLogViewData : B2BViewDataBase
    {
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public bool Success { get; set; }
        public string Result { get; set; }
    }
}
