using Pavolle.Core.Utils;
using Pavolle.MessageService.Common.Enums;
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

        public string CheckString(string? text, bool nullable, int minLength, int maxLength, bool xssControl, EMessageServiceMessageCode messageCode)
        {
            throw new NotImplementedException();
        }

        public string CheckEnum<T>(int? enumValue, bool nullable, EMessageServiceMessageCode messageCode)
        {
            throw new NotImplementedException();
        }
    }
}
