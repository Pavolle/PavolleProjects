﻿using Pavolle.BES.ViewModels.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.BES.Surrvey.ViewModels.Request
{
    public class AddSurveyRequest : BesRequestBase
    {
        public string About { get; set; }
        public string Header { get; set; }
    }
}
