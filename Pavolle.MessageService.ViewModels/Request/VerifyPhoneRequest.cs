﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.MessageService.ViewModels.Request
{
    public class VerifyPhoneRequest : MessageServiceRequestBase
    {
        public string Code { get; set; }
    }
}
