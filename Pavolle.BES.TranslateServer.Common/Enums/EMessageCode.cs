using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.BES.TranslateServer.Common.Enums
{
    public enum EMessageCode
    {
        [Description("Unexpected error occured!")]
        UnexpectedExceptionOccured=1,

        [Description("Request Data Type Error!")]
        RequestDataTypeError,
        UnauthorizedException
    }
}
