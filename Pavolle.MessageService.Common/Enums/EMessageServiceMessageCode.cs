using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.MessageService.Common.Enums
{
    public enum EMessageServiceMessageCode
    {
        XNotFound = 1,
        SecurityError = 2,
        UsernameOrPasswordIsNotCorrect = 3,
        UserIsLocked = 4,
        Username = 5,
        CommunicationValue = 6,
        Password = 7,
        CommunicationType = 8,
        UnexpectedError = 9,
        CodeSendedToEmailNumber = 10,
        CodeSendedToPhoneNumber = 11
    }
}
