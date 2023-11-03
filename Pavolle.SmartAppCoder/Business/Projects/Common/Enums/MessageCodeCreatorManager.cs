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
            icerik += "        XSaved," + Environment.NewLine;
            icerik += "        XCannotBeDeleted," + Environment.NewLine;
            icerik += "        XDeleted," + Environment.NewLine;
            icerik += "        XCannotBeLeftBlank," + Environment.NewLine;
            icerik += "        XNotTheExpectedLength," + Environment.NewLine;
            icerik += "        XNotValid," + Environment.NewLine;
            icerik += "        XCanNotBeChanged," + Environment.NewLine;
            icerik += "        SecurityError," + Environment.NewLine;
            icerik += "        UsernameOrPasswordIsNotCorrect," + Environment.NewLine;
            icerik += "        UserIsLocked," + Environment.NewLine;
            icerik += "        CommunicationType," + Environment.NewLine;
            icerik += "        UnexpectedError," + Environment.NewLine;
            icerik += "        CodeSendedToEmailNumber," + Environment.NewLine;
            icerik += "        CodeSendedToPhoneNumber," + Environment.NewLine;
            icerik += "        ApiService," + Environment.NewLine;
            icerik += "        ApiDefinition," + Environment.NewLine;
            icerik += "        Auhtorizations," + Environment.NewLine;
            icerik += "        TranslateData," + Environment.NewLine;
            icerik += "        City," + Environment.NewLine;
            icerik += "        Country," + Environment.NewLine;
            icerik += "        Username," + Environment.NewLine;
            icerik += "        CommunicationValue," + Environment.NewLine;
            icerik += "        Password," + Environment.NewLine;
            return FileHelperManager.Instance.WriteFile(projectPath, _creator.Path, _creator.ClassName + ".cs", _creator.EnumClass.Replace("//<EnumContent>", icerik));
        }
    }
}
