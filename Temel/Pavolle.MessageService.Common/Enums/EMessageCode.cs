using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.MessageService.Common.Enums
{
    public enum EMessageCode
    {
        XNotFound = 1,
        XSaved,
        XCannotBeDeleted,
        XDeleted,
        XCannotBeLeftBlank,
        XNotTheExpectedLength,
        XNotValid,
        SecurityError,
        UsernameOrPasswordIsNotCorrect,
        UserIsLocked,
        CommunicationType,
        UnexpectedError,
        CodeSendedToEmailNumber,
        CodeSendedToPhoneNumber,
        ApiService,
        ApiDefinition,
        Auhtorizations,
        TranslateData,
        City,
        Country,
        Username,
        CommunicationValue,
        Password,
    }
}
