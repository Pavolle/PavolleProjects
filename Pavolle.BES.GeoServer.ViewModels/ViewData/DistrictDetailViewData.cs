using Pavolle.Core.ViewModels.ViewData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.BES.GeoServer.ViewModels.ViewData
{
    public class DistrictDetailViewData : ViewDataBase
    {
        public CountryDetailViewData CountyDetail { get; set; }
        public CityDetailViewData CityDetail { get; set; }
        public string Name { get; set; }
    }
}
