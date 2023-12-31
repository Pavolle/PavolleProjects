﻿using Pavolle.MessageService.ViewModels.Model;
using Pavolle.MessageService.ViewModels.ViewData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.MessageService.ViewModels.Request
{
    public class EditApiServiceRequest : MessageServiceRequestBase
    {
        public string ApiDefinition { get; set; }
        public List<ApiServiceAuthRequestModel> Auhtorizations { get; set; }
    }
}
