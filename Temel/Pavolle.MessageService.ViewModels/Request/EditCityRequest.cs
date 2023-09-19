using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.MessageService.ViewModels.Request
{
    public class EditCityRequest:MessageServiceRequestBase
    {
        public long? CountryOid { get; set; }
        public string Code { get; set; }
        public long? NameTranslateDataOid { get; set; }
        public string Name { get; set; }
    }
}
