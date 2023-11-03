﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.MessageService.ViewModels.Request
{
    public class AddCountryRequest:MessageServiceRequestBase
    {
        public string ISOCode2 { get; set; }
        public string ISOCode3 { get; set; }
        public string PhoneCode { get; set; }
        public string Name { get; set; }
        public string FlagBase64 { get; set; }
    }
}
