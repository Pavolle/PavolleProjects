using Pavolle.BES.GeoServer.ViewModels.ViewData;
using Pavolle.Core.ViewModels.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.BES.GeoServer.ViewModels.Response
{
    public class CityDetailResponse : ResponseBase
    {
        public CityDetailViewData Detail { get; set; }
        public List<DistrictViewData> DistrictList { get; set; }
    }
}
