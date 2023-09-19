using Pavolle.B2B.Common.Enums;
using Pavolle.B2B.ViewModels.Model;
using Pavolle.Core.ViewModels.Request;
using Pavolle.Core.Enums;

namespace Pavolle.B2B.ViewModels.Request
{
    public class EditTranslateDataRequest : B2BRequestBase
    {
        public string Variable { get; set; }
        public string TR { get; set; }
        public string EN { get; set; }
        public string RU { get; set; }
        public string FR { get; set; }
        public string ES { get; set; }
        public string AZ { get; set; }
    }
}
