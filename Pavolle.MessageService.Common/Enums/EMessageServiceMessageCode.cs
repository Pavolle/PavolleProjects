using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.MessageService.Common.Enums
{
    public enum EMessageServiceMessageCode
    {
        XNotFound=1,
        SecurityError,
        UsernameOrPasswordIsNotCorrect,
        UserIsLocked
    }
}
