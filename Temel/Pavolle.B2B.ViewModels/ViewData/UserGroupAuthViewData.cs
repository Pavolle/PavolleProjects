using Pavolle.B2B.Common.Enums;
using Pavolle.Core.Enums;
using Pavolle.B2B.ViewModels.Model;
using Pavolle.Core.ViewModels.ViewData;

namespace Pavolle.B2B.ViewModels.ViewData
{
    public class UserGroupAuthViewData : B2BViewDataBase
    {
        public long ApiServiceOid { get; set; }
        public string ApiServiceName { get; set; }
        public bool IsAuhority { get; set; }
    }
}
