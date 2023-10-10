using Pavolle.MessageService.Common.Enums;
using Pavolle.Core.Enums;

namespace Pavolle.MessageService.ViewModels.Model
{
    public class TranslateDataCacheModel
    {
        public long Oid { get; set; }
        public string Variable { get; set; }
        public string EN { get; set; }
        public string TR { get; set; }
    }
}
