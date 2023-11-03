using Pavolle.MessageService.Common.Enums;
using Pavolle.Core.Enums;

namespace Pavolle.MessageService.ViewModels.Model
{
    public class CountryCacheModel
    {
        public string ISOCode2 { get; set; }
        public string ISOCode3 { get; set; }
        public string PhoneCode { get; set; }
        public string FlagBase64 { get; set; }
        public string ENName { get; set; }
        public string TRName { get; set; }
    }
}
