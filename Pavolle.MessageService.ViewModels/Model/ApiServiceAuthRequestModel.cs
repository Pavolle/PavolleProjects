using Pavolle.MessageService.Common.Enums;
using Pavolle.Core.Enums;

namespace Pavolle.MessageService.ViewModels.Model
{
    public class ApiServiceAuthRequestModel
    {
        public long UserGroupOid { get; set; }
        public bool IsAuthority { get; set; }
    }
}
