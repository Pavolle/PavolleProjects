using Pavolle.BES.ViewModels.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.BES.GeoServer.ViewModels.Request
{
    public class EditCityRequest : IntegrationAppRequestBase
    {
        public long CountryOid { get; set; }
        public string Name { get; set; }
    }
}
