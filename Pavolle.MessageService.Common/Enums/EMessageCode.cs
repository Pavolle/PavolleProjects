using System.ComponentModel;

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
        XCanNotBeChanged,
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
