using Pavolle.Core.Enums;

namespace Pavolle.Core.ViewModels.Request
{
    public class RequestBase:IRequest
    {
        public ELanguage? Language { get; set; }
        public string RequestIp { get; set; }
    }
}
