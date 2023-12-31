﻿using Pavolle.BES.AuthServer.ViewModels.ViewData;
using Pavolle.Core.ViewModels.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.BES.AuthServer.ViewModels.Response
{
    public class ApiServiceListResponse : ResponseBase
    {
        public List<ApiServiceViewData> DataList { get; set; }
    }
}
