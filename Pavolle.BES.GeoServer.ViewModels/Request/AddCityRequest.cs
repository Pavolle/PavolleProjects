﻿using Pavolle.BES.ViewModels.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.BES.GeoServer.ViewModels.Request
{
    public class AddCityRequest : IntegrationAppRequestBase
    {
        public string Name { get; set; }
        public long CountryOid { get; set; }
    }
}
