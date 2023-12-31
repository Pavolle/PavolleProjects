﻿using Pavolle.Core.ViewModels.ViewData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.MessageService.ViewModels.ViewData
{
    public class OrganizationViewData : ViewDataBase
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public string Address { get; set; }
        public string LogoBase64 { get; set; }
    }
}
