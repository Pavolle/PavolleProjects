using Pavolle.Core.Enums;
using Pavolle.Core.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.BES.RequestValidation
{
    public class NullValidationManager : Singleton<NullValidationManager>
    {
        private NullValidationManager() { }

        public void Check(object objectValue, bool canBeNulli, string objectName, ELanguage language)
        {

        }
    }
}
