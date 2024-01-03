using Pavolle.BES.ViewModels.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.BES.GeoServer.ViewModels.Request
{
    public class EditCountryRequest : IntegrationAppRequestBase
    {
        public string Name { get; set; }
        public string IsoCode2 { get; set; }
        public string IsoCode3 { get; set; }
        public string PhoneCode { get; set; }
        public string Base64Flag { get; set; }
    }
}
