using Pavolle.BES.TranslateServer.Common.Enums;
using Pavolle.Core.Enums;
using Pavolle.Core.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.BES.RequestValidation
{
    public class StringValidationManager : Singleton<StringValidationManager>
    {
        private StringValidationManager() { }

        public BesValidationResult Validate(string property, bool canBeNull, int minLength, int maxLength, EMessageCode messageCode, ELanguage? language)
        {
            throw new NotImplementedException();
        }
    }
}
