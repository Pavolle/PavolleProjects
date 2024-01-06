﻿using Pavolle.BES.GeoServer.ViewModels.ViewData;
using Pavolle.Core.ViewModels.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.BES.GeoServer.ViewModels.Response
{
    public class CountryListResponse : ResponseBase
    {
        public List<CountryViewData> DataList { get; set; }
    }
}
