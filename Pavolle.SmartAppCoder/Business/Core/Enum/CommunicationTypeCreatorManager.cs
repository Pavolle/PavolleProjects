using Pavolle.SmartAppCoder.Common.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.SmartAppCoder.Business.Core.Enum
{
    public class CommunicationTypeCreatorManager : Singleton<CommunicationTypeCreatorManager>
    {
        private CommunicationTypeCreatorManager() { }

        public bool Create(string projectPath, string organizationName)
        {
            string content = "";
            content += "        Phone = 1," + Environment.NewLine;
            content += "        Mail = 2" + Environment.NewLine;
            string classString= EnumClassGenerator.Instance.Generate(organizationName + ".Core.Enums", "ECommunicationType", content);
            return FileHelperManager.Instance.WriteFile(projectPath + "\\" + organizationName + ".Core", "Enums", "ECommunicationType.cs", classString);

        }
    }
}
