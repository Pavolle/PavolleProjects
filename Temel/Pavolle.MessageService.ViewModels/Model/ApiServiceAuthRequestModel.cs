﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.MessageService.ViewModels.Model
{
    public class ApiServiceAuthRequestModel
    {
        public long UserGroupOid { get; set; }
        public bool IsAuthority { get; set; }
    }
}
