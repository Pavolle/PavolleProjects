using Pavolle.B2B.Common.Enums;
using Pavolle.Core.Enums;
using Pavolle.B2B.ViewModels.Model;
using Pavolle.Core.ViewModels.ViewData;

namespace Pavolle.B2B.ViewModels.ViewData
{
    public class OrganizationViewData : B2BViewDataBase
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public string Address { get; set; }
        public string LogoBase64 { get; set; }
    }
}
