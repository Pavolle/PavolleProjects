using Pavolle.BES.ViewModels.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.BES.GeoServer.ViewModels.Request
{
    public class AddDistrictRequest : IntegrationAppRequestBase
    {
        public string Name { get; set; }
        public long CityOid { get; set; }
    }
}
