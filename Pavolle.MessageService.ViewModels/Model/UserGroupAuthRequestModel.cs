using Pavolle.MessageService.Common.Enums;
using Pavolle.Core.Enums;

namespace Pavolle.MessageService.ViewModels.Model
{
    public class UserGroupAuthRequestModel
    {
        public long ApiServiceOid { get; set; }
        public bool IsAuthority { get; set; }
    }
}
