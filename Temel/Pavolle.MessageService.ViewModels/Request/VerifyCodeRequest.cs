﻿using Pavolle.Core.Enums;
using Pavolle.Core.ViewModels.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.MessageService.ViewModels.Request
{
    public class VerifyCodeRequest:ForgotPasswordRequest
    {
        public string Code { get; set; }
    }
}
