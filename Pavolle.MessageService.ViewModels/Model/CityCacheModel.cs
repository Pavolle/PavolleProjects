using Pavolle.MessageService.Common.Enums;
using Pavolle.Core.Enums;

namespace Pavolle.MessageService.ViewModels.Model
{
    public class CityCacheModel
    {
        public long Oid { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public long CountryOid { get; set; }
        public string CountryName { get; set; }
    }
}
