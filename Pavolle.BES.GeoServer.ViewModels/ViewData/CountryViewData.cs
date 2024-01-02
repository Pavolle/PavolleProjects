using Pavolle.Core.ViewModels.ViewData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.BES.GeoServer.ViewModels.ViewData
{
    public class CountryViewData : ViewDataBase
    {
        public string Name { get; set; }
        public string IsoCode2 { get; set; }
        public string IsoCode3 { get; set; }
        public string PhoneCode { get; set; }
        public string Base64Flag { get; set; }
    }
}
