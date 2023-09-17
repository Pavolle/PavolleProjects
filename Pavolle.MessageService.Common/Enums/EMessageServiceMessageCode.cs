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
        XSaved = 2,
        XCannotBeDeleted = 3,
        XDeleted = 4,
        SecurityError = 5,
        UsernameOrPasswordIsNotCorrect = 6,
        UserIsLocked = 7,
        CommunicationType = 8,
        UnexpectedError = 9,
        CodeSendedToEmailNumber = 10,
        CodeSendedToPhoneNumber = 11,
        ApiService = 12,
        ApiDefinition = 13,
        Auhtorizations = 14,
        TranslateData = 15,
        City = 16,
        Country = 17,
        Username = 18,
        CommunicationValue = 19,
        Password = 20,
    }
}
