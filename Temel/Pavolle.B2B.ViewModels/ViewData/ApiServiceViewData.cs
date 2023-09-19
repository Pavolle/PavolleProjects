using Pavolle.B2B.Common.Enums;
using Pavolle.Core.Enums;
using Pavolle.B2B.ViewModels.Model;
using Pavolle.Core.ViewModels.ViewData;

namespace Pavolle.B2B.ViewModels.ViewData
{
    public class ApiServiceViewData : B2BViewDataBase
    {
        public string ApiKey { get; set; }
        public string ApiDefinition { get; set; }
        public EApiServiceMethodType MethodType { get; set; }
        public bool EditableForAdmin { get; set; }
        public bool EditableForOrganization { get; set; }
        public bool Anonymous { get; set; }
    }
}
