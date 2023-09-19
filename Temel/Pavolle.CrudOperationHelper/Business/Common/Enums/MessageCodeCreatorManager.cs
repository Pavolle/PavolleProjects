using Pavolle.Core.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.CrudOperationHelper.Business.Common.Enums
{
    public class MessageCodeCreatorManager : Singleton<MessageCodeCreatorManager>, ICreatorManager
    {
        CommonEnumCreatorManager _creator;
        private MessageCodeCreatorManager() { }

        public bool Write(string companyName, string projectName, string projectPath)
        {
            _creator = new CommonEnumCreatorManager(companyName, projectName, projectPath, "EMessageCode");
            string icerik = "";
            icerik += "        XNotFound = 1," + Environment.NewLine;
            icerik += "        SecurityError = 2," + Environment.NewLine;
            icerik += "        UsernameOrPasswordIsNotCorrect = 3," + Environment.NewLine;
            icerik += "        UserIsLocked = 4," + Environment.NewLine;
            icerik += "        Username = 5," + Environment.NewLine;
            icerik += "        CommunicationValue = 6," + Environment.NewLine;
            icerik += "        Password = 7," + Environment.NewLine;
            icerik += "        CommunicationType = 8," + Environment.NewLine;
            icerik += "        UnexpectedError = 9," + Environment.NewLine;
            icerik += "        CodeSendedToEmailNumber = 10," + Environment.NewLine;
            icerik += "        CodeSendedToPhoneNumber = 11" + Environment.NewLine;
            return FileHelperManager.Instance.WriteFile(projectPath, _creator.Path, _creator.ClassName + ".cs", _creator.EnumClass.Replace("//<EnumContent>", icerik));
        }
    }
}
