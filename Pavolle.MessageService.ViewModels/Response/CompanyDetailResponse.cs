﻿using Pavolle.Core.ViewModels.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.MessageService.ViewModels.Response
{
    public class CompanyDetailResponse:DetailResponseBase
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public string Address { get; set; }
    }
}
