﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.MessageService.ViewModels.Request
{
    public class EditSettingRequest:MessageServiceRequestBase
    {
        public string SettingName { get; set; }
        public string Value { get; set; }
    }
}
