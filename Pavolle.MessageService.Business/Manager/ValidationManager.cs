﻿using Pavolle.Core.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.MessageService.Business.Manager
{
    public class ValidationManager:Singleton<ValidationManager>
    {
        private ValidationManager() { }

        public string CheckString(string? text, bool nullable, int minLength, int maxLength, bool xssControl)
        {
            throw new NotImplementedException();
        }
    }
}
