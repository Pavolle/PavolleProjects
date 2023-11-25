using Pavolle.BES.ViewModels.Request;
using Pavolle.Core.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.BES.RequestValidation
{
    public class BaseParameterValidationManager : Singleton<BaseParameterValidationManager>
    {
        private BaseParameterValidationManager() { }

        public BesValidationResult Validate(BesRequestBase requestBase) 
        {
            return new BesValidationResult { Validated = true };
        }
    }
}
