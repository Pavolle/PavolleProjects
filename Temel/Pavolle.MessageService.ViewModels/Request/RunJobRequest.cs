﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.MessageService.ViewModels.Request
{
    public class RunJobRequest:MessageServiceRequestBase
    {
        public string MailToList { get; set; }
    }
}
