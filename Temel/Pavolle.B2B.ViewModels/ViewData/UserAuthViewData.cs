using Pavolle.B2B.Common.Enums;
using Pavolle.Core.Enums;
using Pavolle.B2B.ViewModels.Model;
using Pavolle.Core.ViewModels.ViewData;

namespace Pavolle.B2B.ViewModels.ViewData
{
    public class UserAuthViewData : B2BViewDataBase
    {
        public string ApiKey { get; set; }
        public bool IsAuthority { get; set; }
    }
}
