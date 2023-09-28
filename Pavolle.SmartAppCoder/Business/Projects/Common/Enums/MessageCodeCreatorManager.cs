using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pavolle.SmartAppCoder.Business;
using Pavolle.SmartAppCoder.Common.Utils;

namespace Pavolle.SmartAppCoder.Business.Projects.Common.Enums
{
    public class MessageCodeCreatorManager : Singleton<MessageCodeCreatorManager>
    {
        CommonEnumCreatorManager _creator;
        private MessageCodeCreatorManager() { }

        public bool Create(string companyName, string projectName, string projectPath)
        {
            _creator = new CommonEnumCreatorManager(companyName, projectName, projectPath, "EMessageCode");
            string icerik = "";
            icerik += "        XNotFound = 1," + Environment.NewLine;
            icerik += "        XSaved = 2," + Environment.NewLine;
            icerik += "        XCannotBeDeleted = 3," + Environment.NewLine;
            icerik += "        XDeleted = 4," + Environment.NewLine;
            icerik += "        SecurityError = 5," + Environment.NewLine;
            icerik += "        UsernameOrPasswordIsNotCorrect = 6," + Environment.NewLine;
            icerik += "        UserIsLocked = 7," + Environment.NewLine;
            icerik += "        CommunicationType = 8," + Environment.NewLine;
            icerik += "        UnexpectedError = 9," + Environment.NewLine;
            icerik += "        CodeSendedToEmailNumber = 10," + Environment.NewLine;
            icerik += "        CodeSendedToPhoneNumber = 11," + Environment.NewLine;
            icerik += "        ApiService = 12," + Environment.NewLine;
            icerik += "        ApiDefinition = 13," + Environment.NewLine;
            icerik += "        Auhtorizations = 14," + Environment.NewLine;
            icerik += "        TranslateData = 15," + Environment.NewLine;
            icerik += "        City = 16," + Environment.NewLine;
            icerik += "        Country = 17," + Environment.NewLine;
            icerik += "        Username = 18," + Environment.NewLine;
            icerik += "        CommunicationValue = 19," + Environment.NewLine;
            icerik += "        Password = 20," + Environment.NewLine;
            return FileHelperManager.Instance.WriteFile(projectPath, _creator.Path, _creator.ClassName + ".cs", _creator.EnumClass.Replace("//<EnumContent>", icerik));
        }
    }
}
